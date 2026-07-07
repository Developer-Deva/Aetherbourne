# Aetherbourne AI Needs System Design

This document formalizes the architecture for agent biological drives, emotional states, and environmental comfort processing loops. In accordance with the core architecture rules of *Aetherbourne*, all systems utilize **deterministic integer math** scaled from `0` to `10,000` (translated to a `0-100%` UI layout for clarity) and implement the **Dirty-Flag Pattern** to decouple constant physical decay from heavy behavior updates.

---

## 1. Systemic Philosophy: Core Needs vs. Derived States

To prevent erratic behavior or AI simulation loops breaking down, the agent state architecture is bifurcated into two independent but deeply linked pipelines:

1. **Core Needs (Visible Drivers):** Simple linear and non-linear variables that decay over time or deplete via specific action costs. These serve as the direct numeric input into utility function decision-making calculations.
2. **Derived States (Hidden Stress/Condition Matrix):** Passive, non-utility calculations derived entirely from the current levels of Core Needs, missing health, or environmental threat vectors. They modify an agent's base attributes, cap skill execution effectiveness, or trigger permanent biological mutations and psychological trauma loops.

---

## 2. Core Needs & Behavioral Hierarchy

Core Needs determine what an agent *wants* to do. Every need has an explicit `BasePriority` scalar applied when a need enters an active threshold.

| Need | Base Priority | Decay / Flux Sources | Behavioral Manifestation & AI Target Loop |
| :--- | :---: | :--- | :--- |
| **Health** | 5.0 | Damage, Toxins, Disease, Extreme Deprivation | Cease labor. Seek medicinal poultices/rest. Flee threats. |
| **Thirst** | 4.0 | Passive time base, High Thermal Comfort delta, Labor | Drop tasks. Migrate to clean water features (rivers, lakes). |
| **Hunger** | 3.5 | Passive time base, Physical Exertion, Metabolic rate | Forage flora, hunt fauna, consume cooked matrices, trade. |
| **Energy** | 3.0 | Wakefulness tick, Combat strain, Heavy Labor | Return to community bed, build temporary shelter, rest. |
| **Safety** | 2.5 | Hostile proximity, Dark Biomes, Isolation | Flee to fortified communities, group up, draw weapons. |
| **Thermal Comfort** | 2.2 | Environmental delta vs. Equipment insulation | Migrate to heat/shade sources, strip or swap armor sets. |
| **Hygiene** | 2.0 | Labor Intensity, Mud/Wetland terrain, Waste handling | Wash in non-contaminated streams, use alchemical soaps. |
| **Affection** | 1.7 | Social isolation, long periods without ritual interaction | Seek community members, converse, gift-give, seek mates. |
| **Curiosity** | 1.2 | Time spent in static or fully discovered tiles | Explore unmapped fog-of-war tiles, inspect new objects. |
| **Purpose** | 1.0 | Idle time, lack of systemic contribution | Pursue long-term legacy goals, craft, train combat skills. |

---

## 3. Need Urgency States

Urgency levels map directly to state machine priorities. When evaluating goals, utility equations scale dynamically based on the current state bucket:

* **Satiated (100 - 81):** Drive is totally fulfilled. Utility score is effectively zeroed out. The agent dedicates ticks to psychological or long-term growth goals (**Curiosity**, **Purpose**).
* **Stable (80 - 51):** Drive is present but safely managed. Regular schedules (working a forge, farming, guarding) are prioritized normally.
* **Pressing (50 - 21):** Drive begins dictating actions. The agent finishes their current macro-task early and initiates systemic item searches or local travel tasks to resolve the specific dipping need.
* **Critical (20 - 0):** The agent enters **Survival Mode**. All low-priority actions, cultural rituals, and labor loops are completely abandoned. Non-essential priorities (**Belonging, Curiosity, Purpose, Hygiene**) drop their evaluation values to 0. The agent focuses exclusively on preservation or resource consumption.

> **Systemic Exception:** If a need like **Hygiene** or **Affection** hits `Critical`, it **does not** trigger standard survival movement. Instead, it injects severe exponential spikes into the *Derived Hidden States* (Stress, Morale), forcing behavioral breakdowns indirectly rather than driving immediate frantic navigation.

---

## 4. The Homeostasis Engine: Thermal Comfort

Thermal tracking does not use a passive decay bar over time. It measures immediate systemic exposure.

```
+-------------------------------------------------------+
|                Environmental Variables                |
|        (Biome Base + Season Shift + Time of Day)       |
+---------------------------+---------------------------+
                            |
                            v
+-------------------------------------------------------+
|               Tile Ambient Temperature                |
+---------------------------+---------------------------+
                            |
                            v
+-------------------------------------------------------+
|             Equipment Insulation Modifier             |
|         (Rigid Plates / Insulating Soft Liners)       |
+---------------------------+---------------------------+
                            |
                            v
+-------------------------------------------------------+
|           Calculated Thermal Equilibrium              |
|        (Deviation from Creature Optimal Temp)         |
+---------------------------+---------------------------+
                            |
                            v
+-------------------------------------------------------+
|            Core Need: Thermal Comfort Flux            |
+-------------------------------------------------------+
```

### Thermal Flux Mathematical Formula
For every simulation tick, the system calculates the exact difference between the tile's modified temperature and the creature's native optimal homeostatic envelope:

$$\Delta T = |T_{	ext{ambient}} - T_{	ext{optimal}}|$$

$$I_{	ext{net}} = \sum 	ext{Equipment Insulation Value}$$

$$	ext{ThermalFlux} = \max(0, \Delta T - I_{	ext{net}}) 	imes 	ext{TickRate}$$

* If **Hot Deviation:** Pulls `Thermal Comfort` down toward 0. Agent emits a high thermal signature, avoids dry/desert tiles, and drops heavy plate layers if possible.
* If **Cold Deviation:** Pulls `Thermal Comfort` down toward 0. Agent prioritizes moving near local thermodynamic entities (furnaces, campfires, thermal flora) and seeks indoor shelter grids.

---

## 5. The Hidden State Pipeline (Derived Conditions)

Derived conditions are calculated continuously using current Core Needs as raw numerical components. They operate as immediate status modifiers.

### Pain
* **Calculation Source:** Derived inversely from missing health percentages and amplified by status conditions (e.g., bone fractures, burn zones).
* **Formula Example:**
  $$	ext{RawPain} = (10000 - 	ext{CurrentHealth}) 	imes 	ext{InjurySeverityMultiplier}$$
* **Systemic Output:** Pain directly applies a negative modifier to the creature's raw physical **Potential (Stats)**. A creature with high pain has low raw attributes, which immediately drags down their total **Capability Score** across all active physical skill executions.

### Stress
* **Calculation Source:** Accumulates dynamically over time for every hour any Core Need is sustained within the *Pressing* or *Critical* boundaries. Taking unmitigated damage or witnessing community deaths injects instant static stress additions.
* **Systemic Output:** Stress directly functions as a negative filter for **Focus**. High stress narrows target evaluation criteria, making the agent easily startled, prone to fleeing prematurely from manageable combat threats, or causing critical failure rates to skyrocket during fine-motor crafting tasks.

### Morale & Sanity
* **Calculation Source:** This is the ultimate long-term rolling structural tracking score of an agent's well-being. It calculated via an exponential moving average of an agent’s total average needs satisfaction over several simulation days.
* **Systemic Output:** * **High Morale:** Generates an artificial status buffer, reducing raw Stress gain rates and adding positive offsets to willpower checks.
  * **Low Sanity/Morale:** Triggers psychological breakdown state overrides. The AI temporary unhooks from standard utility math to execute erratic behavioral packages: catatonia, violent outbursts, panic migrations, or the abandonment of cultural alignments.

---

## 6. Mating Cycles & Lifecycles (The Affection Loop)

To prevent AI from breaking its utility priority paths with erratic mating drives, reproduction is integrated entirely into the high-satisfaction behavior loop of the **Affection** need:

1. **The Biological Baseline:** A creature's reproduction drive is suppressed completely until they reach the adult milestone specified within their genetic lattice.
2. **The Satiation Trigger:** Courtship, nesting behavior, and mate evaluation routines are **only** processed when all survival needs (**Health, Thirst, Hunger, Energy, Safety**) are securely stabilized within the **Satiated (81-100)** state zone.
3. **Emergent Courtship:** When survival pressures reach zero, the natural decay of the `Affection` core need bubbles up to become the highest remaining priority in the AI execution queue. The agent transitions from basic community socializing to executing complex genetic matching and nesting behaviors with compatible faction targets.

---

## 7. Implementation Rules for Code Architecture

1. **Integer Math Only:** Never use floating-point numbers for raw state processing. All metrics are mapped internally from `0` to `10,000` to guarantee total determinism across network links and server simulation ticks.
2. **The Dirty-Flag Pattern Rule:** Core needs decay on simple linear schedules via lightweight tick routines. Heavy utility math calculations (evaluating available items, scanning tiles, changing AI goal targets) are completely bypassed *unless* a core need flips a flag by transitioning from one urgency state boundary to another (e.g., moving from Stable to Pressing).
3. **Immutability of Outputs:** Derived states (Pain, Stress, Morale) read from Core Needs but must *never* inject calculations directly back into Core Needs. They alter physical attributes or override the goal selection framework entirely, keeping the dependency pipeline clean and strictly one-directional.