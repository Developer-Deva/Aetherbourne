# Cosmology & Aethersigns

**Description**: Celestial influences, Aethersigns, and personality predispositions for creatures in Aetherbourne
**Last Updated**: 2026-06-21

---

# Overview

The Cosmology System defines how celestial cycles influence creature development.

Every creature is born under an Aethersign determined by the current Phase, Selene's phase, and Karael's phase at the moment of birth.

Aethersigns do not determine behavior directly. Instead, they create developmental predispositions that influence personality formation throughout life.

This system integrates with the Personality System by affecting:

- Initial personality tendencies
- Personality resistance
- Memory weighting
- Domain affinities

Personality ultimately emerges through experiences, memories, relationships, and environmental factors.

---

# Design Philosophy

- Astrology should influence development without determining destiny.
- Two creatures with the same Aethersign should still develop differently.
- Celestial influences should interact naturally with personality drift.
- Aethersigns should complement existing personality systems rather than replace them.
- Long-term behavior should emerge from experience rather than fixed traits.

---

# Core Concepts

## Aethersigns

An Aethersign consists of three components:

1. State
2. Modality
3. Drive

Example:

Gas Current Discovery

or

Solid Anchor Growth

Together these influences create a creature's astrological predispositions.

---

## State

State is determined by the birth Phase.

State represents a creature's foundational nature and influences which personality domains tend to exert greater influence throughout development.

---

## Modality

Modality is determined by Selene.

Modality influences how readily personality changes throughout life.

Modality primarily affects Personality Resistance.

---

## Drive

Drive is determined by Karael.

Drive influences which experiences produce the strongest personality drift.

Different Drives assign greater weight to different categories of memories.

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

# State Assignment

States are determined by the creature's birth Phase.

| Phase | State |
| --- | --- |
| Brigide | Solid |
| Imbolka | Liquid |
| Floralis | Gas |
| Lithara | Plasma |
| Heliax | Aether |
| Aestium | Solid |
| Mabonel | Liquid |
| Ceresio | Gas |
| Yulith | Plasma |
| Hibernis | Aether |

Each State appears twice during every Span.

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

## Modality Assignment

Modality is determined by Selene's current phase.

| Selene Phase | Modality |
| --- | --- |
| New Moon | Anchor |
| Waxing Crescent | Catalyst |
| First Quarter | Catalyst |
| Waxing Gibbous | Catalyst |
| Full Moon | Anchor |
| Waning Gibbous | Current |
| Last Quarter | Current |
| Waning Crescent | Current |

---

# Drives

Drives determine which experiences exert the greatest influence on personality development.

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

# Drive Assignment

Drive is determined by Karael's orbital position at birth.

Karael's 17-Turn orbit is divided into five celestial regions.

| Orbital Region | Drive |
| --- | --- |
| Region I | Growth |
| Region II | Conflict |
| Region III | Discovery |
| Region IV | Reflection |
| Region V | Renewal |

Because Karael completes its orbit every 17 Turns, Drive distribution shifts continuously throughout the calendar.

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

Aethersign Generation

At birth determine:

Birth Phase
    → State

Selene Phase
    → Modality

Karael Position
    → Drive

Store these values permanently as part of the creature's identity.

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