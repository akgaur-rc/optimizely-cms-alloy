---
name: optimizely-cms-content-modeling
description: Create or modify Optimizely CMS 13 page and block content models, properties, editor metadata, Razor rendering, and content composition. Use when implementing CMS-managed page sections or reusable blocks.
---

# Optimizely CMS 13 Content Modeling Skill

## Before coding
- Inspect the existing page/block models and their base classes, attributes, namespaces, and views.
- Confirm the project's CMS 13 package versions and follow patterns already used in the solution.
- Consult current CMS 13 docs. Do not copy CMS 11/12 snippets without validating compatibility.

## Model and rendering workflow
1. Clarify whether the requested content is a page, reusable block, property, or presentation-only component.
2. Add or update the content model using supported CMS 13 types and attributes.
3. Add editor-facing names/help text and sensible defaults where supported.
4. Add the Razor view or rendering component following the repository's conventions.
5. Handle optional properties and missing media/content safely.
6. Avoid hardcoding editorial text that should be content-managed.
7. Build the solution and verify the editor can create/edit the content and the site can render it.
8. Document any required content migration or editor action.

## Content lifecycle
- Distinguish code deployment from content editing/publishing. Adding a new model or rendering behavior generally requires a code deployment; editing existing content values usually does not.
- Do not claim a content change is publicly visible until its publish state, permissions, and delivery/indexing path are verified.

## Official references
- CMS 13 developer overview: https://docs.optimizely.com/cms-13/docs/developer-overview-cms-13
- Create pages and shared blocks: https://docs.optimizely.com/cms-13/docs/create-pages-and-shared-blocks
- CMS 13 class libraries: https://docs.developers.optimizely.com/content-management-system/v13.0.0-CMS/docs/cms-class-libraries
