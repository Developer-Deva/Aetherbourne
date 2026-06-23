# Emotion System
**Description:** Emotional state, processing, and influence systems for Aetherbourne
**Last Updated:** 2026-06-21
---
## Overview
Emotions are the subjective bridge between objective events and lasting memories. They determine how a creature perceives and reacts to the world.
## Content Coming Soon
This documentation is currently in development. Please check back for updates.
---
## The Emotional Pipeline
`Need → Goal → Action → Event → Interpretation → Emotion → Memory`
---
## Emotional Intensity
```text
EI = EventSeverity × PersonalRelevance × PersonalityAmplifier
```
*   **EventSeverity:** Objective impact (0-100).
*   **PersonalRelevance:** Impact on the creature's current state.
*   **PersonalityAmplifier:** Modified by *Sensitivity* and *Emotional Reactivity*.
---
## Emotional Taxonomy
Emotions are categorized by their influence on behavioral AI.
---
## Subjective Interpretation
The same event produces different emotions based on the creature's perspective.
### Example
*   **Victor:** Pride / Joy.
*   **Loser:** Shame / Anger.
*   **Witness:** Admiration / Fear (influenced by *Empathy* trait).
---
## Emotion → Memory Transition
Not every emotion becomes a memory. Only those that exceed a certain threshold are stored.
```text
MemoryStrength = EI × DurationFactor
```
If `MemoryStrength > MemoryThreshold`, a new memory is created.
---
## Design Philosophy
*   **Subjectivity:** Events are facts; emotions are interpretations.
*   **Volatility:** Emotions are short-lived but drive long-term character change via memories.
