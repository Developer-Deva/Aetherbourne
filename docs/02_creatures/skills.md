# Architecture Specification: The Core Skill Registry

## 1. Design Philosophy

The Skill Registry represents **Nurture**—the behavioral efficiency multipliers mapping to systemic vectors.

* **Stats** are the "Hardware" handled strictly by the Stat Lattice. They determine raw potential capacity.
* **Skills** are the "Software." They determine efficiency, application, and level-based scaling.
* **The Golden Rule:** Skills **do not** modify Stats. Instead, Stats and Skills converge dynamically during the Capability Calculation loop:

$$\text{Capability} = (\text{HardwareStat} \times w_{1}) + (\text{SoftwareSkill} \times w_{2}) + \text{EnvironmentalModifier}$$

* **HardwareStat ($w_{1} = 0.6$):** The core constant potential capacity mapped from the Stat Lattice.
* **SoftwareSkill ($w_{2} = 0.4$):** The learned capability multiplier (0–10 level integer scaling).

---

## 2. Hard Matter Processing (High `STRUCT_DENSITY`)

### `SKILL_SMITHING`

* **Systemic Definition:** Manipulation, thermal refinement, and structural alignment of high-density metallic molecular lattices.
* **Primary Material Axes:** High `STRUCT_DENSITY`, Low `ELASTICITY_MATRIX`.
* **Governed Actions:** `Craft`, `Refine`, `Repair`, `Improve`.
* **Capability Hardware Mapping:** **Prowess (Pro)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Reduces material waste coefficients during metallurgy passes. Determines the max structural threshold of weapons, tool heads, and metallic plating frames before localized stress deformation triggers durability decay.

### `SKILL_MASONRY`

* **Systemic Definition:** Fracturing, shaping, binding, and structural load balancing of dense, brittle minerals, aggregates, and earthen clays.
* **Primary Material Axes:** High `STRUCT_DENSITY`, Minimum `ELASTICITY_MATRIX` (Ultra-Brittle).
* **Governed Actions:** `Build`, `Craft`, `Assemble`, `Repair`.
* **Capability Hardware Mapping:** **Endurance (End)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Dictates the structural integrity vectors of stationary structures (walls, foundations, kilns) and pottery containers. High capability prevents dynamic weight-load structural collapse over time.

### `SKILL_ALCHEMY`

* **Systemic Definition:** The isolation, stabilizing thermal control, and synthesis of reactive fluid compounds or volatile elements.
* **Primary Material Axes:** High `VOLATILITY`, High `CORROSIVE_AXIS`, High `TOXICITY`.
* **Governed Actions:** `Refine`, `Experiment`, `Inspect`.
* **Capability Hardware Mapping:** **Focus (Foc)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Controls the chemical runaway velocity during processing. High capability prevents catastrophic explosive or corrosive venting cycles when blending highly reactive material inputs.

---

## 3. Soft Matter & Expression (High `ELASTICITY_MATRIX`)

### `SKILL_TAILORING`

* **Systemic Definition:** Interlocking, weaving, curing, and treating organic tensile fibers, hides, and flexible matrices.
* **Primary Material Axes:** High `ELASTICITY_MATRIX`, Low `STRUCT_DENSITY`.
* **Governed Actions:** `Craft`, `Assemble`, `Improve`, `Refine` (Dyeing).
* **Capability Hardware Mapping:** **Finesse (Fin)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Controls textile insulation values and armor coverage matrices. When handling liquid pigments, this skill uses the material's `CORROSIVE_AXIS` to successfully bind color fastness to a cloth's `PURITY` without degrading the structural fabric grid.

### `SKILL_WOODWORKING`

* **Systemic Definition:** Precision shaving, joining, and stress-profiling of fibrous, cell-grained organic matrices (woods, canes, bone composites).
* **Primary Material Axes:** Balanced `STRUCT_DENSITY` + Balanced `ELASTICITY_MATRIX`.
* **Governed Actions:** `Craft`, `Assemble`, `Build`.
* **Capability Hardware Mapping:** **Prowess (Pro)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Governs the structural tension limits of flex-critical equipment (bow staves, tool hafts, shields) and structural framing elements.

### `SKILL_ARTISTRY`

* **Systemic Definition:** Application of visual compositions, aesthetic pigments, and geometric decoration to express meaning or record historical observations.
* **Primary Material Axes:** High `PURITY` + High `AETHER_SATURATION`.
* **Governed Actions:** `Record`, `Preserve`, `Experiment`, `Perform`.
* **Capability Hardware Mapping:** **Creativity (Cre)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Translates material attributes into environmental aura buffers. High-quality art pieces broadcast psychological stability vectors to nearby inhabitants, directly mitigating emotional stress and adjusting local room values.

### `SKILL_MUSIC`

* **Systemic Definition:** Generation and harmonic execution of acoustic frequencies using resonant organic or mineral tension arrays.
* **Primary Material Axes:** High `ELASTICITY_MATRIX` (tension) + High `AETHER_SATURATION` (resonance).
* **Governed Actions:** `Perform`, `Rehearse`, `Bond`, `Court`.
* **Capability Hardware Mapping:** **Creativity (Cre)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Actively broadcasts an audio waveform vector across local grid cell tiles, modifying the immediate `Social` and `Courtship` action scoring calculations for all agents within hearing range.

---

## 4. Field & Interaction (Environmental & Social Vectors)

### `SKILL_MINING`

* **Systemic Definition:** Dynamic stress-fracturing, mechanical leverage, and harvesting of subterranean or surface lithosphere deposits.
* **Primary Material Axes:** Directly counteracts targeted tile `STRUCT_DENSITY`.
* **Governed Actions:** `Mine`, `Gather`.
* **Capability Hardware Mapping:** **Momentum (Mom)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Determines mass extraction yield per physical tick. Higher capability reduces structural fatigue damage feedback to the harvesting tool by locating optimized natural fault lines.

### `SKILL_AGRICULTURE`

* **Systemic Definition:** The cultivation, nutritional optimization, and biological management of botanical flora and crop systems.
* **Primary Material Axes:** Manipulates soil `THERMAL_RETENTION`, water tables, and seed `TOXICITY`/nutritional matrices.
* **Governed Actions:** `Harvest`, `Gather`, `Store`, `Plan`.
* **Capability Hardware Mapping:** **Wisdom (Wis)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Maximizes field efficiency loops and seed yields. Governs success rates when attempting to selectively isolate specific Mendelian genetic trait mutations across generational growth cycles.

### `SKILL_CHARISMA`

* **Systemic Definition:** The intentional projection, cadence manipulation, and emotional transmission of social energy to guide interpersonal values.
* **Primary Material Axes:** Modifies target entity internal emotional/psychological matrices.
* **Governed Actions:** `Speak`, `Negotiate`, `Argue`, `Threaten`, `Bond`, `Flirt`, `Greet`.
* **Capability Hardware Mapping:** Dynamic based on chosen Intent Lens:
* *Honest Bartering / Value Assessment:* **Wisdom (Wis)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* *High-Pressure Manipulation / Threaten:* **Focus (Foc)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* *Creative Improvisation / Wit / Flirt:* **Creativity (Cre)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)


* **Simulation Behavior:** Functions as the delivery software for communication. Determines an agent's leverage during trade pricing calculations or high-pressure verbal negotiations by forcing a target to alter their short-term priority matrix.

### `SKILL_STEALTH`

* **Systemic Definition:** The calculated mitigation of sensory output signatures, including optical profiles, structural shadow mapping, and acoustics.
* **Primary Material Axes:** Counters environmental light values, tile-cover indexes, and target `PERCEPTION_RADIUS`.
* **Governed Actions:** `Sneak`, `Hide`.
* **Capability Hardware Mapping:** **Finesse (Fin)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Shrinks the footprint of an agent's audio wave generation radius and dampens their visibility index, preventing nearby entities from updating their threat or awareness vectors.

---

## 5. Cognitive & Vitality (Internal Systems Management)

### `SKILL_SURVIVAL`

* **Systemic Definition:** Practical navigation, environmental threat assessments, and emergency physiological maintenance in wild biomes.
* **Primary Material Axes:** Direct mitigation of environmental tile decay vectors.
* **Governed Actions:** `Maps`, `Flee`, `Track`, `Search`, `Seek shelter`.
* **Capability Hardware Mapping:** **Vitality (Vit)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Directly slows down the rate at which hostile weather, harsh terrains, or biomes deplete an agent's primary physiological needs metrics. Allows accurate pathfinding via tracking footprints on a tile grid.

### `SKILL_MEDICINE`

* **Systemic Definition:** The diagnostic treatment of cellular trauma, disease vector management, and physiological restoration of organic bodies.
* **Primary Material Axes:** Counters `TOXICITY`, cellular decay rates, and infection vectors.
* **Governed Actions:** `Recover`, `Inspect`, `Refine` (Poultices).
* **Capability Hardware Mapping:** **Focus (Foc)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Governs healing efficiency and treatment success. Accelerates metabolic healing velocity ticks during sleep or rest states and neutralizes active biological toxin values before they cause irreversible damage to core stats.

### `SKILL_SCHOLARSHIP`

* **Systemic Definition:** Abstract problem-solving, cognitive data cross-referencing, and pedagogical transmission of complex intellectual data.
* **Primary Material Axes:** Accelerates learning capacity and structural insight.
* **Governed Actions:** `Learn`, `Remember`, `Solve`, `Teach`, `Mentor`, `Record`.
* **Capability Hardware Mapping:** **Wisdom (Wis)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Governs information fidelity transfer during `Teach` or `Mentor` actions between inhabitants. Maximizes the rate at which an agent deciphers cryptic structural blueprints or solves complex technical problems.

### `SKILL_ENCHANTING`

* **Systemic Definition:** The containment, stabilization, and permanent binding of extra-planar mana currents into physical structures.
* **Primary Material Axes:** High `AETHER_SATURATION`, High `PURITY`.
* **Governed Actions:** `Craft`, `Improve`, `Experiment`.
* **Capability Hardware Mapping:** **Focus (Foc)** ($w_1 = 0.6$) + **Skill** ($w_2 = 0.4$)
* **Simulation Behavior:** Sets the capacity limits for how much ambient extra-planar mana can be anchored to an item frame. Minimizes the rate of dangerous volatile backfires or quantum degradation over time.