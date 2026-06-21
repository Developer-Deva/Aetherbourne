# Aetherbourne Documentation Style Guide

**Description:** Formal standards for documentation structure, formatting, and tone
**Last Updated:** 2026-06-21

---

## 1. Document Structure

Every markdown file in the `docs/` directory MUST follow this exact structural sequence:

1.  **H1 Title:** A single `# Title` at the very top.
2.  **Metadata Block:**
    *   `**Description:**` A concise one-sentence summary.
    *   `**Last Updated:**` YYYY-MM-DD format.
3.  **Horizontal Rule:** `---`
4.  **Overview:** An `## Overview` section (H2) explaining the system's purpose.
5.  **Horizontal Rule:** `---`
6.  **Core Content:** H2 sections for major concepts, H3 for subsections.
7.  **Horizontal Rule:** `---` (Before the closing sections)
8.  **Design Philosophy:** A `## Design Philosophy` section (H2) outlining the "Why" behind the system.
9.  **Implementation / Notes:** A `## Implementation / Notes` section (H2) for technical details or future work.

---

## 2. Formatting Standards

### 2.1 Headings
*   Use `##` for primary sections.
*   Use `###` for secondary subsections.
*   Do not use `####` unless absolutely necessary for deep technical nesting.
*   **Consistency Check:** Never use `#` for sections other than the main title.

### 2.2 Lists and Text
*   Use bullet points (`*` or `-`) for lists of properties or features.
*   Keep paragraphs short (2–4 sentences).
*   Use **bold** for key terms and system names (e.g., **Aethersign**, **Planetary Context**).
*   Use `inline code` for technical identifiers, file names, or variable names.

### 2.3 Visual Aids
*   Use code blocks (```` ``` ````) with appropriate language tagging (e.g., `csharp`, `text`, `mermaid`) for data structures or diagrams.
*   Use Markdown tables for mapping stats, properties, or definitions.

---

## 3. Tone and Language

*   **Tense:** Use present tense for describing systems (e.g., "The system manages..." not "The system will manage...").
*   **Voice:** Use a professional, technical, yet accessible tone.
*   **Terminology:** Always use established project terms consistently. Refer to `world.md` for environmental terms and `personality.md` for creature-related terms.

---

## 4. Maintenance

*   Update the **Last Updated** date whenever a file is modified.
*   If a section has no content yet, use the following placeholder:
    ```md
    ## Content Coming Soon
    This documentation is currently in development. Please check back for updates.
    ```

---

## Design Philosophy

This guide ensures that the complex, interconnected systems of Aetherbourne are documented in a way that is predictable, readable, and professional for both developers and collaborators.

## Implementation / Notes

*   This file supersedes `MARKDOWN_GUIDE.md`.
*   All existing documents must be audited against these standards.
