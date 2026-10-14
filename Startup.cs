using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.ContentApi.Cms;
using EPiServer.ContentApi.Core.DependencyInjection;
using EPiServer.Data;
using EPiServer.DependencyInjection;
using EPiServer.OpenIDConnect;
using EPiServer.Scheduler;
using EPiServer.Web.Routing;
using OptiLearningAlloy.Extensions;

namespace OptiLearningAlloy
{
    public class Startup(IWebHostEnvironment webHostingEnvironment, IConfiguration configuration)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            if (webHostingEnvironment.IsDevelopment())
            {
                AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(webHostingEnvironment.ContentRootPath, "App_Data"));

                services.Configure<SchedulerOptions>(options => options.Enabled = false);
            }

            services.Configure<DataAccessOptions>(o => o.UpdateDatabaseCompatibilityLevel = true);

            services
                .AddCmsAspNetIdentity<ApplicationUser>()
                .AddCms()
                .AddAlloy()
                .AddAdminUserRegistration()
                .AddEmbeddedLocalization<Startup>();

            // Content Delivery API (read) secured with the OpenID Connect scheme
            services
                .AddContentDeliveryApi(OpenIDConnectOptionsDefaults.AuthenticationScheme, options =>
                {
                    options.SiteDefinitionApiEnabled = true;
                })
                .WithFriendlyUrl()
                .WithSiteBasedCors();

            // OpenID Connect authentication (OpenIddict-based) with a client for Postman
            var postmanClientId = configuration["OpenIDConnect:Postman:ClientId"] ?? "postman-client";
            var postmanClientSecret = configuration["OpenIDConnect:Postman:ClientSecret"] ?? "postman";

            services.AddOpenIDConnectUI();
            services.AddOpenIDConnect<ApplicationUser>(
                useDevelopmentCertificate: true,
                signingCertificate: null,
                encryptionCertificate: null,
                createSchema: true,
                options =>
                {
                    options.RequireHttps = !webHostingEnvironment.IsDevelopment();

                    options.Applications.Add(new OpenIDConnectApplication
                    {
                        ClientId = postmanClientId,
                        ClientSecret = postmanClientSecret,
                        Scopes =
                        {
                            ContentDeliveryApiOptionsDefaults.Scope,
                            "openid",
                            "offline_access",
                            "profile",
                            "email",
                            "roles",
                            "epi_content_delivery",
                            "epi_content_management",
                        },
                        PostLogoutRedirectUris = { new Uri("http://localhost:5000/") },
                        RedirectUris = { new Uri("http://localhost:5000/") },
                    });
                });

            // Required by Wangkanai.Detection
            services.AddDetection();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Required by Wangkanai.Detection
            app.UseDetection();
            app.UseSession();

            app.UseStaticFiles();
            app.UseRouting();

            // CORS policy registered by WithSiteBasedCors (must run before auth/endpoints)
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapContent();
            });
        }
    }
}

