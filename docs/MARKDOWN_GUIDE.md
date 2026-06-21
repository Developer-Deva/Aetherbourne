# Aetherbourne Docs Markdown Guide

This guide defines the standard structure used by all documentation files in `docs/`.
It is based on the document layout and style used in `minerals.md`, `flora.md`, `world.md`, `actions.md`, `emotions.md`, `needs.md`, and `events.md`.

---

## 1. File Header

Every document should begin with a title and metadata block:

```md
# Document Title

**Description:** One-sentence summary of the document purpose
**Last Updated:** 2026-06-21

---
```

Use a single top-level heading (`#`) for the title. The metadata block must include `Description` and `Last Updated`, followed by a horizontal rule.

## 2. Overview

Start with a clear `Overview` section that explains the system, feature, or concept in broad terms.

- Purpose of the system
- What it affects in the game world
- How it interacts with other systems

Example:

```md
# Overview

This system manages ...

---
```

## 3. Structure and Headings

Use the following heading conventions:

- `##` for main sections
- `###` for subsection headings
- `####` only when needed for nested details

Prefer structured sections instead of long paragraphs.
Use bullet lists, numbered lists, and code blocks to keep documentation readable.

## 4. Common Sections

Most docs should include at least these sections where appropriate:

- `Overview`
- `Design Philosophy`
- `System` or `Core Concepts`
- `Categories`, `Properties`, or `Components`
- `Examples`, `Usage`, or `Implementation`
- `Notes`, `Appendix`, or `References`

Example section order:

```md
# Overview

# Design Philosophy

# Core Concepts

## Component A

## Component B

# Implementation Notes
```

## 5. Content Style

- Use short, direct sentences.
- Keep paragraphs concise (2–4 sentences).
- Use consistent terminology across docs.
- Prefer lists for definitions, properties, and rules.
- Use code fences for sample code, enums, or structured data.
- Avoid mixing data definitions with narrative text.

## 6. Formatting Guidelines

- Use `---` after the metadata block and between major conceptual sections when it helps clarity.
- Keep section titles descriptive and consistent.
- Use present tense for system descriptions and rules.
- Use the same vocabulary as the example docs for shared concepts: `Overview`, `Design Philosophy`, `Core Concepts`, `Needs`, `Actions`, `Events`, `Emotions`, `Categories`, `Properties`, `System`.

## 7. Example Template

Use this template as a starting point for new docs:

```md
# Document Title

**Description:** Brief description of the document purpose
**Last Updated:** 2026-06-21

---

# Overview

One or two paragraphs describing the system and its role.

---

# Design Philosophy

* Rule 1
* Rule 2

---

# Core Concepts

## Concept A

Explanation and bullets.

## Concept B

More details and examples.

---

# Implementation / Notes

* Implementation note
* Requirement
```

## 8. Applying the Guide

When editing or creating docs, make sure the file:

- starts with the required metadata block
- uses a title and section structure matching the examples
- uses bullets and code blocks consistently
- is easy to scan and understand

If a doc requires a specialized section, keep the same overall structure and add it after `Core Concepts` or before `Implementation / Notes`.

---

## 9. Example Reference Documents

Use these files as pattern references:

- `docs/01_world/minerals.md`
- `docs/01_world/flora.md`
- `docs/01_world/world.md`
- `docs/02_creatures/actions.md`
- `docs/02_creatures/emotions.md`
- `docs/02_creatures/needs.md`
- `docs/03_simulation/events.md`

These examples show the preferred heading order, metadata usage, and formatting style.

---

## Design Philosophy

This guide exists to make document structure predictable and easy to follow across the `docs/` folder.

## Core Concepts

- Use consistent metadata and headings
- Keep docs concise and scannable
- Prefer lists and code samples for clarity

## Implementation / Notes

* Apply this template whenever creating or refactoring docs in the repository.
