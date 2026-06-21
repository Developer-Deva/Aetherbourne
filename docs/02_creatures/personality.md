# Personality System

**Description:** Personality development, aging, emotional domains, and emergent behavioral systems for Aetherbourne creatures
**Last Updated:** 2026-06-21

---

## Overview
Personality in Aetherbourne is a layered, developmental architecture. It represents a creature's long-term behavioral tendencies that emerge from a combination of celestial predispositions (**Aethersigns**), genetic inheritance, and lived experience.

## The Aethersign Layer (Predispositions)
Every creature is born under an **Aethersign**, a celestial imprint that provides "discreet influence" on their psychological development. An Aethersign consists of three components: **State**, **Modality**, and **Drive**.

### 1. State (Foundational Nature)
Determined by the birth Phase (e.g., Solid, Liquid, Gas). State defines **Domain Affinity**, providing a -10% reduction in Personality Resistance for traits within specific domains.
*   **Solid:** Affined to *Temperament, Purpose, Legacy*.
*   **Liquid:** Affined to *Socialization, Interaction, Morals*.
*   **Gas:** Affined to *Cognition, Perspective*.
*   **Plasma:** Affined to *Identity, Purpose*.
*   **Aether:** Affined to *Emotional, Morals, Perspective*.

### 2. Modality (Developmental Pace)
Determined by Selene's phase. Modality directly modifies the **Personality Resistance** (PR) stat.
*   **Catalyst:** -20% PR (Learns and changes quickly).
*   **Anchor:** +20% PR (Resistant to change; high consistency).
*   **Current:** PR fluctuates ±15% based on current environmental stability.

### 3. Drive (Memory Weighting)
Determined by Karael's orbital position. Drive determines which types of memories exert the strongest influence on **Personality Drift**.
*   **Growth:** +25% weight to Family and Mentorship memories.
*   **Conflict:** +25% weight to Rivalry and Failure memories.
*   **Discovery:** +25% weight to Exploration and Research memories.
*   **Reflection:** +25% weight to Loss and Beauty memories.
*   **Renewal:** +25% weight to Healing and Migration memories.

## Personality Development by Age
As creatures age, new psychological domains "unlock" and mature. While a domain becomes active at a certain age, it remains active for the rest of the creature's life.

| Age Stage | Active Domains |
| :--- | :--- |
| **Infant** | Temperament |
| **Toddler** | Socialization |
| **Child** | Cognition, Emotional |
| **Teenager** | Identity, Interaction |
| **Young Adult** | Purpose, Morals |
| **Adult** | Perspective |
| **Elder** | Legacy |

## Personality Domains
Each domain contains two unique axes ranging from **-100 to 100**.

### 1. Temperament (Infant)
*Innate biological responses to stimuli.*
#### Sensitivity
`Dull (-100) ↔ Acute (+100)`
Threshold for noticing and reacting to environmental changes or needs.
#### Baseline Mood
`Somber (-100) ↔ Cheerful (+100)`
The default emotional state when no external events are occurring.

### 2. Socialization (Toddler)
*Early attachment and group-entry behaviors.*
#### Attachment Style
`Avoidant (-100) ↔ Secure (+100)`
How the creature reacts to the presence or absence of caregivers/peers.
#### Trust Baseline
`Skeptical (-100) ↔ Trusting (+100)`
The default assumption when meeting a new creature.

### 3. Cognition (Child)
*How the creature processes information and exploration.*
#### Inquiry
`Passive (-100) ↔ Inquisitive (+100)`
The drive to explore unknown tiles or interact with new objects.
#### Mental Focus
`Fluid (-100) ↔ Concentrated (+100)`
Ability to stick to a single task versus being easily distracted by new stimuli.

### 4. Identity (Teenager)
*Formation of the "Self" in relation to the group.*
#### Conformity
`Rebellious (-100) ↔ Compliant (+100)`
Tendency to follow group norms versus seeking unique expression.
#### Ego
`Modest (-100) ↔ Vain (+100)`
How much the creature's own needs and status weigh in decision making.

### 5. Emotional (Child+)
*Developed from Temperament; represents emotional regulation.*
#### Impulse Control
`Volatile (-100) ↔ Restrained (+100)`
The ability to delay an action driven by a high-urgency emotion.
#### Resilience
`Fragile (-100) ↔ Robust (+100)`
How quickly emotional intensity decays back to the Baseline Mood.

### 6. Interaction (Teenager+)
*Developed from Socialization; represents social strategy.*
#### Social Energy
`Solitary (-100) ↔ Gregarious (+100)`
Whether the creature gains or loses "Energy" need when near others.
#### Influence Strategy
`Submissive (-100) ↔ Dominant (+100)`
Preference for following orders versus attempting to lead or assert control.

### 7. Purpose (Young Adult+)
*Developed from Cognition; represents long-term motivation.*
#### Ambition
`Content (-100) ↔ Driven (+100)`
The weight given to "Purpose" and "Fulfillment" needs over biological needs.
#### Grit
`Fickle (-100) ↔ Tenacious (+100)`
Likelihood of abandoning a long-term goal after a "Failure" event.

### 8. Morals (Young Adult+)
*Internalized ethical framework.*
#### Empathy
`Callous (-100) ↔ Empathetic (+100)`
How much a witness's "Emotion" mirrors the "Target's" emotion in an event.
#### Integrity
`Opportunistic (-100) ↔ Principled (+100)`
Willingness to violate "Trust" or "Social Norms" to satisfy an urgent need.

### 9. Perspective (Adult+)
*Developed from Identity; represents worldview.*
#### Adaptability
`Rigid (-100) ↔ Flexible (+100)`
Openness to changing a "Goal" when the "World" state changes.
#### Horizon
`Parochial (-100) ↔ Universal (+100)`
Focus on immediate family/settlement versus the broader species/world.

### 10. Legacy (Elder)
*Developed from Purpose; concern for lasting impact.*
#### Preservation
`Transient (-100) ↔ Ancestral (+100)`
Drive to consume resources now versus leaving them for future generations.
#### Mentorship
`Self-Centered (-100) ↔ Altruistic (+100)`
Tendency to share "Skills" or "Knowledge" with younger creatures.

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
*   **MemoryStrength:** Derived from the Event (0-100).
*   **EmotionalWeight:** How strongly the creature felt during the event.
*   **AxisModifier:** The specific "direction" of the memory.
*   **DriveWeight:** If the memory category matches the creature's **Drive**, this is 1.25; otherwise, it is 1.0.

---

## Design Philosophy
*   **Celestial Foundation:** Aethersigns provide the "flavor" and "speed" of development without forcing a specific outcome.
*   **Slow Emergence:** Personality is a trailing indicator of a life lived, filtered through a celestial lens.
*   **Stability with Age:** The older a creature gets, the more "set in its ways" it becomes (via increasing PR).

---

## Implementation / Notes
*   **Storage:** Store Aethersign (State, Modality, Drive) permanently in the creature's data block.
*   **Processing:** Run personality drift calculations during the "Sleep" or "Long Rest" state.