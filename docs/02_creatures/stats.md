# Architecture Specification: The Stats Lattice

## 1. Design Philosophy

The Stat Lattice represents **Nature**—the genetic ceiling of a creature. It defines the range of biological and mental limits.

* **Stats** are the "Hardware." They determine potential.
* **Skills** are the "Software." They determine efficiency and application.
* **The Golden Rule:** Skills **do not** modify Stats. Modifying stats via skills creates power creep and ruins archetype diversity. Instead, Stats and Skills converge during the **Capability Calculation** (see Section 5).

## 2. The Stat Hierarchy

### Base Stats (1–10)

*Raw genetic traits.*

 1. **Strength:** Force, lifting, breaking, grappling.
 2. **Stamina:** Fatigue resistance, physical recovery.
 3. **Dexterity:** Agility, fine motor control, stealth.
 4. **Perception:** Awareness, tracking, spotting.
 5. **Willpower:** Discipline, fear resistance, concentration.

### Advanced Stats (1–10)

*Blended specialties derived from Base stats.*

 1. **Endurance** (Str + Sta): Sustained physical effort.
 2. **Prowess** (Str + Dex): Skilled physical execution.
 3. **Finesse** (Dex + Per): Precision and timing.
 4. **Insight** (Per + Wil): Pattern recognition and reading intent.
 5. **Resolve** (Wil + Sta): Persistence under strain.

### Emergent Stats (1–10)

*Outcome-based gameplay capacities derived from Advanced stats.*

 1. **Creativity** (Prowess + Finesse + Insight): Invention and improvisation.
 2. **Focus** (Finesse + Insight + Resolve): Concentration and clean execution.
 3. **Wisdom** (Insight + Resolve + Endurance): Judgment and calm.
 4. **Momentum** (Endurance + Prowess + Resolve): Action flow and pressure.
 5. **Vitality** (Endurance + Finesse + Prowess): Resilience and survival.

## 3. Calculation Formulas

### A. Advanced Stat Logic

$$
\text{Advanced}=\frac{A+B}{2}+S
$$

### B. Emergent Stat Logic

$$
\text{Emergent}=\frac{A+B+C}{3}+S
$$

* **S (Synergy Bonus):** +0 (Standard), +1 (Strong), +2 (Rare/Exceptional).

## 4. Implementation: Rust Struct

Use this structure for your ECS (Entity Component System) to ensure cache locality and FFI compatibility.

```rust
#[repr(C)]
#[derive(Debug, Clone, Copy, PartialEq)]
pub struct StatLattice {
    // 0=Str, 1=Sta, 2=Dex, 3=Per, 4=Wil
    pub base: [u8; 5],

    // 0=End, 1=Pro, 2=Fin, 3=Ins, 4=Res
    pub advanced: [u8; 5],

    // 0=Cre, 1=Foc, 2=Wis, 3=Mom, 4=Vit
    pub emergent: [u8; 5],

    // Set true when base stats change; triggers recalc.
    pub is_dirty: bool,
}

impl StatLattice {
    pub fn refresh(&mut self) {
        if !self.is_dirty { return; }

        // Recalculate Advanced (Example)
        self.advanced[0] = (self.base[0] + self.base[1]) / 2; // Endurance
        // ... (Repeat for all 5)

        // Recalculate Emergent (Example)
        self.emergent[0] = (self.advanced[1] + self.advanced[2] + self.advanced[3]) / 3; // Creativity
        // ... (Repeat for all 5)

        self.is_dirty = false;
    }
}

```

## 5. System Integration: The Capability Model

This is how Stats interact with the rest of the simulation. When an agent attempts an action (e.g., "Hunt"), the system calculates their success probability by merging **Stats** (Potential) with **Skills** (Efficiency).

### Capability Formula

$$
\text{Capability}=(\text{Stat}×w_{1})+(\text{Skill}×w_{2})+\text{Environmental Modifier}
$$

* **Stat ($w_{1}$):** The constant raw material (e.g., *Prowess* for an attack).
* **Skill ($w_{2}$):** The multiplier representing training (e.g., *Archery Skill* for a hunt).
* **EnvironmentModifier:** External factors (e.g., weather, terrain).
**Why this prevents bloat:**
* **Growth:** An agent can increase their *Capability* through Skill growth (Nurture) without altering their genetic *Stat* (Nature).
* **Decay:** If an agent is injured, their *Stat* drops. Their *Skill* remains high, but the *Capability* outcome is reduced proportionally to the injury.

## 6. Design Rules

 1. **Immutability:** Emergent stats never loop back into Base stats.
 2. **Integer Math:** Always use integer division to ensure 100% deterministic results across simulation runs.
 3. **Dirty-Flag Pattern:** Never recalculate on every tick. Only recalculate when is_dirty == true (e.g., after an event changes a base stat).

---

## Canonical Consolidation Notes

Material from the previous staged stats planning note was merged here, making this file the canonical home for the system. During implementation, prefer the contracts and terminology in this file over deleted staging notes.

## Merged Legacy Planning Content

## Stats System — Capability Lattice (Core → Advanced → Emergent)

**Last Updated:** 2026-06-26

### Overview
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

### Design Philosophy
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

### Layer Structure
- **Core Stats** = raw capabilities (stored)
- **Advanced Stats** = broad competencies (derived dynamically)
- **Emergent Stats** = behavioral capacities (second-order derived)

### Stat Lattice Constraint
Designed as a balanced lattice:

- Every **Core Stat contributes to exactly two Advanced Stats**.
- Every **Advanced Stat contributes to exactly two Emergent Stats**.

Guarantees:

- no dead-end stat
- no stat dominates
- natural rippling improvements
- balanced emergent behavior

### Core Stats (Stored)
Core Stats are the only permanent creature attributes directly stored and may be influenced by:

- genetics
- species
- development
- training
- aging
- injury
- disease

#### Strength
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

#### Stamina
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

#### Dexterity
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

#### Perception
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

#### Willpower
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

### Advanced Stats (Derived)
Advanced Stats are derived dynamically from Core Stats and are not stored.

#### Formulas
- **Endurance** = (Strength + Stamina) / 2
- **Prowess** = (Strength + Dexterity) / 2
- **Finesse** = (Dexterity + Perception) / 2
- **Conviction** = (Willpower + Perception) / 2
- **Vitality** = (Stamina + Willpower) / 2

#### Meanings & Uses
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

### Emergent Stats (Second-order Derived)
Emergent Stats are second-order derived values. They should generally remain hidden from the player.

They are:

- not skills
- not personality traits
- behavioral capacities that emerge from interactions of broader competencies

#### Formulas
- **Focus** = (Endurance + Finesse) / 2
- **Insight** = (Prowess + Conviction) / 2
- **Creativity** = (Finesse + Vitality) / 2
- **Fortitude** = (Endurance + Conviction) / 2
- **Momentum** = (Vitality + Prowess) / 2

#### Focus
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

#### Insight
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

#### Creativity
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

#### Fortitude
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

#### Momentum
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

### Relationship to Other Systems (Influence Map)
- **Perception System:** detection quality, observation quality, awareness, attention (perception/finesse/focus/insight)
- **Skill System:** learning speed, growth, ceilings, practice efficiency (dexterity/focus/creativity)
- **Emotion System:** regulation, resilience, recovery (willpower/conviction/fortitude)
- **Decision System:** decision quality, goal persistence, action selection (insight/focus/momentum)
- **Personality System:** stats influence experience → memory → personality drift, but do not directly set personality

### Developmental Loop (Intended)
**Genetics → Stats → Competencies → Behavioral Capacities → Actions → Experiences → Memory → Personality**

### Design Goals
- keep core stats simple
- create meaningful derived competencies
- support emergent behavior
- separate capability from personality
- allow experience to shape identity
- create natural specialization
- produce believable developmental divergence
- support large-scale simulation efficiently

---

## Merged Emergent Stat Lattice Notes

This section preserves the lattice calculator observations from the deleted staged stats note.

## Emergent Stat Lattice Notes (Gemini Additions)

This file captures the additional “lattice calculator / design observation / next step” content present in the previous raw conversation note.

### Emergent Stat “DNA” Mapping
Because the lattice is mathematically nested:

- Core stats → Advanced stats → Emergent stats

Gemini’s derived mapping shows each Emergent Stat as an equal blend of four Core Stats.

| Emergent Stat | Component 1 | Component 2 | Raw Core Mix |
|---|---:|---:|---|
| **Focus** | Endurance | Finesse | (Strength + Stamina + Dexterity + Perception) / 4 |
| **Insight** | Prowess | Conviction | (Strength + Dexterity + Willpower + Perception) / 4 |
| **Creativity** | Finesse | Vitality | (Dexterity + Perception + Stamina + Willpower) / 4 |
| **Fortitude** | Endurance | Conviction | (Strength + Stamina + Willpower + Perception) / 4 |
| **Momentum** | Vitality | Prowess | (Stamina + Willpower + Strength + Dexterity) / 4 |

### Design Insight: One Core Stat Omitted
Each emergent stat formula omits exactly one core stat:

- Focus excludes **Willpower**
- Momentum excludes **Perception**

This supports believable behavior decoupling:

- a creature can be blind/low-awareness (low perception)
- but still have strong initiative (high momentum)

### Strengths
- **Decoupling capability from intent** (avoid “High Strength = Aggressive” style coupling)
- **Performance**: derived stats avoid storing many values per creature
- **Believable divergence**: injuries/training drift core stats → emergent capacities change → success/failure feeds memories → personality drift

### Next Design Question (From Gemini)
Emergent Stats must ultimately feed the decision engine. The key integration choice:

- Should high **Momentum** evaluate goals more frequently?
- Or should it weight active goals (explore/hunt) with higher baseline utility than passive goals (rest/socialize)?
