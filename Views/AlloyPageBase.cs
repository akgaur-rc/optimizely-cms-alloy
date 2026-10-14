using EPiServer.ServiceLocation;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OptiLearningAlloy.Business.Rendering;

namespace OptiLearningAlloy.Views
{
    public abstract class AlloyPageBase<TModel>(AlloyContentAreaItemRenderer alloyContentAreaItemRenderer)
        : RazorPage<TModel> where TModel : class
    {
        public abstract override Task ExecuteAsync();

        public AlloyPageBase()
            : this(ServiceLocator.Current.GetInstance<AlloyContentAreaItemRenderer>())
        {
        }

        protected void OnItemRendered(ContentAreaItem contentAreaItem, TagHelperContext context, TagHelperOutput output)
        {
            alloyContentAreaItemRenderer.RenderContentAreaItemCss(contentAreaItem, context, output);
        }
    }
}
