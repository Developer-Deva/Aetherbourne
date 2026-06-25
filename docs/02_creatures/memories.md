# Memory System
**Description:** Memory formation, decay, and influence on personality for Aetherbourne
**Last Updated:** 2026-06-21

---

## Overview
Memories are the stored records of significant emotional experiences. They are the primary driver of **Personality Drift**.
## Content Coming Soon
This documentation is currently incomplete and still in development.  Please check back for updates.

---

## Memory Formation
A memory is formed when the **Emotional Intensity** of an event exceeds the creature's storage threshold.
```text
MemoryStrength = EmotionalIntensity × DriveWeight
```
*   **DriveWeight:** If the event category matches the creature's **Aethersign Drive**, the memory is 25% stronger.

---

## Memory Taxonomy
*   **Episodic:** Records of specific events (e.g., "The time I found the cave").
*   **Semantic:** Generalized knowledge derived from events (e.g., "Caves are dangerous").
*   **Procedural:** Skills and habits learned through repetition (e.g., "How to forge iron").

---

## Memory Decay & Persistence
All memories decay over time, but at different rates.
```text
CurrentStrength = InitialStrength × e^(-DecayRate × Time)
```
*   **Minor Events:** High DecayRate (fades in days).
*   **Traumatic/Significant Events:** Low DecayRate (may last a lifetime).

---

## Memory Retrieval & Association
Memories are not static; they are retrieved when the creature encounters similar stimuli.
*   **Association:** Encountering a "Snake" may trigger a memory of a "Snake Bite," spiking current *Fear* levels.
*   **Recall:** High *Cognition* traits increase the accuracy and speed of memory retrieval.

---

## Influence on Personality
Memories provide "drift" values that accumulate over time.
`DriftContribution = CurrentStrength × AxisModifier`

---

## Design Philosophy
*   **Selective Retention:** The simulation only keeps what matters.
*   **Dynamic History:** As memories decay, their influence on future decisions weakens, but their effect on the *past* personality drift is permanent.
