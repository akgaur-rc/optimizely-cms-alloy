---
name: optimizely-graph-csharp
description: Query Optimizely Graph from .NET/CMS 13 applications with the Graph C# SDK or GraphQL. Use for content delivery, search, filtering, sorting, pagination, authentication, or troubleshooting empty results and 401 errors.
---

# Optimizely Graph C# SDK Skill

## Use the CMS 13 path
- CMS 13 uses Optimizely Graph for content indexing and delivery. Do not assume the legacy CMS 12 Content Delivery API setup applies.
- Official CMS 13 quick start requires .NET 10+, a provisioned Graph instance with AppKey and Secret, and content synchronized to Graph.
- The documented query package is `Optimizely.Graph.Cms.Query`. Confirm current versions and DI registration from the official docs before adding code.

## Implementation workflow
1. Inspect the target framework and installed Optimizely Graph packages.
2. Confirm the Graph instance exists and the correct environment's endpoint/credentials are available.
3. Check whether content is synchronized; if not, consult the CMS scheduled-job instructions for Graph full synchronization.
4. Prefer the typed C# SDK for .NET server-side code when it fits the use case. Use raw GraphQL/HTTP when the caller is a JavaScript frontend or needs a custom query.
5. Inject the SDK client through the supported DI mechanism for the installed version. Do not invent registration APIs.
6. Query only the fields needed. Add appropriate filtering, ordering, limits, and pagination.
7. Keep AppKey/Secret out of source control; use environment variables or a secret manager.
8. Test unauthorized, empty-result, and service-unavailable scenarios and log enough context without exposing secrets.

## Troubleshooting
- `401 Unauthorized`: verify endpoint, AppKey/Secret, environment, and auth mode.
- Empty results: verify content is published/eligible for the selected auth mode and that Graph synchronization completed.
- DI/client resolution failure: verify the package and registration approach match the exact installed SDK version.
- Stale/missing content: check the Graph sync pipeline and the indexed schema/type names.

## Official references
- CMS 13 Graph C# SDK quick start: https://docs.optimizely.com/cms-13/docs/quick-start
- Graph C# SDK overview: https://docs.developers.optimizely.com/content-management-system/v13.0.0-CMS/docs/overview-of-c-sharp-sdk
- SDK authentication: https://docs.developers.optimizely.com/content-management-system/v13.0.0-CMS/docs/authentication
- CMS 13 developer overview: https://docs.optimizely.com/cms-13/docs/developer-overview-cms-13
