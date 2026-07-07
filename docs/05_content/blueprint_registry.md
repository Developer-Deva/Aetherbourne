# Aetherbourne Master Architectural Blueprint Registry

### Document Reference: SIM-SYS-BLP-REGISTRY-2026

This master document describes the definitive, immutable code data schemas for the **60 Structural Blueprints** governing the entirety of physical matter creation within the *Aetherbourne* systemic simulation. By leveraging a strict hybrid model combining **Vector-Based Value Inheritance (Tier 2)** and **Fully Systemic Property Chemistry (Tier 3)**, individual item definitions are entirely phased out.

Each entry dictates an explicit data contract. All inputs map to standard resource attribute configurations utilizing **Pure Integer Mathematics** scaled precisely from `0` to `10,000`. At runtime, the final object's identity, performance bounds, dynamic adjectives, and failure thresholds are derived via **Mass-Weighted Multi-Axial Vector Accumulation** across the 8 Core Shared Property Axes:

1. **`STRUCT_DENSITY` (Index 0):** Compactness, mechanical hardness, kinetic impact absorption, or caloric/nutritional concentration.
2. **`VOLATILITY` (Index 1):** Thermal and chemical feedback runway sensitivity, explosive instability, or biological shelf-life degradation.
3. **`CORROSIVE_AXIS` (Index 2):** Chemical activity, solvent dissolution velocity, or inverse structural corrosion resistance for solids.
4. **`ELASTICITY_MATRIX` (Index 3):** Stress-response slider defining mechanical fracture profiles (Brittle `0-2000`, Malleable `4000-6000`, Elastic `8000+`).
5. **`AETHER_SATURATION` (Index 4):** Latent quantum/magical mana storage density and extra-planar alignment resonance anchor.
6. **`THERMAL_RETENTION` (Index 5):** Specific heat capacity insulation quotient, slowing thermal normalization ticks against local tile biomes.
7. **`TOXICITY` (Index 6):** Biological cellular degradation coefficient, heavy-metal leaching hazard, or radiological emission profile.
8. **`PURITY` (Index 7):** Structural homogeneity, component refinement factor, or assembly craftsmanship precision rating.

---

## Functional Schema Syntax Blueprint Contract

All configuration registries parsing the structural matrix must validate properties against the following unified model layout:

```json
{
  "blueprint_id": "BLP_ARCHETYPE_IDENTIFIER",
  "display_name": "Structural Archetype Name",
  "required_skill": "SKILL_ENUM_ID",
  "min_skill_level": 0, // 0 - 10,000 scaling
  "required_workbench_tags": ["WB_TAG_A", "WB_TAG_B"],
  "base_crafting_ticks": 1200,
  "slots": [
    {
      "slot_id": "SLOT_COMPONENT_ID",
      "weight_multiplier": 100, // Totals must sum precisely to 100%
      "filters": {
        "AXIS_KEY": [MIN_ALLOWED, MAX_ALLOWED]
      }
    }
  ],
  "output_archetype": "ITEM_RUNTIME_CLASS_ENUM",
  "stat_mappings": {
    "GAMEPLAY_STAT_PROPERTY": "AXIAL_MATHEMATICAL_TRANSLATOR"
  }
}
```

---

## Complete Code Blueprint Registry Mapping

### Category: Weapons & Defense

#### BLP_BLADED_SHORTSWORD — Bladed Shortsword / Dagger

* **Required Processing Skill:** `SKILL_BLADESMITHING` (Threshold Floor: `1000` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`]
* **Base Update Ticker Cost:** `400 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_WEAPON_MELEE_LIGHT`
* **Structural Component Slots Configuration:**
  * **`SLOT_LIGHT_BLADE`** | Allocation: `60%` mass value weight | Range Constraints: {STRUCT_DENSITY: [3000, 10000], PURITY: [2000, 10000]}
  * **`SLOT_GRIP`** | Allocation: `30%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [2000, 10000]}
  * **`SLOT_GUARD`** | Allocation: `10%` mass value weight | Range Constraints: {STRUCT_DENSITY: [2000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `WEAPON_DAMAGE` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `WEAPON_SPEED` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `MAGICAL_SCALING` $\leftarrow$ Derived from input state via `AETHER_SATURATION` matrix function.
  * `DURABILITY_MAX` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_BLADED_LONGSWORD — Bladed Longsword

* **Required Processing Skill:** `SKILL_BLADESMITHING` (Threshold Floor: `3000` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`, `WB_LIGHT_HEAT`]
* **Base Update Ticker Cost:** `800 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_WEAPON_MELEE_BALANCED`
* **Structural Component Slots Configuration:**
  * **`SLOT_CORE_BLADE`** | Allocation: `70%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5000, 10000], PURITY: [3000, 10000]}
  * **`SLOT_HILT_BINDING`** | Allocation: `20%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 10000]}
  * **`SLOT_POMMEL`** | Allocation: `10%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `WEAPON_DAMAGE` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `WEAPON_SPEED` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `MAGICAL_SCALING` $\leftarrow$ Derived from input state via `AETHER_SATURATION` matrix function.
  * `DURABILITY_MAX` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_BLADED_GREATSWORD — Bladed Greatsword

* **Required Processing Skill:** `SKILL_BLADESMITHING` (Threshold Floor: `5000` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`, `WB_HIGH_HEAT_FORGE`]
* **Base Update Ticker Cost:** `1400 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_WEAPON_MELEE_HEAVY`
* **Structural Component Slots Configuration:**
  * **`SLOT_MASSIVE_BLADE`** | Allocation: `75%` mass value weight | Range Constraints: {STRUCT_DENSITY: [6500, 10000], PURITY: [4000, 10000]}
  * **`SLOT_TWO_HANDED_HILT`** | Allocation: `20%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5000, 10000], ELASTICITY_MATRIX: [3000, 10000]}
  * **`SLOT_COUNTERWEIGHT`** | Allocation: `5%` mass value weight | Range Constraints: {STRUCT_DENSITY: [7000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `WEAPON_DAMAGE` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `STAGGER_FORCE` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `WEAPON_SPEED` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `DURABILITY_MAX` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_BLUNT_MACE — Blunt Mace / Club

* **Required Processing Skill:** `SKILL_WEAPONSMITHING` (Threshold Floor: `1500` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`]
* **Base Update Ticker Cost:** `600 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_WEAPON_BLUNT_LIGHT`
* **Structural Component Slots Configuration:**
  * **`SLOT_IMPACT_HEAD`** | Allocation: `70%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5500, 10000]}
  * **`SLOT_HAFT_SHAFT`** | Allocation: `30%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [3000, 8000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `ARMOR_PENETRATION` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `WEAPON_DAMAGE` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `WEAPON_SPEED` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.

----------------------------------------

#### BLP_BLUNT_WARHAMMER — Blunt Warhammer / Maul

* **Required Processing Skill:** `SKILL_WEAPONSMITHING` (Threshold Floor: `4500` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`, `WB_HIGH_HEAT_FORGE`]
* **Base Update Ticker Cost:** `1300 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_WEAPON_BLUNT_HEAVY`
* **Structural Component Slots Configuration:**
  * **`SLOT_CRUSHING_HEAD`** | Allocation: `75%` mass value weight | Range Constraints: {STRUCT_DENSITY: [7000, 10000], ELASTICITY_MATRIX: [0, 4000]}
  * **`SLOT_POLE_SHAFT`** | Allocation: `20%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 9000], ELASTICITY_MATRIX: [4000, 9000]}
  * **`SLOT_GRIP_WRAP`** | Allocation: `5%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [5000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `CRUSHING_DAMAGE` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `POISE_BREAK` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `WEAPON_SPEED` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `DURABILITY_MAX` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_PIERCING_SPEAR — Piercing Spear / Pike

* **Required Processing Skill:** `SKILL_WEAPONSMITHING` (Threshold Floor: `2000` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`]
* **Base Update Ticker Cost:** `700 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_WEAPON_PIERCING`
* **Structural Component Slots Configuration:**
  * **`SLOT_PIERCING_TIP`** | Allocation: `30%` mass value weight | Range Constraints: {STRUCT_DENSITY: [6000, 10000], PURITY: [4000, 10000]}
  * **`SLOT_ELONGATED_SHAFT`** | Allocation: `70%` mass value weight | Range Constraints: {STRUCT_DENSITY: [3000, 7500], ELASTICITY_MATRIX: [4000, 9000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `PIERCING_DAMAGE` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `REACH_DISTANCE` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `WEAPON_SPEED` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.

----------------------------------------

#### BLP_RANGED_SHORTBOW — Ranged Shortbow

* **Required Processing Skill:** `SKILL_BOW_CARVING` (Threshold Floor: `1500` / 10,000)
* **Required Workbench Tags:** [`WB_CARPENTRY_BENCH`]
* **Base Update Ticker Cost:** `600 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_RANGED_FAST`
* **Structural Component Slots Configuration:**
  * **`SLOT_FLEXIBLE_LIMBS`** | Allocation: `80%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [6000, 10000], STRUCT_DENSITY: [2000, 6000]}
  * **`SLOT_TAUT_STRING`** | Allocation: `20%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [7000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `ARROW_VELOCITY` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `ATTACK_RATE` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `DURABILITY_MAX` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_RANGED_LONGBOW — Ranged Longbow

* **Required Processing Skill:** `SKILL_BOW_CARVING` (Threshold Floor: `4000` / 10,000)
* **Required Workbench Tags:** [`WB_CARPENTRY_BENCH`]
* **Base Update Ticker Cost:** `1100 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_RANGED_HEAVY`
* **Structural Component Slots Configuration:**
  * **`SLOT_HIGH_TENSION_LIMBS`** | Allocation: `85%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5000, 8500], ELASTICITY_MATRIX: [4000, 7500]}
  * **`SLOT_HEAVY_STRING`** | Allocation: `15%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 10000], ELASTICITY_MATRIX: [8000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `MAX_RANGE` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `PROJECTILE_DAMAGE` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `DRAW_TIME_TICKS` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_PROJECTILE_AMMUNITION — Projectile Ammunition (Arrows/Bolts)

* **Required Processing Skill:** `SKILL_FLETCHING` (Threshold Floor: `500` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `200 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_AMMUNITION_STACK`
* **Structural Component Slots Configuration:**
  * **`SLOT_AMMO_TIP`** | Allocation: `25%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 10000]}
  * **`SLOT_AMMO_SHAFT`** | Allocation: `60%` mass value weight | Range Constraints: {STRUCT_DENSITY: [1000, 5000], ELASTICITY_MATRIX: [3000, 10000]}
  * **`SLOT_AMMO_FLETCHING`** | Allocation: `15%` mass value weight | Range Constraints: {STRUCT_DENSITY: [0, 2000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `ARMOR_PIERCING_MOD` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `FLIGHT_STABILITY` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `VOLATILITY_BURST` $\leftarrow$ Derived from input state via `VOLATILITY` matrix function.

----------------------------------------

#### BLP_SHIELD_PARRYING_MATRIX — Shield Parrying Matrix / Buckler / Pavise

* **Required Processing Skill:** `SKILL_ARMORSMITHING` (Threshold Floor: `2000` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `750 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_EQUIPMENT_SHIELD`
* **Structural Component Slots Configuration:**
  * **`SLOT_SHIELD_FACE`** | Allocation: `80%` mass value weight | Range Constraints: {STRUCT_DENSITY: [3000, 10000]}
  * **`SLOT_SHIELD_BRACE_HANDLE`** | Allocation: `20%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [3000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `BLOCK_ABSORPTION` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `POISE_RECOVERY_BONUS` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `WEAR_RESISTANCE` $\leftarrow$ Derived from input state via `CORROSIVE_AXIS` matrix function.

----------------------------------------

#### BLP_TORSO_FRAME — Universal Torso Frame Garment / Breastplate

* **Required Processing Skill:** `SKILL_ARMOR_ASSEMBLY` (Threshold Floor: `1000` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `900 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_EQUIPMENT_TORSO`
* **Structural Component Slots Configuration:**
  * **`SLOT_MAIN_OUTER_SHELL`** | Allocation: `75%` mass value weight | Range Constraints: {PURITY: [1500, 10000]}
  * **`SLOT_INNER_PROTECTIVE_LINING`** | Allocation: `25%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [3000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `KINETIC_DEFENSE` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `FATIGUE_COST_PER_TICK` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `MOVEMENT_PENALTY` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `ELEMENTAL_INSULATION` $\leftarrow$ Derived from input state via `THERMAL_RETENTION` matrix function.

----------------------------------------

#### BLP_HEAD_FRAME — Universal Head Frame Gear / Helmet / Cap

* **Required Processing Skill:** `SKILL_ARMOR_ASSEMBLY` (Threshold Floor: `1000` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `600 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_EQUIPMENT_HEAD`
* **Structural Component Slots Configuration:**
  * **`SLOT_SENSORY_MASK_SHELL`** | Allocation: `70%` mass value weight | Range Constraints: {PURITY: [1000, 10000]}
  * **`SLOT_CUSHION_PADDING`** | Allocation: `30%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `CONCUSSIVE_RESISTANCE` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `PERCEPTION_MODIFIER` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `HAZARD_SHIELDING` $\leftarrow$ Derived from input state via `CORROSIVE_AXIS` matrix function.

----------------------------------------

#### BLP_LEG_FRAME — Universal Leg Frame / Trousers / Greaves

* **Required Processing Skill:** `SKILL_ARMOR_ASSEMBLY` (Threshold Floor: `1000` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `800 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_EQUIPMENT_LEGS`
* **Structural Component Slots Configuration:**
  * **`SLOT_LOWER_GUARD_SHELL`** | Allocation: `65%` mass value weight | Range Constraints: {PURITY: [1000, 10000]}
  * **`SLOT_JOINT_ARTICULATION_BINDING`** | Allocation: `35%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [5000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `POISE_THRESHOLD` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `SPRINT_STAMINA_DRAIN` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `TRAVERSAL_AGILITY` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.

----------------------------------------

#### BLP_HAND_FOOT_FRAME — Universal Hand/Foot Frame / Gloves / Boots

* **Required Processing Skill:** `SKILL_ARMOR_ASSEMBLY` (Threshold Floor: `800` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `500 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_EQUIPMENT_PERIPHERAL`
* **Structural Component Slots Configuration:**
  * **`SLOT_PERIPHERAL_SHELL`** | Allocation: `60%` mass value weight | Range Constraints: {PURITY: [1000, 10000]}
  * **`SLOT_DEXTERITY_LINING`** | Allocation: `40%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `MANUAL_DEXTERITY_PENALTY` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `TERRAIN_SPEED_BONUS` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `UNARMED_STRIKE_BONUS` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

### Category: Tools & Utility

#### BLP_ARTISAN_HAMMER — Artisan Crafting Hammer / Mallet

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `1200` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`]
* **Base Update Ticker Cost:** `500 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_CRAFTING`
* **Structural Component Slots Configuration:**
  * **`SLOT_STRIKING_HEAD`** | Allocation: `70%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5000, 10000], VOLATILITY: [0, 3000]}
  * **`SLOT_HAFT_HANDLE`** | Allocation: `30%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [3000, 8000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `FORCE_TRANSFERENCE_EFFICIENCY` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `CRIT_DEFLECTION_RISK` $\leftarrow$ Derived from input state via `VOLATILITY` matrix function.
  * `STATION_WEAR_DELTA` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.

----------------------------------------

#### BLP_FELLING_AXE — Felling Axe

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `1000` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`]
* **Base Update Ticker Cost:** `600 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_HARVEST_WOOD`
* **Structural Component Slots Configuration:**
  * **`SLOT_WEDGE_BLADE`** | Allocation: `65%` mass value weight | Range Constraints: {STRUCT_DENSITY: [6000, 10000], ELASTICITY_MATRIX: [2000, 7000]}
  * **`SLOT_HAFT_SHAFT`** | Allocation: `35%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 9000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `LIGNEOUS_DESTRUCTION_POWER` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `CHIPPING_RESISTANCE` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `DURABILITY_MAX` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_MINING_PICKAXE — Mining Pickaxe

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `1000` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`]
* **Base Update Ticker Cost:** `650 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_HARVEST_MINERAL`
* **Structural Component Slots Configuration:**
  * **`SLOT_BEAKED_HEAD`** | Allocation: `70%` mass value weight | Range Constraints: {STRUCT_DENSITY: [6500, 10000], PURITY: [2500, 10000]}
  * **`SLOT_HAFT_SHAFT`** | Allocation: `30%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [3000, 8000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `VEIN_FRACTURE_VELOCITY` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `HARDNESS_THRESHOLD` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `REBOUND_SHOCK` $\leftarrow$ Derived from input state via `inverse(ELASTICITY_MATRIX)` matrix function.

----------------------------------------

#### BLP_SKINNING_KNIFE — Skinning Knife

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `800` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `350 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_HARVEST_FAUNA`
* **Structural Component Slots Configuration:**
  * **`SLOT_PRECISION_BLADE`** | Allocation: `60%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4500, 10000], PURITY: [5000, 10000]}
  * **`SLOT_COMPACT_HANDLE`** | Allocation: `40%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [2000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `HIDE_EXTRACTION_PURITY` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `INTACT_ORGAN_CHANCE` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `DURABILITY_MAX` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_HARVESTING_SICKLE — Harvesting Sickle

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `800` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `350 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_HARVEST_FLORA`
* **Structural Component Slots Configuration:**
  * **`SLOT_CURVED_BLADE`** | Allocation: `55%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 10000], PURITY: [4000, 10000]}
  * **`SLOT_HANDLE`** | Allocation: `45%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [3000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `BOTANICAL_SEED_PRESERVATION` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `STEM_CLEAN_CUT_POWER` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_PERCUSSIVE_CHISEL — Percussive Chisel / Gem Cutter

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `1500` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `400 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_PRECISION`
* **Structural Component Slots Configuration:**
  * **`SLOT_CHISEL_TIP`** | Allocation: `80%` mass value weight | Range Constraints: {STRUCT_DENSITY: [7000, 10000], PURITY: [5500, 10000]}
  * **`SLOT_STRIKING_CAP`** | Allocation: `20%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [1000, 6000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `CRYSTAL_GEODE_PRESERVATION` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `MASONRY_SCULPT_EFFICIENCY` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_SHOVEL_EXCAVATION_BLADE — Shovel / Excavation Spade

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `900` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `500 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_EXCAVATION`
* **Structural Component Slots Configuration:**
  * **`SLOT_SCOOP_BLADE`** | Allocation: `60%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 10000]}
  * **`SLOT_LONG_SHAFT`** | Allocation: `40%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [3000, 9000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `TILE_LAYER_SHIFT_VOLUME` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `CLAY_SAND_YIELD` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_SOIL_DISRUPTION_BLADE — Agricultural Hoe / Soil Tiller

* **Required Processing Skill:** `SKILL_AGRICULTURAL_CRAFT` (Threshold Floor: `1000` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `450 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_AGRICULTURE`
* **Structural Component Slots Configuration:**
  * **`SLOT_TILLING_EDGE`** | Allocation: `50%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4500, 9000]}
  * **`SLOT_HOE_SHAFT`** | Allocation: `50%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 9000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `SOIL_AERATION_DEPTH` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `TILE_TILL_TICK_SPEED` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.

----------------------------------------

#### BLP_GRAVITY_FLUID_DISTRIBUTOR — Gravity Fluid Distributor / Watering Can

* **Required Processing Skill:** `SKILL_AGRICULTURAL_CRAFT` (Threshold Floor: `800` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `400 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_FLUID_DISTRIBUTOR`
* **Structural Component Slots Configuration:**
  * **`SLOT_HOLLOW_RESERVOIR`** | Allocation: `80%` mass value weight | Range Constraints: {CORROSIVE_AXIS: [4000, 10000]}
  * **`SLOT_ROSE_SPROUT`** | Allocation: `20%` mass value weight | Range Constraints: {PURITY: [2000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `BUFFER_CAPACITY_MASS` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `FLUID_SPREAD_RADIUS` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `CORROSION_STABILITY` $\leftarrow$ Derived from input state via `CORROSIVE_AXIS` matrix function.

----------------------------------------

#### BLP_INVASIVE_TENSION_PRONG — Invasive Tension Prong / Lockpick Assembly

* **Required Processing Skill:** `SKILL_PRECISION_MECHANICS` (Threshold Floor: `1800` / 10,000)
* **Required Workbench Tags:** [`WB_精密TIER_1`]
* **Base Update Ticker Cost:** `300 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_BYPASS`
* **Structural Component Slots Configuration:**
  * **`SLOT_BYPASS_PIN`** | Allocation: `50%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5500, 10000], ELASTICITY_MATRIX: [3000, 8000]}
  * **`SLOT_TENSION_WRENCH`** | Allocation: `50%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [5000, 9500]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `LOCK_TORQUE_THRESHOLD` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `FEEDBACK_SENSIDER` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `SNAP_RISK` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.

----------------------------------------

#### BLP_TENSILE_AQUATIC_TETHER — Tensile Aquatic Tether / Fishing Rod

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `1100` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `500 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_AQUATIC`
* **Structural Component Slots Configuration:**
  * **`SLOT_FLEXIBLE_POLE_FRAME`** | Allocation: `65%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [6500, 10000], STRUCT_DENSITY: [1000, 5000]}
  * **`SLOT_SUBMERGED_CORD`** | Allocation: `35%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [7500, 10000], CORROSIVE_AXIS: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `CAPTURE_TENSION_LIMIT` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `FLUID_DEPTH_REACH` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `SALT_WATER_DEGRADE_RESIST` $\leftarrow$ Derived from input state via `CORROSIVE_AXIS` matrix function.

----------------------------------------

#### BLP_ABRASIVE_REFINING_MEDIUM — Abrasive Refining Medium / Whetstone / File

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `700` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `300 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_MAINTENANCE`
* **Structural Component Slots Configuration:**
  * **`SLOT_ABRASIVE_MATRIX_SOLID`** | Allocation: `90%` mass value weight | Range Constraints: {STRUCT_DENSITY: [6000, 10000], ELASTICITY_MATRIX: [0, 2000]}
  * **`SLOT_BINDER_FLUX`** | Allocation: `10%` mass value weight | Range Constraints: {PURITY: [3000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `SHARPENING_VELOCITY_TICK` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `EDGE_REALIGNMENT_QUALITY` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `FINENESS_GRID` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.

----------------------------------------

#### BLP_COMBUSTIBLE_ILLUMINATION_DEVICE — Combustible Illumination Device / Torch / Lantern

* **Required Processing Skill:** `SKILL_SURVIVAL_GEAR` (Threshold Floor: `400` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `250 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_LIGHT_HEAT`
* **Structural Component Slots Configuration:**
  * **`SLOT_SUPPORT_HANDLE_FRAME`** | Allocation: `40%` mass value weight | Range Constraints: {STRUCT_DENSITY: [2000, 8000]}
  * **`SLOT_VOLATILE_BURN_CORE`** | Allocation: `60%` mass value weight | Range Constraints: {VOLATILITY: [5000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `GRID_TILE_ILLUM_RADIUS` $\leftarrow$ Derived from input state via `VOLATILITY` matrix function.
  * `AMBIENT_THERMAL_EMISSION` $\leftarrow$ Derived from input state via `THERMAL_RETENTION` matrix function.
  * `FUEL_DEPLETION_LOOPS` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_PRECISION_CUTTING_SHEARS — Precision Cutting Shears / Tailoring Scissors

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `1400` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`]
* **Base Update Ticker Cost:** `450 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_TEXTILE`
* **Structural Component Slots Configuration:**
  * **`SLOT_SCISSOR_PUNCTURE_BLADES`** | Allocation: `70%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5500, 10000], PURITY: [5000, 10000]}
  * **`SLOT_FULCRUM_RIVET_RING`** | Allocation: `30%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 9000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `CLEAN_HIDE_SEGMENTATION` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `FIBER_SNIP_TICK_EFFICIENCY` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_PIGMENT_APPLICATOR — Pigment Applicator / Paintbrush / Quill

* **Required Processing Skill:** `SKILL_ARTISTIC_CRAFT` (Threshold Floor: `500` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `200 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_EXPRESSION`
* **Structural Component Slots Configuration:**
  * **`SLOT_FINE_BRISTLE_TIP`** | Allocation: `40%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [6000, 10000], STRUCT_DENSITY: [0, 3000]}
  * **`SLOT_GRIP_STICK`** | Allocation: `60%` mass value weight | Range Constraints: {STRUCT_DENSITY: [2000, 7000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `CANVAS_COORDINATE_CRISPNESS` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `RESERVOIR_FLUID_RETENTION` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.

----------------------------------------

### Category: Components & Refinement

#### BLP_REFINED_MATERIAL_INGOT — Refined Material Ingot / Plate / Block / Brick

* **Required Processing Skill:** `SKILL_SMELTING_METALLURGY` (Threshold Floor: `500` / 10,000)
* **Required Workbench Tags:** [`WB_SMELTING`, `WB_LIGHT_HEAT`]
* **Base Update Ticker Cost:** `300 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_REFINED_SOLID`
* **Structural Component Slots Configuration:**
  * **`SLOT_RAW_CHUNK_MATRIX`** | Allocation: `85%` mass value weight | Range Constraints: {PURITY: [0, 10000]}
  * **`SLOT_REACTION_FLUX_AGENT`** | Allocation: `15%` mass value weight | Range Constraints: {PURITY: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `AXIAL_INHERITANCE_STABILITY` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `MASS_CONSERVATION_MULTIPLIER` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_TENSILE_WOVEN_FILAMENT — Tensile Woven Filament / Thread / Yarn / Twine

* **Required Processing Skill:** `SKILL_TEXTILE_REFINEMENT` (Threshold Floor: `400` / 10,000)
* **Required Workbench Tags:** [`WB_SPINNING_WHEEL`]
* **Base Update Ticker Cost:** `200 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_REFINED_FILAMENT`
* **Structural Component Slots Configuration:**
  * **`SLOT_UNSPUN_FIBER_STALKS`** | Allocation: `100%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `TENSILE_PULL_MAX` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `STRUCT_UNIFORMITY` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_RIGID_STRUCTURAL_BEAM — Rigid Structural Beam / Shaft / Brace / Rod

* **Required Processing Skill:** `SKILL_CARPENTRY_MILLING` (Threshold Floor: `600` / 10,000)
* **Required Workbench Tags:** [`WB_CARPENTRY_BENCH`]
* **Base Update Ticker Cost:** `250 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_REFINED_STRUCT_MEMBER`
* **Structural Component Slots Configuration:**
  * **`SLOT_RAW_RIGID_CORE`** | Allocation: `90%` mass value weight | Range Constraints: {STRUCT_DENSITY: [3500, 10000]}
  * **`SLOT_TREATMENT_COATING`** | Allocation: `10%` mass value weight | Range Constraints: {CORROSIVE_AXIS: [2000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `BEARING_LOAD_KINETIC` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `WEATHERING_LOCK` $\leftarrow$ Derived from input state via `CORROSIVE_AXIS` matrix function.

----------------------------------------

#### BLP_RIVETED_BINDING_HARDWARE — Riveted Binding Hardware / Nails / Screws / Fasteners

* **Required Processing Skill:** `SKILL_SMELTING_METALLURGY` (Threshold Floor: `800` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`]
* **Base Update Ticker Cost:** `150 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_REFINED_FASTENER`
* **Structural Component Slots Configuration:**
  * **`SLOT_FASTENER_METAL`** | Allocation: `100%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5000, 10000], ELASTICITY_MATRIX: [3000, 7500]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `CLAMP_PRESSURE_HOLD` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `SHEAR_STRESS_RESIST` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.

----------------------------------------

#### BLP_PULVERIZED_DUST — Pulverized Dust / Mineral Extract / Catalyst Flour

* **Required Processing Skill:** `SKILL_ALCHEMICAL_REFINEMENT` (Threshold Floor: `500` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `150 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_REFINED_CATALYST_POWDER`
* **Structural Component Slots Configuration:**
  * **`SLOT_INPUT_SHATTER_SOLID`** | Allocation: `100%` mass value weight | Range Constraints: {PURITY: [1000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `DISSOLUTION_SURFACE_AREA_BONUS` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `VECTOR_RELEASE_VELOCITY` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_CHEMICAL_SOLVENT — Chemical Solvent / Base Leach Fluid

* **Required Processing Skill:** `SKILL_ALCHEMICAL_REFINEMENT` (Threshold Floor: `1200` / 10,000)
* **Required Workbench Tags:** [`WB_REACTION_TANK`]
* **Base Update Ticker Cost:** `400 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_LIQUID_REAGENT`
* **Structural Component Slots Configuration:**
  * **`SLOT_DISSOLUTION_MEDIUM_FLUID`** | Allocation: `80%` mass value weight | Range Constraints: {CORROSIVE_AXIS: [4000, 10000]}
  * **`SLOT_ACTIVE_LEACH_SOLUTE`** | Allocation: `20%` mass value weight | Range Constraints: {PURITY: [2000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `SOLVENT_ACIDITY_STRENGTH` $\leftarrow$ Derived from input state via `CORROSIVE_AXIS` matrix function.
  * `SATURATION_CEILING_UNIT` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_ALCHEMICAL_EXTRACT — Alchemical Extract / Concentrated Essence

* **Required Processing Skill:** `SKILL_ALCHEMICAL_REFINEMENT` (Threshold Floor: `2000` / 10,000)
* **Required Workbench Tags:** [`WB_ALCHEMICAL_STILL`]
* **Base Update Ticker Cost:** `500 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_LIQUID_ESSENCE`
* **Structural Component Slots Configuration:**
  * **`SLOT_REACTIVE_BIO_ESSENCE`** | Allocation: `70%` mass value weight | Range Constraints: {AETHER_SATURATION: [3000, 10000]}
  * **`SLOT_CARRIER_FLUID_BASE`** | Allocation: `30%` mass value weight | Range Constraints: {PURITY: [5000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `MAGICAL_RESONANCE_DRIVE` $\leftarrow$ Derived from input state via `AETHER_SATURATION` matrix function.
  * `CHEMICAL_STABILITY_FRAME` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_MECHANICAL_GEARWORK — Mechanical Gearwork / Cogwheel / Spring Assembly

* **Required Processing Skill:** `SKILL_PRECISION_MECHANICS` (Threshold Floor: `2200` / 10,000)
* **Required Workbench Tags:** [`WB_精密TIER_1`]
* **Base Update Ticker Cost:** `600 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_REFINED_GEARWORK`
* **Structural Component Slots Configuration:**
  * **`SLOT_INTERLOCKING_TEETH_BODY`** | Allocation: `70%` mass value weight | Range Constraints: {STRUCT_DENSITY: [6000, 10000], ELASTICITY_MATRIX: [2000, 6000]}
  * **`SLOT_CENTER_AXLE_PIN`** | Allocation: `30%` mass value weight | Range Constraints: {STRUCT_DENSITY: [7000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `TORQUE_RATIO_EFFICIENCY` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `FRICTION_LOSS_MIN` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_MECHANICAL_FASTENER_ASSEMBLY — Mechanical Fastener Assembly / Lock Mechanism

* **Required Processing Skill:** `SKILL_PRECISION_MECHANICS` (Threshold Floor: `2500` / 10,000)
* **Required Workbench Tags:** [`WB_精密TIER_1`]
* **Base Update Ticker Cost:** `700 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_REFINED_LOCKBOX_CORE`
* **Structural Component Slots Configuration:**
  * **`SLOT_TUMBLER_PIN_BARREL`** | Allocation: `60%` mass value weight | Range Constraints: {STRUCT_DENSITY: [6500, 10000], PURITY: [4000, 10000]}
  * **`SLOT_DEADBOLT_SHACKLE`** | Allocation: `40%` mass value weight | Range Constraints: {STRUCT_DENSITY: [7500, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `LOCK_COMPLEXITY_AXIS` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `WARD_BREACH_RESISTANCE` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

### Category: Consumables & Bio-Chemistry

#### BLP_NUTRITIONAL_RATION_MATRIX — Nutritional Ration Matrix / Cooked Meal / Stew

* **Required Processing Skill:** `SKILL_CULINARY_ARTS` (Threshold Floor: `200` / 10,000)
* **Required Workbench Tags:** [`WB_COOKING`, `WB_LIGHT_HEAT`]
* **Base Update Ticker Cost:** `400 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_CONSUMABLE_FOOD`
* **Structural Component Slots Configuration:**
  * **`SLOT_ORGANIC_BULK_MASS`** | Allocation: `80%` mass value weight | Range Constraints: {TOXICITY: [0, 4000]}
  * **`SLOT_PRESERVATION_MEDIUM`** | Allocation: `20%` mass value weight | Range Constraints: {PURITY: [2000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `METABOLIC_SATURATE_CALORIE` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `SPOIL_TICK_RESIST` $\leftarrow$ Derived from input state via `THERMAL_RETENTION` matrix function.
  * `TOXIC_SIDE_EFFECT` $\leftarrow$ Derived from input state via `TOXICITY` matrix function.

----------------------------------------

#### BLP_FLUID_BEVERAGE_SOLUTION — Fluid Beverage Solution / Infused Tea / Tonic

* **Required Processing Skill:** `SKILL_CULINARY_ARTS` (Threshold Floor: `400` / 10,000)
* **Required Workbench Tags:** [`WB_COOKING`, `WB_LIGHT_HEAT`]
* **Base Update Ticker Cost:** `300 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_CONSUMABLE_DRINK`
* **Structural Component Slots Configuration:**
  * **`SLOT_AQUEOUS_BASE_FLUID`** | Allocation: `85%` mass value weight | Range Constraints: {PURITY: [3000, 10000]}
  * **`SLOT_BIO_ACTIVE_SOLUTE_STEM`** | Allocation: `15%` mass value weight | Range Constraints: {TOXICITY: [0, 5000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `HYDRATION_UNITS_DELTA` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `ABSORPTION_FRAME_SPEED` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `AETHER_REFRESH` $\leftarrow$ Derived from input state via `AETHER_SATURATION` matrix function.

----------------------------------------

#### BLP_BIOMEDICAL_POULTICE_SUSPENSION — Biomedical Poultice / Antidote / Healing Salve

* **Required Processing Skill:** `SKILL_ALCHEMICAL_MEDICAL` (Threshold Floor: `1000` / 10,000)
* **Required Workbench Tags:** [`WB_REACTION_TANK`]
* **Base Update Ticker Cost:** `500 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_CONSUMABLE_MEDICINE`
* **Structural Component Slots Configuration:**
  * **`SLOT_VISCOUS_SUBSTRATE_BASE`** | Allocation: `60%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 10000]}
  * **`SLOT_COAGULANT_ACTIVE_COMPOUND`** | Allocation: `40%` mass value weight | Range Constraints: {PURITY: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `CELLULAR_REPAIR_VELOCITY` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `BLOOD_CLOT_TICK_ACCEL` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `TOXIC_OVERLOAD_CLEANSE` $\leftarrow$ Derived from input state via `inverse(TOXICITY)` matrix function.

----------------------------------------

#### BLP_LIQUID_RESTORATIVE — Liquid Restorative / Elixir Matrix / Healing Potion

* **Required Processing Skill:** `SKILL_ALCHEMICAL_MEDICAL` (Threshold Floor: `1500` / 10,000)
* **Required Workbench Tags:** [`WB_REACTION_TANK`, `WB_LIGHT_HEAT`]
* **Base Update Ticker Cost:** `600 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_CONSUMABLE_ELIXIR`
* **Structural Component Slots Configuration:**
  * **`SLOT_REACTIVE_FLUID_VEHICLE`** | Allocation: `70%` mass value weight | Range Constraints: {PURITY: [5000, 10000]}
  * **`SLOT_POTENCY_CATALYST_SOLUTE`** | Allocation: `30%` mass value weight | Range Constraints: {AETHER_SATURATION: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `RESTORE_POTENCY_AXIS` $\leftarrow$ Derived from input state via `AETHER_SATURATION` matrix function.
  * `RUNAWAY_EXPLOSION_VOLATILITY` $\leftarrow$ Derived from input state via `VOLATILITY` matrix function.

----------------------------------------

#### BLP_GASEOUS_INHALANT — Gaseous Inhalant / Smelling Salts / Aerosol Bomb

* **Required Processing Skill:** `SKILL_ALCHEMICAL_MEDICAL` (Threshold Floor: `2500` / 10,000)
* **Required Workbench Tags:** [`WB_ALCHEMICAL_STILL`, `WB_HIGH_HEAT_FORGE`]
* **Base Update Ticker Cost:** `700 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_CONSUMABLE_GAS_CONTAINER`
* **Structural Component Slots Configuration:**
  * **`SLOT_VOLATILE_AEROSOL_FLUID`** | Allocation: `60%` mass value weight | Range Constraints: {VOLATILITY: [6000, 10000]}
  * **`SLOT_ACTIVE_VAPORIZER_DRUST`** | Allocation: `40%` mass value weight | Range Constraints: {TOXICITY: [0, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `ATMOSPHERIC_EXPANSION_TICKS` $\leftarrow$ Derived from input state via `VOLATILITY` matrix function.
  * `GAS_SATURATION_CLOUD_DENSITY` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `CELLULAR_DAMAGE_PER_FRAME` $\leftarrow$ Derived from input state via `TOXICITY` matrix function.

----------------------------------------

#### BLP_COAGULATING_CATALYST — Coagulating Catalyst / Chemical Gel Thickener

* **Required Processing Skill:** `SKILL_ALCHEMICAL_REFINEMENT` (Threshold Floor: `1100` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `350 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_CHEMICAL_THICKENER`
* **Structural Component Slots Configuration:**
  * **`SLOT_ACTIVE_BINDING_COMPOUND`** | Allocation: `100%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5000, 10000], ELASTICITY_MATRIX: [0, 3000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `PHASE_TRANSITION_EFFICIENCY` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `PRECIPITATION_RATE` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_CORROSIVE_LINIMENT — Corrosive Liniment / Blade Poison / Acid Polish

* **Required Processing Skill:** `SKILL_ALCHEMICAL_REFINEMENT` (Threshold Floor: `1800` / 10,000)
* **Required Workbench Tags:** [`WB_REACTION_TANK`]
* **Base Update Ticker Cost:** `550 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_COATING_LINIMENT`
* **Structural Component Slots Configuration:**
  * **`SLOT_HIGH_ACID_SOLUTE`** | Allocation: `65%` mass value weight | Range Constraints: {CORROSIVE_AXIS: [6000, 10000]}
  * **`SLOT_CARRIER_STICKY_PASTE`** | Allocation: `35%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [5000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `MELT_ARMOR_MODIFIER` $\leftarrow$ Derived from input state via `CORROSIVE_AXIS` matrix function.
  * `CONTACT_TRANSFER_TICK_DURATION` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.

----------------------------------------

#### BLP_PYROTECHNIC_POWDER — Pyrotechnic Powder / Gunpowder Analog / Firecracker

* **Required Processing Skill:** `SKILL_ALCHEMICAL_REFINEMENT` (Threshold Floor: `2200` / 10,000)
* **Required Workbench Tags:** [`WB_REACTION_TANK`]
* **Base Update Ticker Cost:** `450 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_COMBUSTIVE_POWDER`
* **Structural Component Slots Configuration:**
  * **`SLOT_COMBUSTIVE_FUEL_SULFUR`** | Allocation: `70%` mass value weight | Range Constraints: {VOLATILITY: [7000, 10000]}
  * **`SLOT_OXIDIZER_AGENT_SALTPETER`** | Allocation: `30%` mass value weight | Range Constraints: {PURITY: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `EXPLOSIVE_FORCE_PRESSURE` $\leftarrow$ Derived from input state via `VOLATILITY` matrix function.
  * `PROPULSION_STABILITY` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_ANTIDOTE_SORBATE — Antidote Sorbate / Universal Toxin Sponge

* **Required Processing Skill:** `SKILL_ALCHEMICAL_MEDICAL` (Threshold Floor: `1300` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `400 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_CONSUMABLE_ANTIDOTE`
* **Structural Component Slots Configuration:**
  * **`SLOT_POROUS_ABSORBENT_CARBON`** | Allocation: `80%` mass value weight | Range Constraints: {STRUCT_DENSITY: [1000, 4000], PURITY: [4000, 10000]}
  * **`SLOT_BINDING_SUSPENSION_AGENT`** | Allocation: `20%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [3000, 9000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `TOXIN_ADSORPTION_UNITS` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `METABOLIC_PASS_SPEED_TICK` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.

----------------------------------------

#### BLP_INSULATED_FUEL_BRIQUETTE — Insulated Fuel Briquette / Processed Charcoal

* **Required Processing Skill:** `SKILL_SURVIVAL_GEAR` (Threshold Floor: `300` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `200 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_FUEL_SOURCE`
* **Structural Component Slots Configuration:**
  * **`SLOT_HIGH_DENSITY_ORGANIC_FUEL`** | Allocation: `90%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 10000], VOLATILITY: [3000, 8000]}
  * **`SLOT_BINDER_SLURRY`** | Allocation: `10%` mass value weight | Range Constraints: {PURITY: [1000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `STATION_BURN_UPDATE_TICKS` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `STEADY_HEAT_OUTPUT_CONSTANT` $\leftarrow$ Derived from input state via `THERMAL_RETENTION` matrix function.

----------------------------------------

### Category: Construction, Furnishings & World-Grid Objects

#### BLP_STRUCTURAL_FOUNDATION — Modular Structural Foundation / Floor Span / Roof Deck

* **Required Processing Skill:** `SKILL_MASONRY_CARPENTRY` (Threshold Floor: `1000` / 10,000)
* **Required Workbench Tags:** [`WB_CONSTRUCTION_STATION`]
* **Base Update Ticker Cost:** `1000 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_GRID_STRUCTURE_FLOOR`
* **Structural Component Slots Configuration:**
  * **`SLOT_WEIGHT_BEARING_CORE_FRAME`** | Allocation: `80%` mass value weight | Range Constraints: {STRUCT_DENSITY: [2500, 10000]}
  * **`SLOT_BASE_FOUNDATION_ANCHOR`** | Allocation: `20%` mass value weight | Range Constraints: {PURITY: [1000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `MAX_VERTICAL_STACK_LOAD` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `TILE_STABILITY_RATING` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_VERTICAL_BARRIER_SEGMENT — Modular Vertical Barrier Segment / Wall / Barricade

* **Required Processing Skill:** `SKILL_MASONRY_CARPENTRY` (Threshold Floor: `1200` / 10,000)
* **Required Workbench Tags:** [`WB_CONSTRUCTION_STATION`]
* **Base Update Ticker Cost:** `1200 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_GRID_STRUCTURE_WALL`
* **Structural Component Slots Configuration:**
  * **`SLOT_MAIN_STRUCTURAL_FACE_BLOCK`** | Allocation: `70%` mass value weight | Range Constraints: {STRUCT_DENSITY: [3000, 10000]}
  * **`SLOT_CORE_INTERLOCKING_TIE_LAYER`** | Allocation: `30%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [2000, 9000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `SIEGE_IMPACT_ABSORPTION` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `STRUCTURAL_HP_MAX` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `THERMAL_SHIELDING_INDEX` $\leftarrow$ Derived from input state via `THERMAL_RETENTION` matrix function.

----------------------------------------

#### BLP_APERTURE_FRAME — Modular Aperture Frame / Doorway / Window Gateway

* **Required Processing Skill:** `SKILL_MASONRY_CARPENTRY` (Threshold Floor: `1500` / 10,000)
* **Required Workbench Tags:** [`WB_CONSTRUCTION_STATION`]
* **Base Update Ticker Cost:** `900 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_GRID_STRUCTURE_APERTURE`
* **Structural Component Slots Configuration:**
  * **`SLOT_SWING_GATE_PANEL`** | Allocation: `65%` mass value weight | Range Constraints: {PURITY: [1000, 10000]}
  * **`SLOT_PIVOT_HINGE_FRAME_HARDWARE`** | Allocation: `35%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4500, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `BREACH_RESISTANCE_HP` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `OPERATIONAL_TICK_LAG` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_VERTICAL_LOAD_PILLAR — Modular Vertical Load Pillar / Structural Column

* **Required Processing Skill:** `SKILL_MASONRY_CARPENTRY` (Threshold Floor: `1100` / 10,000)
* **Required Workbench Tags:** [`WB_CONSTRUCTION_STATION`]
* **Base Update Ticker Cost:** `800 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_GRID_STRUCTURE_PILLAR`
* **Structural Component Slots Configuration:**
  * **`SLOT_HIGH_COMPRESSION_COLUMN_BODY`** | Allocation: `90%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 10000], ELASTICITY_MATRIX: [0, 5000]}
  * **`SLOT_CAPSTONE_MOUNT`** | Allocation: `10%` mass value weight | Range Constraints: {PURITY: [2000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `HORIZONTAL_SPAN_THRESHOLD_REACH` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `CEILING_COLLAPSE_SHIELD` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_STATIC_STORAGE_CHEST — Static Storage Chest / Secure Vault Box

* **Required Processing Skill:** `SKILL_FURNITURE_ASSEMBLY` (Threshold Floor: `800` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `600 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_CONTAINER_STATIC`
* **Structural Component Slots Configuration:**
  * **`SLOT_VOLUMETRIC_CASING_WALLS`** | Allocation: `80%` mass value weight | Range Constraints: {STRUCT_DENSITY: [2000, 10000]}
  * **`SLOT_SECURE_LOCKING_LATCH`** | Allocation: `20%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `STORAGE_VOLUME_SLOTS` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `CHEST_BREACH_DURABILITY` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_THERMAL_PRESERVATION_VESSEL — Thermal Preservation Vessel / Cooling Cryo Container / Ice Box

* **Required Processing Skill:** `SKILL_FURNITURE_ASSEMBLY` (Threshold Floor: `2000` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`, `WB_REACTION_TANK`]
* **Base Update Ticker Cost:** `1000 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_CONTAINER_THERMAL`
* **Structural Component Slots Configuration:**
  * **`SLOT_INSULATED_CONTAINMENT_CHAMBER`** | Allocation: `75%` mass value weight | Range Constraints: {THERMAL_RETENTION: [6000, 10000]}
  * **`SLOT_HERMETIC_SEAL_RING`** | Allocation: `25%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [5000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `INTERNAL_BIOLOGICAL_ROT_NEGATOR` $\leftarrow$ Derived from input state via `THERMAL_RETENTION` matrix function.
  * `FLUID_EVAPORATION_SHIELD_MULTIPLIER` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.

----------------------------------------

#### BLP_WORN_PACK_FRAME — Worn Pack Frame / Backpack / Satchel

* **Required Processing Skill:** `SKILL_SURVIVAL_GEAR` (Threshold Floor: `600` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `500 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_CONTAINER_WORN`
* **Structural Component Slots Configuration:**
  * **`SLOT_FLEXIBLE_BODY_EXPANSION_POUCH`** | Allocation: `70%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 10000]}
  * **`SLOT_RIGID_SHOULDER_SUPPORT_STRAPS`** | Allocation: `30%` mass value weight | Range Constraints: {STRUCT_DENSITY: [2000, 8000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `INVENTORY_GRID_CAPACITY_SLOTS` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `BACKPACK_WEIGHT_DISTRIBUTION_MOD` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_HORIZONTAL_REST_FRAME — Horizontal Rest Frame / Bed / Sleeping Cot / Bedroll

* **Required Processing Skill:** `SKILL_FURNITURE_ASSEMBLY` (Threshold Floor: `500` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `700 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_FURNITURE_REST`
* **Structural Component Slots Configuration:**
  * **`SLOT_STABLE_SUPPORT_BASE_CHASSIS`** | Allocation: `50%` mass value weight | Range Constraints: {STRUCT_DENSITY: [3000, 9000]}
  * **`SLOT_COMFORT_INSULATION_FILLER`** | Allocation: `50%` mass value weight | Range Constraints: {THERMAL_RETENTION: [4000, 10000], ELASTICITY_MATRIX: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `STAMINA_ENERGY_RECOVERY_RATE` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `ARCTIC_ENV_INSULATION_SHIELD` $\leftarrow$ Derived from input state via `THERMAL_RETENTION` matrix function.

----------------------------------------

#### BLP_VERTICAL_SUPPORT_SEATING — Vertical Support Seating / Chair / Stool

* **Required Processing Skill:** `SKILL_FURNITURE_ASSEMBLY` (Threshold Floor: `400` / 10,000)
* **Required Workbench Tags:** [`WB_CARPENTRY_BENCH`]
* **Base Update Ticker Cost:** `400 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_FURNITURE_SEAT`
* **Structural Component Slots Configuration:**
  * **`SLOT_SUPPORT_LEGS_AXLE`** | Allocation: `60%` mass value weight | Range Constraints: {STRUCT_DENSITY: [3000, 9000]}
  * **`SLOT_REST_PLATE_SEAT`** | Allocation: `40%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [2000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `STAMINA_TICK_RESTORE_PASSIVE` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `MAX_LOAD_CAPACITY_WEIGHT` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_SURFACE_WORK_PLATFORM — Surface Work Platform / Table / Counter Desk

* **Required Processing Skill:** `SKILL_FURNITURE_ASSEMBLY` (Threshold Floor: `600` / 10,000)
* **Required Workbench Tags:** [`WB_CARPENTRY_BENCH`]
* **Base Update Ticker Cost:** `600 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_FURNITURE_TABLE`
* **Structural Component Slots Configuration:**
  * **`SLOT_CLEAN_INTERACTION_GRID_PLANE`** | Allocation: `70%` mass value weight | Range Constraints: {PURITY: [2000, 10000]}
  * **`SLOT_STURDY_UNDER_BRACE`** | Allocation: `30%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `SURFACE_OBJECT_SLOTS_COUNT` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `TABLE_COLLAPSE_WEIGHT_MAX` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_RESONATING_INSTRUMENT — Resonating Musical Instrument / Lute / Flute / Drum

* **Required Processing Skill:** `SKILL_ARTISTIC_CRAFT` (Threshold Floor: `1500` / 10,000)
* **Required Workbench Tags:** [`WB_CARPENTRY_BENCH`, `WB_精密TIER_1`]
* **Base Update Ticker Cost:** `800 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_UTILITY_INSTRUMENT`
* **Structural Component Slots Configuration:**
  * **`SLOT_ACOUSTIC_RESONANCE_CHAMBER`** | Allocation: `65%` mass value weight | Range Constraints: {STRUCT_DENSITY: [2000, 6500], PURITY: [4000, 10000]}
  * **`SLOT_TENSION_CHORD_STRINGS_VENTS`** | Allocation: `35%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [7000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `ACOUSTIC_SOUND_FREQUENCY_GRID` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `PERFORMANCE_SKILL_EXP_GAIN` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `CULTURAL_VALUE_SCORE` $\leftarrow$ Derived from input state via `AETHER_SATURATION` matrix function.

----------------------------------------

#### BLP_STRETCHED_CANVAS_FRAME — Stretched Canvas Frame / Painting Canvas / Scroll

* **Required Processing Skill:** `SKILL_ARTISTIC_CRAFT` (Threshold Floor: `400` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `300 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_UTILITY_CANVAS`
* **Structural Component Slots Configuration:**
  * **`SLOT_ABSORPTION_TEXTURE_MATRIX`** | Allocation: `80%` mass value weight | Range Constraints: {PURITY: [3000, 10000], STRUCT_DENSITY: [0, 4000]}
  * **`SLOT_RIGID_STRETCH_STRETCHER_BARS`** | Allocation: `20%` mass value weight | Range Constraints: {STRUCT_DENSITY: [3000, 8000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `PIGMENT_ABSORPTION_LIMIT` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `AERATION_POROSITY_RATING` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.

----------------------------------------

#### BLP_VERTICAL_TRAVERSAL_STRUT — Vertical Traversal Strut / Ladder / Stair Assembly

* **Required Processing Skill:** `SKILL_MASONRY_CARPENTRY` (Threshold Floor: `500` / 10,000)
* **Required Workbench Tags:** [`WB_CONSTRUCTION_STATION`]
* **Base Update Ticker Cost:** `500 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_GRID_STRUCTURE_TRAVERSAL`
* **Structural Component Slots Configuration:**
  * **`SLOT_VERTICAL_STRINGERS_RAILS`** | Allocation: `60%` mass value weight | Range Constraints: {STRUCT_DENSITY: [3500, 10000]}
  * **`SLOT_HORIZONTAL_RUNGS_TREADS`** | Allocation: `40%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 10000], ELASTICITY_MATRIX: [2000, 8000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `CLIMB_SPEED_TICK_FACTOR` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.
  * `MAX_TRAVERSAL_WEIGHT_CEILING` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_FLOW_CONTROL_VALVE — Flow Control Valve / Hydraulic Shut-off Spigot

* **Required Processing Skill:** `SKILL_PRECISION_MECHANICS` (Threshold Floor: `2000` / 10,000)
* **Required Workbench Tags:** [`WB_精密TIER_1`, `WB_ANVIL`]
* **Base Update Ticker Cost:** `500 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_MECHANICAL_VALVE`
* **Structural Component Slots Configuration:**
  * **`SLOT_BINARY_SEALING_GATE_PLUG`** | Allocation: `50%` mass value weight | Range Constraints: {CORROSIVE_AXIS: [5000, 10000], STRUCT_DENSITY: [5000, 10000]}
  * **`SLOT_ACTUATION_ROTATION_HANDLE`** | Allocation: `50%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [3000, 9000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `PRESSURE_BURST_RATING` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `LEAK_PROOF_SEAL_VALIDITY` $\leftarrow$ Derived from input state via `CORROSIVE_AXIS` matrix function.

----------------------------------------

### Category: Components & Refinement

#### BLP_STAMPED_TOKEN_MATRIX — Stamped Token Matrix / Trade Coin / Currency Bar

* **Required Processing Skill:** `SKILL_SMELTING_METALLURGY` (Threshold Floor: `300` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`]
* **Base Update Ticker Cost:** `100 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_CURRENCY_TOKEN_STACK`
* **Structural Component Slots Configuration:**
  * **`SLOT_MINERAL_TOKEN_BLANK`** | Allocation: `100%` mass value weight | Range Constraints: {PURITY: [1000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `NPC_TRADE_VALUE_SCALAR` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `MAGICAL_HOARD_WORTH` $\leftarrow$ Derived from input state via `AETHER_SATURATION` matrix function.
  * `MELTDOWN_RESOURCE_MASS` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

### Category: Tools & Utility

#### BLP_CULINARY_COOKING_VESSEL — Culinary Cooking Vessel / Boiling Pot / Skillet

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `1100` / 10,000)
* **Required Workbench Tags:** [`WB_ANVIL`]
* **Base Update Ticker Cost:** `550 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_CONTAINMENT_HEAT`
* **Structural Component Slots Configuration:**
  * **`SLOT_CONTAINMENT_VESSEL_BOWL`** | Allocation: `80%` mass value weight | Range Constraints: {CORROSIVE_AXIS: [4500, 10000], THERMAL_RETENTION: [1000, 10000]}
  * **`SLOT_VESSEL_ISOLATED_HANDLE`** | Allocation: `20%` mass value weight | Range Constraints: {THERMAL_RETENTION: [6000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `THERMAL_CONDUCTIVITY_VELOCITY` $\leftarrow$ Derived from input state via `inverse(THERMAL_RETENTION)` matrix function.
  * `PURITY_LEACH_SHIELD` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `ACID_FOOD_STABILITY` $\leftarrow$ Derived from input state via `CORROSIVE_AXIS` matrix function.

----------------------------------------

#### BLP_CULINARY_ROASTING_SPIT — Culinary Roasting Spit / Skewer / Fire Grate

* **Required Processing Skill:** `SKILL_SURVIVAL_GEAR` (Threshold Floor: `300` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `200 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_COOKING_ATTACHMENT`
* **Structural Component Slots Configuration:**
  * **`SLOT_ROASTING_SHAFT_GRATE`** | Allocation: `100%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4000, 10000], VOLATILITY: [0, 2000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `SEARING_HEAT_TRANSFER_RATE` $\leftarrow$ Derived from input state via `inverse(THERMAL_RETENTION)` matrix function.
  * `FIRE_TILES_MOUNT_HP` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

### Category: Construction, Furnishings & World-Grid Objects

#### BLP_COMMERCIAL_DISPLAY_COUNTER — Commercial Display Counter / Shop Stall Table

* **Required Processing Skill:** `SKILL_FURNITURE_ASSEMBLY` (Threshold Floor: `1000` / 10,000)
* **Required Workbench Tags:** [`WB_CONSTRUCTION_STATION`]
* **Base Update Ticker Cost:** `900 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_GRID_STRUCTURE_MARKET`
* **Structural Component Slots Configuration:**
  * **`SLOT_MERCHANDISE_EXHIBIT_PLANE`** | Allocation: `70%` mass value weight | Range Constraints: {PURITY: [3000, 10000]}
  * **`SLOT_COIN_DROP_DRAWER`** | Allocation: `30%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `NPC_VISIBILITY_RADIUS_CELLS` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `AUTOMATED_TRADE_VALIDATION_TICKS` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.

----------------------------------------

### Category: Components & Refinement

#### BLP_AMORPHOUS_SLAG_RESIDUE — Amorphous Slag Residue / Charcoal / Ash / Smelt Waste

* **Required Processing Skill:** `SKILL_WASTE_RECOVERY` (Threshold Floor: `0` / 10,000)
* **Required Workbench Tags:** [`WB_ANY_STATION`]
* **Base Update Ticker Cost:** `100 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_MATERIAL_WASTE_SLAG`
* **Structural Component Slots Configuration:**
  * **`SLOT_UNSTABLE_REACTION_WASTE`** | Allocation: `100%` mass value weight | Range Constraints: {PURITY: [0, 3000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `FERTILIZER_BOTANICAL_CHEMICAL_SCORE` $\leftarrow$ Derived from input state via `TOXICITY` matrix function.
  * `CONSTRUCTION_FILLER_WEIGHT` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_ORGANIC_PUTREFACTION_MATRIX — Organic Putrefaction Matrix / Rotten Spoiled Compost

* **Required Processing Skill:** `SKILL_WASTE_RECOVERY` (Threshold Floor: `0` / 10,000)
* **Required Workbench Tags:** [`WB_ANY_STATION`]
* **Base Update Ticker Cost:** `100 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_MATERIAL_WASTE_COMPOST`
* **Structural Component Slots Configuration:**
  * **`SLOT_DECAYED_BIOLOGICAL_MASS`** | Allocation: `100%` mass value weight | Range Constraints: {PURITY: [0, 2000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `AGRICULTURAL_NITROGEN_BONUS_AXIS` $\leftarrow$ Derived from input state via `TOXICITY` matrix function.
  * `SOIL_HYDRATION_RETAIN_MODIFIER` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.

----------------------------------------

### Category: Tools & Utility

#### BLP_RIGID_FLUID_CONTAINER — Rigid Fluid Container / Glass Vial / Metal Flask / Bucket / Cask

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `500` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `400 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_FLUID_CONTAINER`
* **Structural Component Slots Configuration:**
  * **`SLOT_INTERNAL_FLUID_VESSEL_WALLS`** | Allocation: `85%` mass value weight | Range Constraints: {CORROSIVE_AXIS: [3000, 10000]}
  * **`SLOT_CONTAINMENT_STOPPER_CORK`** | Allocation: `15%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `VOLUMETRIC_FLUID_UNIT_MAX` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `CHEMICAL_REACTION_SHIELD` $\leftarrow$ Derived from input state via `CORROSIVE_AXIS` matrix function.
  * `BOIL_SAFE_THERMAL_LIMIT` $\leftarrow$ Derived from input state via `inverse(VOLATILITY)` matrix function.

----------------------------------------

### Category: Components & Refinement

#### BLP_RAW_BIOMASS_CARCASS — Raw Biomass Carcass / Unrefined Fauna Pelt Block

* **Required Processing Skill:** `SKILL_SURVIVAL_GEAR` (Threshold Floor: `0` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `200 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_MATERIAL_RAW_CARCASS`
* **Structural Component Slots Configuration:**
  * **`SLOT_RAW_INTEGRAL_ANIMAL_BODY`** | Allocation: `100%` mass value weight | Range Constraints: {PURITY: [0, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `MEAT_FAT_EXTRACTION_MAX` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `LEATHER_HIDE_SQUARE_UNITS` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `TOXIC_DECAY_VELOCITY` $\leftarrow$ Derived from input state via `TOXICITY` matrix function.

----------------------------------------

### Category: Tools & Utility

#### BLP_MORTAR_PESTLE_ASSEMBLY — Mortar & Pestle Pulverizer Assembly

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `600` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `300 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_PULVERIZATION`
* **Structural Component Slots Configuration:**
  * **`SLOT_CRUSHING_GRIND_BOWL`** | Allocation: `60%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5000, 10000]}
  * **`SLOT_PERCUSSIVE_GRIND_PESTLE`** | Allocation: `40%` mass value weight | Range Constraints: {STRUCT_DENSITY: [6000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `DUST_GRIND_TICK_SPEED` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `PULVERIZE_PURITY_RETENTION` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_ABSORBENT_SWAB_MATRIX — Absorbent Swab Matrix / Sponge / Fluid Clearer Wipe

* **Required Processing Skill:** `SKILL_SURVIVAL_GEAR` (Threshold Floor: `300` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `200 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_FLUID_MOP`
* **Structural Component Slots Configuration:**
  * **`SLOT_POROUS_SOAK_WIPE_CORE`** | Allocation: `100%` mass value weight | Range Constraints: {STRUCT_DENSITY: [0, 3000], ELASTICITY_MATRIX: [5000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `TILE_LIQUID_SOAK_CAPACITY` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `CORROSIVE_CHEMICAL_WIPE_SHIELD` $\leftarrow$ Derived from input state via `CORROSIVE_AXIS` matrix function.

----------------------------------------

#### BLP_SNARE_ENTANGLEMENT_DEVICE — Snare Entanglement Device / Fauna Trapping Net

* **Required Processing Skill:** `SKILL_SURVIVAL_GEAR` (Threshold Floor: `900` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `450 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_GRID_ENTITY_TRAP`
* **Structural Component Slots Configuration:**
  * **`SLOT_TRIGGER_ACTUATION_TRIPWIRE`** | Allocation: `30%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [5000, 10000]}
  * **`SLOT_SNAPBACK_SPRING_NET_CORD`** | Allocation: `70%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [7000, 10000], STRUCT_DENSITY: [2000, 7000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `CAPTURE_MASS_LOCKOUT_MAX` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `TRAP_TRIGGER_VALIDATE_RADIUS` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_MOBILE_FREIGHT_CHASSIS — Mobile Freight Chassis / Hauling Sled / Cart / Wheelbarrow

* **Required Processing Skill:** `SKILL_TOOL_MANUFACTURING` (Threshold Floor: `1600` / 10,000)
* **Required Workbench Tags:** [`WB_CARPENTRY_BENCH`, `WB_CONSTRUCTION_STATION`]
* **Base Update Ticker Cost:** `1200 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_VEHICLE_CARGO`
* **Structural Component Slots Configuration:**
  * **`SLOT_FREIGHT_CONTAINMENT_BOX_BED`** | Allocation: `55%` mass value weight | Range Constraints: {STRUCT_DENSITY: [2500, 8500]}
  * **`SLOT_ROTATION_WHEELS_RUNNERS`** | Allocation: `35%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 9500], STRUCT_DENSITY: [4000, 9000]}
  * **`SLOT_PULL_HANDLE_SHAFT_YOKE`** | Allocation: `10%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4500, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `MASS_HAUL_CAPACITY_SLOTS` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `TERRAIN_FRICTION_REDUCTION_MOD` $\leftarrow$ Derived from input state via `ELASTICITY_MATRIX` matrix function.
  * `CHASSIS_耐久DURABILITY` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

### Category: Components & Refinement

#### BLP_MECHANICAL_VALIDATION_KEY — Mechanical Validation Key / Lockbox Override Key

* **Required Processing Skill:** `SKILL_PRECISION_MECHANICS` (Threshold Floor: `1200` / 10,000)
* **Required Workbench Tags:** [`WB_精密TIER_1`]
* **Base Update Ticker Cost:** `250 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_REFINED_OVERRIDE_KEY`
* **Structural Component Slots Configuration:**
  * **`SLOT_KEY_BOW_HANDLE`** | Allocation: `30%` mass value weight | Range Constraints: {STRUCT_DENSITY: [3000, 10000]}
  * **`SLOT_KEY_BITTING_TEETH_SHAFT`** | Allocation: `70%` mass value weight | Range Constraints: {STRUCT_DENSITY: [5000, 10000], PURITY: [4500, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `BITTING_TOLERANCE_VALID` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `KEY_TORQUE_SNAP_LIMIT` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

### Category: Tools & Utility

#### BLP_COMBUSTION_IGNITER — Combustion Igniter / Flint & Steel / Spark Drill

* **Required Processing Skill:** `SKILL_SURVIVAL_GEAR` (Threshold Floor: `300` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `200 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_IGNITION`
* **Structural Component Slots Configuration:**
  * **`SLOT_PERCUSSIVE_STRIKER_STEEL`** | Allocation: `60%` mass value weight | Range Constraints: {STRUCT_DENSITY: [6000, 10000]}
  * **`SLOT_SPARK_FRACTURE_FLINT`** | Allocation: `40%` mass value weight | Range Constraints: {STRUCT_DENSITY: [7000, 10000], ELASTICITY_MATRIX: [0, 1500]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `THERMAL_SPIKE_LAUNCH_TICK` $\leftarrow$ Derived from input state via `VOLATILITY` matrix function.
  * `SPARK_SUCCESS_CHANCE` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

### Category: Construction, Furnishings & World-Grid Objects

#### BLP_THERMAL_INSULATED_PIPE — Thermal Insulated Pipe / Fluid Gutter Conduit

* **Required Processing Skill:** `SKILL_MASONRY_CARPENTRY` (Threshold Floor: `1400` / 10,000)
* **Required Workbench Tags:** [`WB_CONSTRUCTION_STATION`]
* **Base Update Ticker Cost:** `400 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_GRID_PIPE_CONDUIT`
* **Structural Component Slots Configuration:**
  * **`SLOT_FLOW_CHANNEL_CORE`** | Allocation: `75%` mass value weight | Range Constraints: {CORROSIVE_AXIS: [4000, 10000]}
  * **`SLOT_THERMAL_INSULATION_JACKET`** | Allocation: `25%` mass value weight | Range Constraints: {THERMAL_RETENTION: [5000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `FLUID_ROUTING_MASS_MAX` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `NETWORK_THERMAL_LOSS_CLAMP` $\leftarrow$ Derived from input state via `THERMAL_RETENTION` matrix function.

----------------------------------------

### Category: Tools & Utility

#### BLP_POROUS_FILTER_MEMBRANE — Porous Filter Membrane / Alchemical Liquid Strainer

* **Required Processing Skill:** `SKILL_ALCHEMICAL_REFINEMENT` (Threshold Floor: `900` / 10,000)
* **Required Workbench Tags:** [`WB_WORKBENCH`]
* **Base Update Ticker Cost:** `300 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_TOOL_ALCHEMICAL_STRAINER`
* **Structural Component Slots Configuration:**
  * **`SLOT_POROUS_SIFTER_MESH`** | Allocation: `100%` mass value weight | Range Constraints: {STRUCT_DENSITY: [1000, 5000], PURITY: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `IMPURITY_EXTRACTION_RATING` $\leftarrow$ Derived from input state via `PURITY` matrix function.
  * `LIQUID_FLOW_THROUGH_RATE` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.

----------------------------------------

### Category: Construction, Furnishings & World-Grid Objects

#### BLP_THERMAL_REACTION_FORGE — Thermal Reaction Forge / Melting Furnace Station Frame

* **Required Processing Skill:** `SKILL_MASONRY_CARPENTRY` (Threshold Floor: `1500` / 10,000)
* **Required Workbench Tags:** [`WB_CONSTRUCTION_STATION`]
* **Base Update Ticker Cost:** `2000 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_STATIC_STATION_FORGE`
* **Structural Component Slots Configuration:**
  * **`SLOT_THERMAL_HEARTH_BRICKS`** | Allocation: `80%` mass value weight | Range Constraints: {THERMAL_RETENTION: [6500, 10000], STRUCT_DENSITY: [5000, 10000]}
  * **`SLOT_AIR_FORCED_BELLOWS_LINING`** | Allocation: `20%` mass value weight | Range Constraints: {ELASTICITY_MATRIX: [4000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `MAX_TEMPERATURE_TICK_CEILING` $\leftarrow$ Derived from input state via `THERMAL_RETENTION` matrix function.
  * `STATION_FUSION_MELTDOWN_SHIELD` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.

----------------------------------------

#### BLP_KINETIC_IMPACT_STATION — Kinetic Impact Station / Master Smithing Anvil Frame

* **Required Processing Skill:** `SKILL_MASONRY_CARPENTRY` (Threshold Floor: `1500` / 10,000)
* **Required Workbench Tags:** [`WB_CONSTRUCTION_STATION`]
* **Base Update Ticker Cost:** `1800 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_STATIC_STATION_ANVIL`
* **Structural Component Slots Configuration:**
  * **`SLOT_HEAVY_IMPACT_HORN_BLOCK`** | Allocation: `85%` mass value weight | Range Constraints: {STRUCT_DENSITY: [7000, 10000], VOLATILITY: [0, 2000]}
  * **`SLOT_MOUNT_FOUNDATION_BED`** | Allocation: `15%` mass value weight | Range Constraints: {STRUCT_DENSITY: [4500, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `MAX_SHAPING_CAPABILITY_FACTOR` $\leftarrow$ Derived from input state via `STRUCT_DENSITY` matrix function.
  * `REFLECTED_REBOUND_STABILITY` $\leftarrow$ Derived from input state via `PURITY` matrix function.

----------------------------------------

#### BLP_FARMING_PLOT — Farming Plot Box / Greenhouse Agricultural Bed

* **Required Processing Skill:** `SKILL_AGRICULTURAL_CRAFT` (Threshold Floor: `800` / 10,000)
* **Required Workbench Tags:** [`WB_CONSTRUCTION_STATION`]
* **Base Update Ticker Cost:** `800 Ticks`
* **Runtime Output Type Class:** `ITEM_TYPE_STATIC_STATION_FARM`
* **Structural Component Slots Configuration:**
  * **`SLOT_SUBSTRATE_NUTRIENT_BASE`** | Allocation: `70%` mass value weight | Range Constraints: {TOXICITY: [0, 3000]}
  * **`SLOT_CONTAINMENT_RIGID_BORDER`** | Allocation: `30%` mass value weight | Range Constraints: {STRUCT_DENSITY: [3000, 10000]}
* **Mathematical Gameplay Stat Mapping Translators:**
  * `FLORA_MUTATION_VELOCITY_TICK` $\leftarrow$ Derived from input state via `AETHER_SATURATION` matrix function.
  * `ROOT_HYDRATION_EFFICIENCY` $\leftarrow$ Derived from input state via `inverse(STRUCT_DENSITY)` matrix function.

----------------------------------------
