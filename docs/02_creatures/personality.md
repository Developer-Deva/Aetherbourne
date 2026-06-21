# Personality System
**Description:** Personality development, aging, emotional domains, and emergent behavioral systems for Aetherbourne creatures
**Last Updated:** 2026-06-21
---

## Overview
Personality in Aetherbourne is not a static set of stats but a layered, developmental architecture. It represents a creature's long-term behavioral tendencies that emerge from genetics and are refined by experience.

---

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

### Domain Evolution Tree
The architecture follows a branching path where early traits form the foundation for complex adult behaviors.
```text
Temperament (Innate) → Emotional (Regulated)
Socialization (Bonding) → Interaction (Influence)
Cognition (Understanding) → Purpose (Direction) → Legacy (Impact)
Identity (Self) → Perspective (Worldview)
Morals (Values) — Independent but influenced by Socialization
```

---

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

---

## Personality Drift & Resistance
Personality never changes instantly. It "drifts" based on the accumulation of memories.

### Personality Resistance
**Personality Resistance** is the "inertia" of a creature's character. It represents how difficult it is to change an existing trait.
*   **Base Resistance:** Starts at 10.0 for Infants.
*   **Age Scaling:** Resistance increases by +5.0 per Age Stage.
*   **Domain Depth:** Traits in earlier domains (Temperament) have +10.0 additional resistance compared to later domains (Legacy).

### Personality Drift Formula
```text
PersonalityChange = (MemoryStrength × EmotionalWeight × AxisModifier) / (PersonalityResistance × FrequencyFactor)
```
*   **MemoryStrength:** Derived from the Event (0-100).
*   **EmotionalWeight:** How strongly the creature felt during the event.
*   **AxisModifier:** The specific "direction" of the memory (e.g., a Betrayal has a -5.0 modifier on Trust Baseline).
*   **FrequencyFactor:** A multiplier that increases if the same type of event happens repeatedly in a short time.

---

## Design Philosophy
*   **Slow Emergence:** Personality is a trailing indicator of a life lived, not a leading cause of every action.
*   **Layered Complexity:** Adult behavior is the result of infant temperament being filtered through years of socialization and cognition.
*   **Stability with Age:** The older a creature gets, the more "set in its ways" it becomes (via increasing Resistance).

## Implementation / Notes
*   **Storage:** Store personality as a `float[-100, 100]` for each axis.
*   **Inheritance:** Infants inherit a randomized ±10% of their parents' Temperament and Socialization axes.
*   **Drift Processing:** Run personality drift calculations during the "Sleep" or "Long Rest" state to simulate psychological consolidation.
