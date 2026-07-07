# Stats System — Capability Lattice (Core → Advanced → Emergent)

**Last Updated:** 2026-06-26

## Overview
The **Stats System** defines a creature’s fundamental capabilities.

- Stats **do not directly determine behavior**.
- Instead, stats determine what a creature is capable of:
  - perceiving
  - learning
  - enduring
  - understanding
  - accomplishing

The system is intentionally layered:

**Core Stats → Advanced Stats → Emergent Stats → Decision Making → Experience → Memory → Personality Development**

This allows creatures with similar genetics to develop into distinct individuals through experience.

## Design Philosophy
The system exists to model **capability rather than personality**.

Personality is shaped primarily by:

- experience
- memory
- relationships
- emotion

Stats influence *how experiences occur*:

- stronger creatures experience the world differently
- observant creatures notice opportunities others miss
- determined creatures persist through hardships

## Layer Structure
- **Core Stats** = raw capabilities (stored)
- **Advanced Stats** = broad competencies (derived dynamically)
- **Emergent Stats** = behavioral capacities (second-order derived)

## Stat Lattice Constraint
Designed as a balanced lattice:

- Every **Core Stat contributes to exactly two Advanced Stats**.
- Every **Advanced Stat contributes to exactly two Emergent Stats**.

Guarantees:

- no dead-end stat
- no stat dominates
- natural rippling improvements
- balanced emergent behavior

## Core Stats (Stored)
Core Stats are the only permanent creature attributes directly stored and may be influenced by:

- genetics
- species
- development
- training
- aging
- injury
- disease

### Strength
Represents force production and physical power.

Primary uses:

- carrying
- mining
- construction
- melee combat
- grappling
- throwing
- resource extraction

Answers:

- how much force can this creature generate?
- how much weight can it move?

### Stamina
Represents physical endurance and energy sustainability.

Primary uses:

- travel
- labor
- hunting
- recovery
- fatigue resistance

Answers:

- how long can the creature keep performing?
- how quickly does it tire?

### Dexterity
Represents coordination, precision, and fine motor control.

Primary uses:

- crafting
- harvesting
- tool use
- accuracy
- dodging
- manipulation

Answers:

- how precisely can it act?
- how well can it control movement?

### Perception
Represents sensory awareness.

Primary uses:

- detection
- tracking
- observation
- threat recognition
- resource spotting
- environmental awareness

Important distinction:

- perception does not guarantee awareness
- perception system determines what can be sensed; a separate system determines whether it’s noticed

Answers:

- what can this creature notice?
- how much information can it acquire?

### Willpower
Represents mental persistence and self-control.

Primary uses:

- goal commitment
- emotional regulation
- fear resistance
- pain tolerance
- long-term planning

Answers:

- how strongly can the creature maintain intention?
- how resistant is it to giving up?

## Advanced Stats (Derived)
Advanced Stats are derived dynamically from Core Stats and are not stored.

### Formulas
- **Endurance** = (Strength + Stamina) / 2
- **Prowess** = (Strength + Dexterity) / 2
- **Finesse** = (Dexterity + Perception) / 2
- **Conviction** = (Willpower + Perception) / 2
- **Vitality** = (Stamina + Willpower) / 2

### Meanings & Uses
- **Endurance:** sustained physical performance
  - long travel, labor, hunting, combat duration, physical persistence
- **Prowess:** physical effectiveness
  - combat, athletics, physical problem solving
- **Finesse:** precision + awareness
  - crafting, gathering, tracking, inspection, tool mastery
- **Conviction:** mental clarity + direction
  - leadership, decision-making, goal maintenance, social influence
- **Vitality:** resilience + recovery
  - recovery, disease resistance, survival, stress tolerance

## Emergent Stats (Second-order Derived)
Emergent Stats are second-order derived values. They should generally remain hidden from the player.

They are:

- not skills
- not personality traits
- behavioral capacities that emerge from interactions of broader competencies

### Formulas
- **Focus** = (Endurance + Finesse) / 2
- **Insight** = (Prowess + Conviction) / 2
- **Creativity** = (Finesse + Vitality) / 2
- **Fortitude** = (Endurance + Conviction) / 2
- **Momentum** = (Vitality + Prowess) / 2

### Focus
- meaning: persistence + precision
- influences:
  - learning speed
  - task completion
  - skill growth
  - attention maintenance
  - goal persistence

High Focus tends to:

- finish tasks
- become specialists
- lose concentration less often

### Insight
- meaning: capability + judgment
- influences:
  - decision quality
  - pattern recognition
  - tactical reasoning
  - risk assessment
  - opportunity recognition

High Insight tends to:

- recognize useful opportunities
- anticipate danger
- choose effective solutions

### Creativity
- meaning: awareness + adaptability
- influences:
  - exploration
  - improvisation
  - innovation
  - strategy variation
  - discovery

High Creativity tends to:

- experiment frequently
- adapt to change
- develop unusual solutions

### Fortitude
- meaning: physical persistence + mental persistence
- influences:
  - stress tolerance
  - recovery from setbacks
  - emotional resilience
  - long-term persistence

High Fortitude tends to:

- recover from failure
- endure hardship
- maintain commitments

### Momentum
- meaning: energy + capability
- influences:
  - activity frequency
  - goal pursuit
  - exploration
  - work rate
  - initiative

High Momentum tends to:

- act quickly
- pursue goals aggressively
- accomplish more over time

## Relationship to Other Systems (Influence Map)
- **Perception System:** detection quality, observation quality, awareness, attention (perception/finesse/focus/insight)
- **Skill System:** learning speed, growth, ceilings, practice efficiency (dexterity/focus/creativity)
- **Emotion System:** regulation, resilience, recovery (willpower/conviction/fortitude)
- **Decision System:** decision quality, goal persistence, action selection (insight/focus/momentum)
- **Personality System:** stats influence experience → memory → personality drift, but do not directly set personality

## Developmental Loop (Intended)
**Genetics → Stats → Competencies → Behavioral Capacities → Actions → Experiences → Memory → Personality**

## Design Goals
- keep core stats simple
- create meaningful derived competencies
- support emergent behavior
- separate capability from personality
- allow experience to shape identity
- create natural specialization
- produce believable developmental divergence
- support large-scale simulation efficiently

