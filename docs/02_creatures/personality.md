# Personality System
**Description:** Personality development, aging, emotional domains, and emergent behavioral systems for Aetherbourne creatures
**Last Updated:** 2026-06-21
---

## Overview
Personality in Aetherbourne is a layered, developmental architecture. It represents a creature's long-term behavioral tendencies that emerge from a combination of celestial predispositions (**Aethersigns**), genetic inheritance, and lived experience.

---

## The Aethersign Layer (Predispositions)
Every creature is born under an **Aethersign**, a celestial imprint that provides "discreet influence" on their psychological development.

*   **State (Foundational Nature):** Defines **Domain Affinity**, providing a -10% reduction in Personality Resistance for traits within specific domains.
*   **Modality (Developmental Pace):** Directly modifies the **Personality Resistance** (PR) stat (e.g., Catalyst -20% PR).
*   **Drive (Memory Weighting):** Determines which categories of experiences produce the strongest **Personality Drift** (+25% weight).

---

## Personality Development by Age
As creatures age, new psychological domains "unlock" and mature. While a domain becomes active at a certain age, its **foundations** are laid by earlier domains.

| Age Stage | Active Domains | Foundation For... |
| :--- | :--- | :--- |
| **Infant** | Temperament | Emotional Regulation |
| **Toddler** | Socialization | Interaction & Morals |
| **Child** | Cognition, Emotional | Purpose |
| **Teenager** | Identity, Interaction | Perspective |
| **Young Adult** | Purpose, Morals | Legacy |
| **Adult** | Perspective | - |
| **Elder** | Legacy | - |

---

## Personality Domains
Each domain contains two unique axes ranging from **-100 to 100**.

### 1. Temperament (Infant)
*Innate biological responses to stimuli.*
#### Sensitivity
`Dull (-100) ↔ Acute (+100)`
#### Baseline Mood
`Somber (-100) ↔ Cheerful (+100)`

### 2. Socialization (Toddler)
*Early attachment and group-entry behaviors. Bridges the gap to adult Morals.*
#### Attachment Style
`Avoidant (-100) ↔ Secure (+100)`
#### Trust Baseline
`Skeptical (-100) ↔ Trusting (+100)`

*Note: High Trust Baseline and Secure Attachment form the "Proto-Morals" that govern early social cooperation before the full Morals domain unlocks.*

### 3. Cognition (Child)
#### Inquiry
`Passive (-100) ↔ Inquisitive (+100)`
#### Mental Focus
`Fluid (-100) ↔ Concentrated (+100)`

### 4. Identity (Teenager)
#### Conformity
`Rebellious (-100) ↔ Compliant (+100)`
#### Ego
`Modest (-100) ↔ Vain (+100)`

### 5. Emotional (Child+)
#### Impulse Control
`Volatile (-100) ↔ Restrained (+100)`
#### Resilience
`Fragile (-100) ↔ Robust (+100)`

### 6. Interaction (Teenager+)
#### Social Energy
`Solitary (-100) ↔ Gregarious (+100)`
#### Influence Strategy
`Submissive (-100) ↔ Dominant (+100)`

### 7. Purpose (Young Adult+)
#### Ambition
`Content (-100) ↔ Driven (+100)`
#### Grit
`Fickle (-100) ↔ Tenacious (+100)`

### 8. Morals (Young Adult+)
*Internalized ethical framework. Influenced by early Socialization.*
#### Empathy
`Callous (-100) ↔ Empathetic (+100)`
#### Integrity
`Opportunistic (-100) ↔ Principled (+100)`

### 9. Perspective (Adult+)
#### Adaptability
`Rigid (-100) ↔ Flexible (+100)`
#### Horizon
`Parochial (-100) ↔ Universal (+100)`

### 10. Legacy (Elder)
#### Preservation
`Transient (-100) ↔ Ancestral (+100)`
#### Mentorship
`Self-Centered (-100) ↔ Altruistic (+100)`

---

## Personality Drift & Resistance
Personality "drifts" based on the accumulation of memories, filtered through the creature's Aethersign and current age.

### Personality Resistance (PR)
**Personality Resistance** represents the "inertia" of a creature's character.
*   **Base Resistance:** Starts at 10.0 for Infants.
*   **Age Scaling:** PR increases by +5.0 per Age Stage.
*   **Modality Modifier:** Applied to the total PR (e.g., Anchor = ×1.2).
*   **Domain Affinity:** If a trait belongs to a domain affined to the creature's **State**, PR for that trait is ×0.9.

### Personality Drift Formula
```text
PersonalityChange = (MemoryStrength × EmotionalWeight × AxisModifier × DriveWeight) / PR
```

---

## Design Philosophy
*   **Slow Emergence:** Personality is a trailing indicator of a life lived.
*   **Layered Complexity:** Adult behavior is the result of infant temperament being filtered through years of socialization and cognition.
*   **Stability with Age:** The older a creature gets, the more "set in its ways" it becomes.

## Implementation / Notes
*   **Storage:** Store Aethersign (State, Modality, Drive) permanently in the creature's data block.
*   **Processing:** Run personality drift calculations during the "Sleep" or "Long Rest" state.
