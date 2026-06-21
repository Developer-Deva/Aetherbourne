# Emotion System
**Description:** Emotional state, processing, and influence systems for Aetherbourne
**Last Updated:** 2026-06-21
---

## Overview
Emotions are the subjective bridge between objective events and lasting memories. They determine how a creature perceives and reacts to the world.

---

## The Emotional Pipeline
The relationship between systems is:
```text
Need → Goal → Action → Event → Interpretation → Emotion → Memory → Personality Drift
```

---

## Emotional Intensity
When an event is perceived, it triggers an **Emotional Intensity** (EI) value.
```text
EI = EventSeverity × PersonalRelevance × PersonalityAmplifier
```
*   **EventSeverity:** Objective impact of the event (0-100).
*   **PersonalRelevance:** How much the event affects the creature's current Needs, Relationships, or Goals.
*   **PersonalityAmplifier:** Modified by the creature's *Sensitivity* and *Emotional Reactivity* traits.

---

## Subjective Interpretation
The same event produces different emotions based on the creature's perspective.
*   **Victor:** Pride / Joy
*   **Loser:** Shame / Anger
*   **Witness:** Admiration / Fear (influenced by *Empathy* trait)

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
*   **Volatility:** Emotions are short-lived but have long-term consequences via memories.
