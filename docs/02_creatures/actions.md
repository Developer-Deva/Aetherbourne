# Actions System

**Description:** Reusable, modular creature actions that bridge **Needs → Goals → Action → Events → Outcomes**

**Last Updated:** 2026-06-21

---

# Overview

Actions are the executable layer of the creature simulation.

They translate:
- **Needs/urgency** (from `needs.md`) into **Goals** (planner output)
- **Goals** into **Actions** (what the creature does)
- **Actions** into **Events/Outcomes** (what the world records)
- **Events** into **Emotions → Memories → Personality drift** (from the creature pipeline)

Actions **do not modify personality directly**.

Instead:

```text
Action
↓ (preconditions)
Execute
↓ (outcomes)
Event(s)
↓
Emotion
↓
Memory
↓
Personality drift
```

---

# Design Goals

1. **Simple and clear**: an action template should be readable in seconds.
2. **Versatile**: one action can support variants (tool/target/difficulty) without rewriting everything.
3. **Consistent with events**: actions emit standardized event categories + scales.
4. **Data-driven**: the same action definition should drive AI planning and simulation execution.

---

# Core Concepts

## ActionCategory
Group actions into domains so the planner can reason globally.

```csharp
public enum ActionCategory
{
    Survival,      // food/water/health maintenance
    Work,          // labor/farming/building
    Exploration,   // scouting/learning/locating
    Gathering,     // flora/minerals resources
    Crafting,      // tool/item production
    Combat,        // attack/defend/fight
    Escape,        // flee/evade
    Social,        // talk/share/mentor
    Economic,      // trade/theft/assist exchanges
    Rest,          // sleep/rest/heal-by-time
    Culture,       // rituals/festivals/ceremonies
    Magic          // spellcasting
}
```
```csharp
public enum AltActionCategory
{
  Movement,        // walk/run/jump/climb/carry/crouch/swim
  Interaction,     // inspect/pick up/use/speak/trade/fight
  Social,          // befriend/persuade/lie/intimidate/bond/appease/rally/reproduce/flee/steal/give/observe/conceal 
  Trade,           // haggle/deliver/manage
  Combat,          // attack/defend/dodge/equip or swap/feint/counter
  Tactical,        // wait/prepare/distract/camo/ambush/track/strageize/scout
  Utility,         // craft/heal/rest/signal
  Construction,    // build/repair/survey/excavate/fortify/decorate
  Resource,        // plant/harvest/tame/hunt/fish/mine/gather/trap/preserve
  Crafting,        // forge/carve/weave/tinker/refine/assemble
  Consumable,      // cook/bake/brew
  Daily,           // clean/organize/care/teach
  Magic,           // mix/cast spell/enchant/divine
  Culture,         // preform/write/study/paint
  Cognitive        // desire/remember/decide/plan/forget/learn
}

## Goal Link
Each action declares which needs/goals it can satisfy.

Actions should not “decide urgency” (that’s the needs arbitration). Instead, they declare compatibility:

- **Consumes or restores**: Hunger/Thirst/Energy/Health/Belonging/Purpose/Fulfillment
- **Advances**: Exploration discoveries; crafting progress; relationship progress

---

# Standard Action Definition Template

Every action definition should follow the same structure.

## 1) Purpose
- One short paragraph describing what the creature is trying to do.
- Which needs/goals it is intended to satisfy.

## 2) Requirements
Two types:

### MustExist (world facts)
- Target availability/type
- Terrain/biome/water/hazard thresholds
- Line-of-sight or adjacency rules

### MustHave (actor capabilities/resources)
- Relevant skills thresholds
- Tools required (or allowed)
- Minimum relationships (for social/economic actions)
- Minimum current health/energy to attempt

## 3) Results
Must specify:

### Outcomes on Success
- State changes (health/energy/hunger/etc.)
- Inventory changes (+food, −tool durability)
- Relationship changes (trust, respect)
- Discovery/knowledge seeds
- Hazard exposure or mitigation

### Outcomes on Failure
- What partial progress happens (if any)
- Wasted time/costs
- Injury/negative state changes (if applicable)
- Optional fear/anger emotional drivers via event emission

### Events emitted
List event categories + recommended visibility and scale.

---

# Action Lifecycle (Execution Model)

Actions run through a common lifecycle so they plug into the event/emotion/memory pipeline.

```text
Action Start
↓ Precondition checks
↓ Plan parameters
   (target, tool, route, timing)
↓ Execute (duration + movement + consumes)
↓ Resolve (success/failure)
↓ Apply Outcomes (state/inventory/relationships)
↓ Emit Event(s)
↓ Finish / cooldown / next decision
```

## Action duration and tick model
To keep docs simple, define actions in one of these execution styles:

- **Instant**: single resolution (share a piece of food, drink from a nearby source)
- **Timed**: duration-based (forage/mine/build/craft)
- **Ongoing**: continues while condition remains (harvest until depleted, escort until destination)

---

# Standard Outcome Tags

To keep actions versatile without huge prose, outcomes should use a small vocabulary.

## StateChange
- **Health Δ**
- **Energy Δ**
- **Stamina Δ**
- **Hunger Δ**
- **Thirst Δ**
- **Bladder discomfort / urgency Δ**

## InventoryChange
- **+Food / −Food**
- **+Flora / +Minerals**
- **−ToolDurability**
- **+Parts / +Materials**

## RelationshipChange
- **Trust Δ** (relationship-specific)
- **Respect Δ**

## Knowledge / Discovery
- **MemorySeed** strength/severity band (e.g. 20..60)
- **LearnedFact** / **MapPin** / **EncounterTag**

## Hazard Exposure
- Infection/poison/radiation/curse exposure checks
- Injury risks (falls, bites, heat, cold)

---

# Standard Event Emission Rules

Actions should emit event(s) rather than directly causing emotional change.

## Recommended mapping
- **Gather / Hunt / Mine / Build** → usually **Biological**, **Environmental**, or **Economic** events
- **Attack / Defend** → **Conflict** events
- **Share / Socialize / Mentor** → **Social** events
- **Rest / Sleep / Heal** → **Personal** + **Biological** (injury recovery) events
- **Explore / Discover** → **Discovery** events

## Scale and severity
Use these ranges consistently:
- **Severity**: `0..100` (minor to catastrophic)
- **Scale**:
  - Individual / Family / Group / Settlement / Regional / Global

If an action has failure that causes injury, severity should skew moderate:
- typical failure injury: **15..55**

---

# Action Variants (Versatility)

Instead of redefining actions, use variants as parameters.

Each action supports:
- **ToolVariant** (barehand / hand-tool / specialized tool)
- **TargetVariant** (deer/fish/herb/ore/ruin node)
- **DifficultyVariant** (safe/normal/dangerous/cursed)

The action template remains identical; only requirements/outcomes/event severity bands shift.

---

# Core Action Set (Start Here)

Below are initial actions designed to cover most gameplay loops.

## 1) Gather (Flora/Minerals)

### Purpose
Collect nearby resource nodes (plants or geological materials) for food, crafting, alchemy, or construction.

Supports:
- Hunger/Thirst (if food/water flora)
- Work and economic goals (materials)
- Discovery (learning resource locations)

### Requirements
**MustExist**
- Target resource node within interaction range
- Target type is compatible with allowed gather modes (flora/minerals)

**MustHave**
- Dexterity + relevant tool use skill threshold
- Appropriate tool (optional for “basic” gather; required for quality mining/cutting)

### Results
**Success outcomes**
- `+InventoryChange`: harvested flora/minerals (quantity depends on tool + skill)
- `−ToolDurability` (if tool used)
- `MemorySeed`: mild discovery memory (severity band **10..35**)
- Optional hazard exposure check (poisonous spines, contaminated deposit)

**Failure outcomes**
- `−Energy` / `−Stamina` (small)
- `MemorySeed` optional (if failure is costly): **15..40**
- Optional injury if target is hazardous: `Health −Δ`

**Events emitted**
- Category: **Economic** (trade value context) and/or **Environmental** (hazard exposure)
- Scale: **Individual**
- Severity: **0..60** (higher when injury/hazard)

---

## 2) Forage (Seasonal Gathering)

### Purpose
Search and collect small edible or useful items from the environment without a fixed node.

Supports:
- Hunger
- Thirst (if water sources exist)
- Exploration

### Requirements
**MustExist**
- Forage-able conditions in the current biome/season
- Suitable terrain (not fully hazardous unless specialized)

**MustHave**
- Curiosity/Perception threshold for spotting targets
- Low tool needs (hand gather) or optional simple tools

### Results
**Success outcomes**
- `+Food/−Food` inventory depending on consumption plans
- `Energy −Δ` (activity cost)
- `MemorySeed`: “where to forage next time” (severity band **10..40**)

**Failure outcomes**
- `−Energy` and `Hunger may remain high`
- Potential mild injury if forage in hostile hazard layers

**Events emitted**
- Category: **Discovery** (location/biome knowledge)
- Category: **Biological** (predation/harassment if encountered)
- Scale: **Individual**

---

## 3) Drink (From Water Source)

### Purpose
Consume water to reduce thirst (and optionally improve recovery if safe and clean enough).

### Requirements
**MustExist**
- WaterFeature present (stream/lake/spring/oasis/etc.)
- Safety check: hazard layer or contamination may require “safe drink” variant

**MustHave**
- Enough energy to perform drinking action

### Results
**Success outcomes**
- `Thirst Δ −` (amount depends on water quality)
- `Energy` small recovery if clean water
- Optional `MemorySeed`: safe source remembered (severity **5..25**)

**Failure outcomes**
- `Thirst remains high`
- Possible `Health −Δ` if contaminated/miasmic

**Events emitted**
- Category: **Environmental** (contamination exposure) and/or **Personal**
- Scale: **Individual**
- Severity: **0..70** (higher if poisoning)

---

## 4) Hunt (Predation/Chase/Capture)

### Purpose
Chase, track, and capture prey for food or resources.

### Requirements
**MustExist**
- Prey detected within tracking radius
- Pathing possible (terrain/hazard constraints)

**MustHave**
- Perception + stamina
- Combat skill threshold (for active hunting)
- Tool variant optional (trap/spear/club)

### Results
**Success outcomes**
- `+InventoryChange`: meat/edibles (quantity depends on success margin)
- `Hunger Δ −`
- Possible injury from struggle (`Health −Δ`)
- `MemorySeed`: “effective strategy” (severity **20..65**)

**Failure outcomes**
- `Energy −Δ`, `Stamina −Δ`
- Optional `Fear/anger` event trigger via fight interruption

**Events emitted**
- Category: **Conflict** (if fight occurs)
- Category: **Biological** (predation result)
- Scale: **Individual**
- Severity: **0..85**

---

## 5) Mine (Geological Resource Extraction)

### Purpose
Extract minerals/ores from geological nodes.

### Requirements
**MustExist**
- Ore node within interaction range
- Terrain supports safe access (depth/hazard constraints)

**MustHave**
- Tool quality and relevant mining skill threshold

### Results
**Success outcomes**
- `+InventoryChange`: minerals/ore fragments
- `−ToolDurability`
- `MemorySeed`: efficient vein memory (severity **10..40**)
- Optional hazard exposure: radiation/curse/volatile rock

**Failure outcomes**
- `−Energy`, `Health −Δ` if rock failure
- Possible cave-in trigger (if unstable tectonic activity)

**Events emitted**
- Category: **Environmental** (hazard/cave-in)
- Category: **Economic** (resource production)
- Scale: **Individual**
- Severity: **0..90**

---

## 6) Rest (Recover by Time)

### Purpose
Recover energy and reduce fatigue.

### Requirements
**MustExist**
- Safe resting conditions (hazard layer check / threat proximity)

**MustHave**
- None beyond basic survival ability

### Results
**Success outcomes**
- `Energy Δ +`
- `Stamina Δ +`
- `MemorySeed` minimal (severity **0..10**)

**Failure outcomes**
- Rest interrupted: `Energy gain reduced`
- Optional exposure to nearby conflict events

**Events emitted**
- Category: **Personal**
- Scale: **Individual**
- Severity: usually low **0..25**

---

## 7) Heal (Medicine / Care)

### Purpose
Apply medicine, bandages, or rest to improve health.

### Requirements
**MustExist**
- Injured state present OR preventive care goal
- Medicine resource available OR basic bandaging possible

**MustHave**
- Medicinal skill threshold (or tool variant)
- Optional relationship requirement for caring (social vs professional)

### Results
**Success outcomes**
- `Health Δ +` (amount depends on medicine potency)
- Possible removal/mitigation of poison debuffs (if applicable)
- `MemorySeed`: “I was helped” (severity **15..55**)

**Failure outcomes**
- Less effective healing
- Possible infection worsening (if medicine quality poor or contamination)

**Events emitted**
- Category: **Biological** (recovery) and **Social** (if by another creature)
- Scale: **Individual**

---

## 8) Explore (Scout / Map / Discover)

### Purpose
Move through unknown or partially known territory to find resources, hazards, routes, and settlements.

### Requirements
**MustExist**
- Unscouted tiles or interest points

**MustHave**
- Energy > minimum
- Perception threshold for meaningful discoveries

### Results
**Success outcomes**
- `MemorySeed`: discovery memories (severity **10..45**)
- Possible `Action outcome`: mark route, unlock knowledge nodes

**Failure outcomes**
- Missed opportunities
- If hazard encountered: `Health −Δ` or `Energy −Δ`

**Events emitted**
- Category: **Discovery**
- Category: **Environmental** (if hazards encountered)
- Scale: **Individual**
- Severity: **0..80**

---

## 9) Trade (Exchange Resources)

### Purpose
Exchange items/resources with another entity or settlement.

### Requirements
**MustExist**
- Trade partner available
- Market availability (if you model it)

**MustHave**
- Relationship trust threshold OR social influence skill
- Items in inventory

### Results
**Success outcomes**
- `InventoryChange`: trade swap
- `RelationshipChange`: trust/respect Δ
- `MemorySeed`: “deal went well” (severity **10..50**)

**Failure outcomes**
- Transaction aborted
- Possible social conflict event if attempted deceit/stealing

**Events emitted**
- Category: **Economic** and **Social**
- Scale: **Settlement** or **Individual** (depending on partner)
- Severity: **0..70**

---

## 10) Socialize (Share / Talk / Mentor)

### Purpose
Interact to improve belonging, trust, and cooperative bonds.

### Requirements
**MustExist**
- Another creature (or group member) available
- Social context permits interaction

**MustHave**
- Minimum energy
- Personality/social skill influence threshold

### Results
**Success outcomes**
- `RelationshipChange`: trust/respect Δ
- `Belonging` maintenance indirectly via relationship system
- `MemorySeed`: shared experience severity **10..55**

**Failure outcomes**
- Relationship change negative (miscommunication)
- Possible conflict event in high threat context

**Events emitted**
- Category: **Social**
- Scale: **Family/Group/Settlement** depending on participants
- Severity: **0..75**

---

## 11) Attack (Combat Resolution Wrapper)

### Purpose
Perform an aggressive action intended to injure, disable, or deter a target.

### Requirements
**MustExist**
- Target within combat range
- Combat conditions valid (line-of-sight / adjacency)

**MustHave**
- Combat skill threshold
- Weapon/tool variant availability
- Health/energy minimum

### Results
**Success outcomes**
- `Health −Δ` on target
- `Stamina −Δ` attacker
- Optional status effects (if you model them later)
- `MemorySeed` for both sides based on severity **20..90**

**Failure outcomes**
- Attacker injury risk
- Possible return aggression event

**Events emitted**
- Category: **Conflict**
- Scale: **Individual/Group**
- Severity: **10..100**

---

## 12) Flee (Escape / Evade)

### Purpose
Avoid danger by disengaging and moving toward safety.

### Requirements
**MustExist**
- Threat source present
- Escape route exists (pathing)

**MustHave**
- Energy > minimum
- Fear/low threat tolerance interacts via emotion system (planner picks flee)

### Results
**Success outcomes**
- `Energy −Δ` but reduces future injury risk
- Optional `MemorySeed`: survival/trauma (severity **15..80**)

**Failure outcomes**
- Panic risk: `Health −Δ`
- Potential conflict escalation events

**Events emitted**
- Category: **Conflict** and/or **Environmental**
- Scale: **Individual**
- Severity: **0..95**

---

# Extending the Action Library

To add actions without breaking clarity:
1. Start with the **template** sections: Purpose → Requirements → Results.
2. Use **variants** for tool/target/difficulty.
3. Keep outcomes tagged and consistent.
4. Emit events using the same severity/scale approach from `events.md`.

---

# Consistency Checklist

When writing a new action, confirm:
- [ ] It does not directly modify personality
- [ ] It declares clear preconditions
- [ ] It defines success and failure outcomes
- [ ] It emits one or more event(s)
- [ ] Outcomes are expressible with outcome tags
- [ ] It can be parameterized via variants

---

## Design Philosophy

The actions system is designed to stay modular, data-driven, and aligned with the event/emotion pipeline.

## Core Concepts

- Action definitions use Purpose, Requirements, and Results
- Outcomes are expressed with standardized tags
- Actions emit events rather than directly modifying personality

## Implementation / Notes

* Keep new actions consistent with existing templates and variant patterns.

