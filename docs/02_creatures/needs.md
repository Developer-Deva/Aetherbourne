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
*   **Urgency (0-100):** How much the need is currently neglected.
*   **BasePriority:** Survival needs have higher multipliers (3.5+) than psychological ones (1.0).
*   **PersonalityWeight:** Modified by the creature's traits (e.g., *Ambitious* creatures prioritize *Purpose*).

---

## The Need Hierarchy

| Need | BasePriority | Behavioral Manifestation |
| :--- | :--- | :--- |
| **Health** | 5.0 | Avoidance of hazards, seeking medicine/rest. |
| **Thirst** | 4.0 | Searching for water sources, migration to rivers. |
| **Hunger** | 3.5 | Foraging, hunting, or trading for food. |
| **Energy** | 3.0 | Sleeping, resting, or reducing labor intensity. |
| **Safety** | 2.5 | Seeking shelter, grouping with others, building defenses. |
| **Belonging** | 1.5 | Socializing, gift-giving, participating in rituals. |
| **Curiosity** | 1.2 | Exploring unknown tiles, inspecting new objects. |
| **Purpose** | 1.0 | Pursuing long-term goals, training skills, building legacy. |

---

## Need States
Urgency levels are categorized into states that trigger specific behavioral AI modes:
*   **Satiated (0-20):** Need is satisfied; creature focuses on low-priority psychological goals.
*   **Stable (21-50):** Need is present but not pressing.
*   **Pressing (51-80):** Creature begins actively searching for solutions.
*   **Critical (81-100):** Creature enters "Survival Mode," abandoning all non-essential goals to satisfy the need.

---

## Design Philosophy
*   **Biological Realism:** Survival needs are mathematically "louder" than psychological ones.
*   **Emergent Motivation:** Behavior emerges from the competition between these pressures.
