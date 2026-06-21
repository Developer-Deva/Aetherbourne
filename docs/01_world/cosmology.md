# Cosmology & Aethersigns
**Description:** Celestial influences, Aethersigns, and personality predispositions for creatures in Aetherbourne
**Last Updated:** 2026-06-21
---

## Overview
The Cosmology System defines how celestial cycles influence creature development. Every creature is born under an **Aethersign** determined by the current birth Phase, Selene's phase, and Karael's orbital position.

Aethersigns do not determine behavior directly. Instead, they create developmental predispositions that influence personality formation throughout life. This system integrates with the [Personality System](docs/02_creatures/personality.md) by affecting initial tendencies, resistance, and memory weighting.

---

## Design Philosophy
*   **Influence, Not Destiny:** Astrology should guide development without forcing a specific behavioral outcome.
*   **Emergent Diversity:** Two creatures with the same Aethersign will still develop differently based on their unique lived experiences.
*   **Systemic Integration:** Celestial influences interact naturally with personality drift and resistance formulas.

---

## The Three Pillars of the Aethersign
An Aethersign consists of three components: **State**, **Modality**, and **Drive**.

### 1. State (Foundational Nature)
Determined by the **Birth Phase**. It represents a creature's foundational nature and influences which personality domains they are naturally affined to.

| Phase | State | Domain Affinities |
| :--- | :--- | :--- |
| Brigide, Aestium | **Solid** | Temperament, Purpose, Legacy |
| Imbolka, Mabonel | **Liquid** | Socialization, Interaction, Morals |
| Floralis, Ceresio | **Gas** | Cognition, Perspective |
| Lithara, Yulith | **Plasma** | Identity, Purpose |
| Heliax, Hibernis | **Aether** | Emotional, Morals, Perspective |

### 2. Modality (Developmental Pace)
Determined by **Selene's Phase**. It influences how readily a creature's personality changes in response to experiences.

| Selene Phase | Modality | Personality Effect |
| :--- | :--- | :--- |
| New Moon, Full Moon | **Anchor** | Higher Personality Resistance (+20%) |
| Waxing (Crescent, Quarter, Gibbous) | **Catalyst** | Lower Personality Resistance (-20%) |
| Waning (Gibbous, Quarter, Crescent) | **Current** | Situational/Contextual Resistance (±15%) |

### 3. Drive (Memory Weighting)
Determined by **Karael's Orbital Region**. It determines which categories of experiences produce the strongest personality drift.

| Orbital Region | Drive | Memory Affinities |
| :--- | :--- | :--- |
| Region I | **Growth** | Family, Teaching, Community |
| Region II | **Conflict** | Rivalry, Victory, Failure |
| Region III | **Discovery** | Travel, Research, Mystery |
| Region IV | **Reflection** | Beauty, Spirituality, Loss |
| Region V | **Renewal** | Migration, Healing, New Beginnings |

---

## Implementation Notes
*   **Generation:** At birth, the simulation captures the Phase, Selene phase, and Karael position to lock the Aethersign.
*   **Integration:** These values are passed to the `PersonalitySystem` to initialize the creature's `PersonalityResistance` and `MemoryWeight` multipliers.
*   **Persistence:** The Aethersign is a permanent part of the creature's identity and does not change, even if the creature moves to a different region or world.
