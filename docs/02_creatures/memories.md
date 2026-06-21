# Memory System
**Description:** Memory formation, decay, and influence on personality for Aetherbourne
**Last Updated:** 2026-06-21
---

## Overview
Memories are the stored records of significant emotional experiences. They are the primary driver of **Personality Drift**.

---

## Memory Formation
A memory is formed when the **Emotional Intensity** of an event exceeds the creature's storage threshold.
```text
MemoryStrength = EmotionalIntensity × DriveWeight
```
*   **DriveWeight:** If the event category matches the creature's **Aethersign Drive**, the memory is 25% stronger.

---

## Memory Decay
All memories decay over time, but at different rates.
```text
CurrentStrength = InitialStrength × e^(-DecayRate × Time)
```
*   **Minor Events:** High DecayRate (fades in days).
*   **Traumatic/Significant Events:** Low DecayRate (may last a lifetime).

---

## Influence on Personality
Memories do not change personality directly; they provide "drift" values that accumulate.
```text
DriftContribution = CurrentStrength × AxisModifier
```

---

## Design Philosophy
*   **Selective Retention:** The brain (simulation) only keeps what matters.
*   **Dynamic History:** As memories decay, their influence on future decisions weakens, but their effect on the *past* personality drift is permanent.
