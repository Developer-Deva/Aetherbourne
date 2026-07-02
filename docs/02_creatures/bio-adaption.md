# Aetherbourne: Biological Adaptation System Specification (v2.0)

## 1. System Architecture

The stat system is divided into three tiers, each governed by a specific data flow mechanism.

### Tier 1: Core Stats (The "Hardware" Layer)

**Properties:** Inherited, Trainable, Mutable.

* **Stats:** Strength, Stamina, Dexterity, Perception, Willpower.
* **Logic:** Driven by the **Universal Adaptation Engine** (Adaptation/Stress/Injury).
* **Data Structure:** Each stat object contains `current`, `target` (maturity), `ceiling` (genetic limit), `stress_buffer`, and an `is_dirty` flag.

### Tier 2: Advanced Stats (The "Performance" Layer)

**Properties:** Derived, Instantaneous, Read-Only.

* **Stats:** Endurance, Prowess, Finesse, Conviction, Vitality.
* **Logic:** Formulaic derivatives updated via an Observer pattern when a Core stat changes.
* **Example:** `Prowess = (Strength * 0.5) + (Dexterity * 0.5)`

### Tier 3: Hidden Stats (The "Emergence" Layer)

**Properties:** Cumulative, Historical, Context-Dependent.

* **Stats:** Focus, Insight, Creativity, Fortitude, Momentum.
* **Logic:** Driven by history buffers and event triggers. They store the "story" of the creature's experiences.

---

## 2. The Universal Adaptation Engine (Core Loop)

This logic runs on the daily/seasonal tick for all creatures.

### The Logic Pipeline:

1. **Life Stage Assessment:** Check Age vs. Prime/Maturity. Apply growth or senescence multipliers.
2. **Environmental/Elevation Check:** Adjust active Core stats based on biome constraints (e.g., altitude $\rightarrow$ Stamina).
3. **Behavioral Audit:** Compare `DailyDistance` vs. `Thresholds` (Atrophy/Optimal/Overdrive).
4. **Stress Buffer Update:** Apply stress/recovery.
5. **Injury Resolution:** If `StressBuffer >= 10`, force `InjuryEvent` and penalize `Current` Core stat.
6. **Flag Propagation:** If any Core stat changes, set `is_dirty = true`.

---

## 3. Implementation Specification

### The Data Object

```rust
struct Creature {
    core_stats: HashMap<StatType, CoreStat>,
    advanced_stats: AdvancedStats, // Cached values
    hidden_stats: HiddenStats,
    is_dirty: bool, // Observer flag
}

```

### The Update Logic (Pseudocode)

```rust
fn process_biological_tick(creature: &mut Creature) {
    // 1. Core Adaptation
    for (stat_type, stat) in creature.core_stats.iter_mut() {
        // Apply environmental or activity-based delta
        let delta = calculate_delta(creature, stat_type);
        
        stat.current = clamp(stat.current + delta, 1, stat.ceiling);
        
        // Update Stress
        stat.stress = update_stress_buffer(stat, delta);
        
        // Handle Breaking Point
        if stat.stress >= 10 {
            trigger_injury(stat);
        }
    }

    // 2. Observer Pattern: Update Tier 2 (Advanced)
    if creature.is_dirty {
        creature.advanced_stats.recalculate(&creature.core_stats);
        creature.is_dirty = false;
    }
}

```

---

## 4. Edge Case Matrix

| Scenario | Trigger | Logic |
| --- | --- | --- |
| **Maturation** | `Age < Maturity` | `Current` moves toward `Target`. |
| **Senescence** | `Age > Prime` | `Ceiling` and `Current` decay by a factor of $0.05$ annually. |
| **High Altitude** | `BiomeType == Mountain` | Modifier on `Stamina` adaptation rate. |
| **Injury** | `Stress > 10` | `Current` Core stat reduced (Injury Penalty); `Fortitude` (Hidden) incremented. |
| **Over-Specialization** | `Current == Ceiling` | Adaptation effort converts to `Stress` instead of `Stat Growth`. |
| **Famine** | `Dietary Intake < Need` | Force `Atrophy` regardless of activity; `Vitality` (Advanced) penalty. |

---

## 5. Emergent Logic: Hidden Stats

Hidden stats do not follow formulas; they follow **cumulative experience**.

* **Focus:** Increment based on `Duration of Focused Task` / `Total Day Length`.
* **Insight:** Increment on `(Success_Counter)`. Requires tracking successful complex interactions.
* **Creativity:** Increment on `(Unique_Action_Count)`. Track actions in a set; if the action is new, increment.
* **Fortitude:** Increment on `(Injury_Event_Count)`. Specifically tracks survival after `Stress` breaks.
* **Momentum:** Track the last 10 actions. If `Count(Success) > 7`, increment.

## 6. Balancing Design Principles

1. **Core-Driven:** You should never manually modify an Advanced Stat. Always change the Core Stat that feeds the formula.
2. **Hardware vs. Memory:** Core stats define what the body *can do*. Hidden stats define what the creature *has experienced*.
3. **The Feedback Loop:** If a creature is "over-adapted" (e.g., very high strength), their needs (food/stamina) increase, which naturally creates a risk of `Atrophy` if the environment is harsh, creating a self-regulating ecosystem.

This specification should now be ready for integration into your codebase. The key is the `is_dirty` flag—it ensures your system remains performant even as your creature count scales.
