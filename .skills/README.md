# Optimizely CMS 13 AI Coding-Agent Skills

Custom skill pack for coding agents such as Codex, Claude Code, Cursor, and compatible Agent Skills tools.

## Included skills

- `optimizely-cms13-core` — CMS 13 / .NET 10 core guardrails and workflow.
- `optimizely-graph-csharp` — Optimizely Graph C# SDK, delivery/query patterns, troubleshooting.
- `optimizely-cms-content-modeling` — pages, blocks, properties, Razor rendering.
- `optimizely-cms-api-security` — external integrations, authentication, scopes, and least privilege.

These are community-style custom skills prepared for this request, not official Optimizely-authored files. They point to official documentation and instruct the agent to verify version-specific APIs before generating code.

## Install for Codex

Copy the skill folders into your repository's `.agents/skills/` directory (or the global skills directory supported by your Codex installation). For a project-local setup:

```bash
mkdir -p .agents/skills
# Copy the four skill folders into .agents/skills/
```

Expected layout:

```text
your-repo/
  .agents/
    skills/
      optimizely-cms13-core/SKILL.md
      optimizely-graph-csharp/SKILL.md
      optimizely-cms-content-modeling/SKILL.md
      optimizely-cms-api-security/SKILL.md
```

## Install for Claude Code

Copy the skill folders into `.claude/skills/` inside the project, or into `~/.claude/skills/` for user-level availability.

```bash
mkdir -p .claude/skills
# Copy the four skill folders into .claude/skills/
```

## Use

Ask your agent, for example:
- "Use the optimizely-cms13-core skill to inspect this repository and verify the CMS/.NET versions."
- "Use optimizely-graph-csharp to implement a Graph query for the existing content type."
- "Use optimizely-cms-api-security to review this Metafy integration for least privilege."

## Official references

- CMS 13 developer overview: https://docs.optimizely.com/cms-13/docs/developer-overview-cms-13
- Graph C# SDK quick start: https://docs.optimizely.com/cms-13/docs/quick-start
- Graph C# SDK overview: https://docs.developers.optimizely.com/content-management-system/v13.0.0-CMS/docs/overview-of-c-sharp-sdk
