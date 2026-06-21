# Needs System
**Description:** Biological and psychological drivers for creature behavior in Aetherbourne
**Last Updated:** 2026-06-21
---

## Overview
Needs are the fundamental drivers of all behavior. They create "pressure" that the creature seeks to alleviate through actions.

---

## Need Urgency & Weighting
The "Decision Pressure" for any need is calculated as:
```text
Pressure = (Urgency × BasePriority) × PersonalityWeight
```
*   **Urgency (0-100):** How much the need is currently neglected (e.g., 100 = starving).
*   **BasePriority:** A fixed multiplier based on the biological hierarchy (see below).
*   **PersonalityWeight:** Modified by the creature's traits (e.g., a *Driven* creature gives more weight to *Purpose*).

---

## The Priority Hierarchy (BasePriority)
This hierarchy ensures that survival needs take precedence when they become critical, without making them absolute "overrides" at low urgency levels.

| Need | BasePriority | Type |
| :--- | :--- | :--- |
| **Health** | 5.0 | Survival |
| **Thirst** | 4.0 | Survival |
| **Hunger** | 3.5 | Survival |
| **Energy** | 3.0 | Maintenance |
| **Safety** | 2.5 | Maintenance |
| **Belonging** | 1.5 | Psychological |
| **Curiosity** | 1.2 | Psychological |
| **Purpose** | 1.0 | Psychological |

**Realism Fix:** A creature with **Hunger (90)** and **Curiosity (100)** will calculate:
*   Hunger Pressure: 90 × 3.5 = **315**
*   Curiosity Pressure: 100 × 1.2 = **120**
*   **Result:** The creature eats first, as the biological pressure outweighs the psychological drive.

---

## Need Decay & Recovery
*   **Decay:** Needs increase (urgency rises) over time or through specific actions (e.g., Labor increases Energy need).
*   **Recovery:** Needs are satisfied through specific interactions (e.g., Eating, Sleeping, Socializing).

---

## Design Philosophy
*   **Biological Realism:** Survival needs are mathematically "louder" than psychological needs.
*   **Emergent Motivation:** Behavior emerges from the competition between these pressures, rather than a hard-coded script.
