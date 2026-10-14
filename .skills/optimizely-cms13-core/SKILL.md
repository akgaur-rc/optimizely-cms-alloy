---
name: optimizely-cms13-core
description: Build, configure, debug, and review Optimizely CMS 13 PaaS applications using .NET 10. Use when working on CMS setup, dependency injection, content types, Razor/MVC rendering, migrations, configuration, or CMS 12-to-13 compatibility.
---

# Optimizely CMS 13 Core Skill

## First principles
- Treat CMS 13 as a .NET 10+ application. Inspect the repository's target framework, package versions, project layout, and existing conventions before editing.
- CMS 13 is cloud-first. Optimizely Graph and Opti ID are core platform components for the full CMS 13 experience. Traditional ASP.NET MVC/Razor rendering is still possible.
- Do not assume CMS 12 instructions or packages work on CMS 13. Verify every API, package, method, and configuration setting against CMS 13 documentation and the installed package version.
- Prefer small, incremental changes. Explain any required external service, account, AppKey, Secret, or environment configuration rather than inventing credentials.

## Workflow
1. Inspect `*.sln`, `*.csproj`, `Program.cs`, configuration files, content model folders, and existing tests.
2. Identify exact CMS and .NET versions from project files and package references.
3. Consult the official CMS 13 docs below before implementing version-specific behavior.
4. Follow existing naming, dependency-injection, logging, and error-handling conventions.
5. Make the smallest coherent change; avoid upgrading packages or restructuring the application unless requested.
6. Build and run relevant tests when possible. Report commands run and any blockers honestly.
7. Never put secrets in source control. Use user secrets/environment variables or the team's approved secret store.

## CMS content modeling
- Model pages and blocks using the patterns supported by the installed CMS 13 packages.
- Keep content definitions separate from presentation where the project conventions support it.
- For Razor rendering, add or update the matching view/component using the repository's existing pattern.
- Avoid inventing attributes, base classes, or registration calls. Verify their availability in the current package version.

## CMS 12 compatibility guardrails
- Do not blindly add `EPiServer.ContentDeliveryApi.Cms`, `EPiServer.ContentManagementApi`, `EPiServer.OpenIDConnect`, Search & Navigation, or CMS 12 template commands to a CMS 13 project.
- If the task asks for a legacy API, first verify CMS 13 package compatibility and recommend the CMS 13-supported API/Graph route when appropriate.
- Distinguish content delivery (reading/querying content) from content management (creating/updating content) and authentication/authorization.

## Official references
- CMS 13 developer overview: https://docs.optimizely.com/cms-13/docs/developer-overview-cms-13
- CMS 13 install: https://docs.optimizely.com/cms-13/docs/install-cms-13
- CMS 13 system requirements: https://docs.optimizely.com/cms-13/docs/system-requirements
- CMS 13 deployment scenarios: https://docs.optimizely.com/cms-13/docs/deployment-scenarios
