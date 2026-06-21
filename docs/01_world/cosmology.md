# Cosmology & Aethersigns

**Description**: Celestial influences, Aethersigns, and personality predispositions for creatures in Aetherbourne
**Last Updated**: 2026-06-21

---

# Overview

The Cosmology System defines how celestial cycles influence creature development.

Every creature is born under an Aethersign determined by the current Phase, Selene's phase, and Karael's phase at the moment of birth.

Aethersigns do not determine behavior directly. Instead, they create developmental predispositions that influence personality formation throughout life. This system integrates with the [Personality System](docs/02_creatures/personality.md) by affecting initial tendencies, resistance, and memory weighting.

This system integrates with the Personality System by affecting:

- Initial personality tendencies
- Personality resistance
- Memory weighting
- Domain affinities

Personality ultimately emerges through experiences, memories, relationships, and environmental factors.

---

## Design Philosophy
*   **Influence, Not Destiny:** Astrology should guide development without forcing a specific behavioral outcome.
*   **Emergent Diversity:** Two creatures with the same Aethersign will still develop differently based on their unique lived experiences.
*   **Systemic Integration:** Celestial influences interact naturally with personality drift and resistance formulas.

---

# Core Concepts

## The Three Pillars of the Aethersign
An Aethersign consists of three components: **State**, **Modality**, and **Drive**.

Together these influences create a creature's astrological predispositions.

---

# 1. State (Foundational Nature)
Determined by the **Birth Phase**. It represents a creature's foundational nature and influences which personality domains they are naturally affined to.

| Phase | State | Domain Affinities |
| :--- | :--- | :--- |
| Brigide, Aestium | **Solid** | Temperament, Purpose, Legacy |
| Imbolka, Mabonel | **Liquid** | Socialization, Interaction, Morals |
| Floralis, Ceresio | **Gas** | Cognition, Perspective |
| Lithara, Yulith | **Plasma** | Identity, Purpose |
| Heliax, Hibernis | **Aether** | Emotional, Morals, Perspective |

Each State appears twice during every Span.

---

# States

## Solid

Associated Concepts:

- Stability
- Structure
- Reliability
- Endurance

Domain Affinities:

- Temperament
- Purpose
- Legacy

---

## Liquid

Associated Concepts:

- Adaptation
- Connection
- Empathy
- Cooperation

Domain Affinities:

- Socialization
- Interaction
- Morals

---

## Gas

Associated Concepts:

- Curiosity
- Exploration
- Knowledge
- Possibility

Domain Affinities:

- Cognition
- Perspective

---

## Plasma

Associated Concepts:

- Action
- Ambition
- Transformation
- Expression

Domain Affinities:

- Identity
- Purpose

---

## Aether

Associated Concepts:

- Reflection
- Meaning
- Consciousness
- Spirituality

Domain Affinities:

- Emotional
- Morals
- Perspective

---
# 2. Modality (Developmental Pace)

Modality is determined by Selene.

Modality influences how readily personality changes throughout life.

Modality primarily affects Personality Resistance.

Determined by **Selene's Phase**. It influences how readily a creature's personality changes in response to experiences.

| Selene Phase | Modality | Personality Effect |
| :--- | :--- | :--- |
| New Moon, Full Moon | **Anchor** | Higher Personality Resistance (+20%) |
| Waxing (Crescent, Quarter, Gibbous) | **Catalyst** | Lower Personality Resistance (-20%) |
| Waning (Gibbous, Quarter, Crescent) | **Current** | Situational/Contextual Resistance (±15%) |
---

# Modalities

Modalities describe how a creature responds to change and development.

## Catalyst

Characteristics:

- Initiates change
- Learns quickly
- Adapts rapidly

Personality Effect:

Lower Personality Resistance

---

## Anchor

Characteristics:

- Maintains stability
- Resists change
- Preserves consistency

Personality Effect:

Higher Personality Resistance

---

## Current

Characteristics:

- Adapts to circumstances
- Balances stability and change
- Responds to context

Personality Effect:

Situational Personality Resistance

---

# 3. Drive (Memory Weighting)

Drives determine which experiences exert the greatest influence on personality development.

Drive is determined by Karael.

Drive influences which experiences produce the strongest personality drift.

Different Drives assign greater weight to different categories of memories.

Determined by **Karael's Orbital Region**. It determines which categories of experiences produce the strongest personality drift.

| Orbital Region | Drive | Memory Affinities |
| :--- | :--- | :--- |
| Region I | **Growth** | Family, Teaching, Community |
| Region II | **Conflict** | Rivalry, Victory, Failure |
| Region III | **Discovery** | Travel, Research, Mystery |
| Region IV | **Reflection** | Beauty, Spirituality, Loss |
| Region V | **Renewal** | Migration, Healing, New Beginnings |

Drive is determined by Karael's orbital position at birth.

Karael's 17-Turn orbit is divided into five celestial regions.


Because Karael completes its orbit every 17 Turns, Drive distribution shifts continuously throughout the calendar.

## Growth

Values:

- Learning
- Improvement
- Mentorship

Memory Affinities:

- Family
- Teaching
- Community

---

## Conflict

Values:

- Competition
- Challenge
- Achievement

Memory Affinities:

- Rivalry
- Victory
- Failure

---

## Discovery

Values:

- Exploration
- Curiosity
- Knowledge

Memory Affinities:

- Travel
- Research
- Mystery

---

## Reflection

Values:

- Understanding
- Wisdom
- Meaning

Memory Affinities:

- Beauty
- Spirituality
- Loss

---

## Renewal

Values:

- Adaptation
- Recovery
- Reinvention

Memory Affinities:

- Migration
- Healing
- New Beginnings

---

# Personality Integration

Aethersigns influence personality through three mechanisms.

## Domain Affinity

State influences which personality domains naturally exert greater influence throughout development.

## Personality Resistance

Modality influences how easily personality changes in response to experiences.

## Memory Weighting

Drive influences which memories produce stronger personality drift.

---

# Development Flow

Birth
    ↓
Aethersign
    ↓
Initial Tendencies
    ↓
Experiences
    ↓
Memories
    ↓
Personality Drift
    ↓
Personality Development

Aethersigns influence predispositions.

Life experiences shape the individual.

---

# Implementation / Notes

*   **Generation:** At birth, the simulation captures the Phase, Selene phase, and Karael position to lock the Aethersign.
*   **Integration:** These values are passed to the `PersonalitySystem` to initialize the creature's `PersonalityResistance` and `MemoryWeight` multipliers.
*   **Persistence:** The Aethersign is a permanent part of the creature's identity and does not change, even if the creature moves to a different region or world.

---

# Personality Modifiers

Aethersigns should influence:

- Initial personality values
- Personality Resistance
- Memory weighting calculations
- Domain affinity calculations

Aethersigns should never directly determine:

- Actions
- Careers
- Relationships
- Beliefs
- Goals

These outcomes should emerge naturally through simulation.

---

# Future Expansion

Potential future systems:

- Cultural astrology traditions
- Religious interpretations
- Compatibility systems
- Astrological events
- Celestial festivals
- Rare alignment effects