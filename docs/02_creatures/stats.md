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
 * **Skill ($w_{2}3):** The multiplier representing training (e.g., *Archery Skill* for a hunt).
 * **EnvironmentModifier:** External factors (e.g., weather, terrain).
**Why this prevents bloat:**
 * **Growth:** An agent can increase their *Capability* through Skill growth (Nurture) without altering their genetic *Stat* (Nature).
 * **Decay:** If an agent is injured, their *Stat* drops. Their *Skill* remains high, but the *Capability* outcome is reduced proportionally to the injury.

## 6. Design Rules

 1. **Immutability:** Emergent stats never loop back into Base stats.
 2. **Integer Math:** Always use integer division to ensure 100% deterministic results across simulation runs.
 3. **Dirty-Flag Pattern:** Never recalculate on every tick. Only recalculate when is_dirty == true (e.g., after an event changes a base stat).