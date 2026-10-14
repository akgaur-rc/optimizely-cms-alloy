---
name: optimizely-cms-api-security
description: Design and troubleshoot secure external integrations with Optimizely CMS 13 APIs and Graph, including service-to-service authentication, OAuth scopes, content permissions, and draft-versus-publish boundaries.
---

# Optimizely CMS API Integration and Security Skill

## Establish the correct API first
- Identify the CMS version and the actual API being requested: CMS REST API for management operations, Optimizely Graph/GraphQL for querying and delivery, or a version-specific legacy API.
- Never assume `EPiServer.ContentDeliveryApi.Cms`, `EPiServer.ContentManagementApi`, or `EPiServer.OpenIDConnect` is the correct package set for CMS 13. Check compatibility against the exact version.
- Distinguish an external client (for example, a service called Metafy) from the CMS application. Do not infer what the external service does beyond the supplied requirements.

## Security workflow
1. Identify the calling application, environment, required operations, and data classification.
2. Choose the documented auth mechanism for the selected API and version.
3. Use least privilege. Separate read/query access from create/update/delete/publish privileges.
4. Verify both token scopes/claims and CMS content-level authorization. A scope alone does not guarantee permission to edit every item.
5. If publishing is prohibited, enforce and test that boundary server-side; do not rely only on the external client UI.
6. Store client secrets in environment variables or a secrets manager. Never commit them or include them in logs.
7. Use HTTPS for non-local environments. Avoid exposing preview/draft content to public clients.
8. Test valid token, missing token, insufficient scope, insufficient content permission, forbidden publish, and expired/invalid credential scenarios.

## Data-flow explanation
- A delivery/query API lets the external system read content from CMS/Graph.
- A management API lets the external system create or modify content if authorized.
- These are separate capabilities; installing both does not automatically synchronize data in either direction.
- Describe the direction explicitly: request/response, polling, webhook, or scheduled sync. Do not imply automatic synchronization unless it is implemented.

## Official references
- CMS 13 developer overview: https://docs.optimizely.com/cms-13/docs/developer-overview-cms-13
- CMS 13 overview: https://docs.developers.optimizely.com/content-management-system/v13.0.0-CMS/docs/cms-13-overview
- Graph C# SDK authentication: https://docs.developers.optimizely.com/content-management-system/v13.0.0-CMS/docs/authentication
- CMS 13 Graph C# SDK quick start: https://docs.optimizely.com/cms-13/docs/quick-start
