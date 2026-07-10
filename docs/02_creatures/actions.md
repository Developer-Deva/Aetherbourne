# Actions

**Description:**  
Defines the primitive action system used by creatures to interact with themselves, other creatures, objects, and the environment.

**Purpose:**  
Primitive actions are the smallest meaningful units of interaction within Aetherbourne.

Creatures do not directly perform goals. They perform behaviors, and behaviors are constructed from primitive actions.

Actions describe **what happens**.

Behaviors describe **why it happens**.

Events describe **what changes as a result**.

---

## Action Philosophy

Aetherbourne separates intent from execution.

A creature does not perform:

- Gather
- Hunt
- Trade
- Teach
- Court
- Build
- Steal

These are behaviors.

Instead, behaviors are composed from primitive actions.

Example:

    Need:
    Hunger

    Goal:
    Acquire Food

    Behavior:
    Gather Berries

    Primitive Actions:
    Move
    Look
    Transfer
    Consume

    Results:
    Food acquired
    Hunger reduced

    Events:
    Memory Created
    Relationship Changed

---

## Action Hierarchy

    Need
    ↓
    Goal
    ↓
    Behavior
    ↓
    Primitive Action
    ↓
    Effect
    ↓
    Event / Memory / State Change

---

## Primitive Action Definition

Every primitive action follows a shared schema.

### Action Schema

```rust
pub struct ActionDefinition {
    pub id: ActionId,
    pub name: String,
    pub category: ActionCategory,
    pub description: String,

    pub targets: Vec<TargetType>,

    pub requirements: Vec<Requirement>,
    pub costs: Vec<ActionCost>,
    pub effects: Vec<Effect>,

    pub tags: Vec<ActionTag>,
}
````

Equivalent C## structure:

```csharp
public class ActionDefinition
{
    public ActionId Id { get; set; }
    public string Name { get; set; }
    public ActionCategory Category { get; set; }
    public string Description { get; set; }

    public List<TargetType> Targets { get; set; }

    public List<Requirement> Requirements { get; set; }
    public List<ActionCost> Costs { get; set; }
    public List<Effect> Effects { get; set; }

    public List<ActionTag> Tags { get; set; }
}
```

---

## Action Instance

An Action Definition describes what an action is.

An Action Instance represents a creature currently performing an action.

Example:

"A creature is transferring an apple to another creature."

Rust:

```rust
pub struct ActionInstance {
    pub action: ActionId,
    pub actor: EntityId,
    pub target: Option<EntityId>,

    pub progress: f32,
    pub state: ActionState,
}
```

---

## Action Categories

---

## Movement / Body

**Description:**
Actions that change a creature's position, posture, or physical state.

### Move

Changes a creature's location.

---

### Turn

Changes facing direction.

---

### Stop

Ends movement.

---

### Sit

Changes the creature into a seated posture.

---

### Stand

Returns the creature to an upright posture.

---

### Lie Down

Changes the creature into a prone or resting posture.

---

### Jump

Changes vertical position through forceful movement.

---

### Climb

Allows movement across climbable surfaces.

---

### Crawl

Allows movement while maintaining a low posture.

---

### Swim

Allows movement through liquids.

---

### Fly

Allows movement through air for capable creatures.

---

## Temporal

**Description:**
Actions that intentionally allow time to pass or maintain a condition.

### Wait

Allows time to pass without another major action.

Examples:

- Waiting for prey
- Waiting for another creature
- Waiting for a process to complete
- Guarding

---

### Rest

Allows recovery.

Examples:

- Restore stamina
- Reduce fatigue
- Reduce stress

---

## Perception

**Description:**
Actions that gather information from the environment.

### Look

Gathers visual information.

---

### Listen

Gathers auditory information.

---

### Smell

Gathers chemical information.

---

### Taste

Gathers information through consumption or contact.

---

### Feel

Gathers information through physical contact.

---

## Manipulation

**Description:**
Actions that alter possession, position, or force relationships with objects.

### Transfer

Moves an object or entity between locations or owners.

Examples:

    Ground → Creature
    Pick up

    Creature → Ground
    Place

    Creature → Container
    Store

    Container → Creature
    Retrieve

    Creature → Creature
    Give / Trade / Feed

Transfer replaces:

- Pick Up
- Place
- Drop
- Give
- Receive
- Store
- Deliver

---

### Hold

Maintains control over an object or entity.

Examples:

- Holding a tool
- Holding an infant
- Holding a rope

---

### Release

Stops maintaining control.

Examples:

- Let go
- Drop
- Release restraint

---

### Throw

Transfers an object using force and direction.

---

### Push

Applies force away from the actor.

Examples:

- Move object
- Close mechanism
- Push creature

---

### Pull

Applies force toward the actor.

Examples:

- Move object
- Open mechanism
- Draw object closer

---

## World Interaction

**Description:**
Actions that directly affect objects, materials, and environmental systems.

---

### Touch

Creates physical contact.

---

### Use

Uses an object, tool, or environmental feature.

Examples:

    Use(Shovel, Ground)
    → Dig

    Use(Pickaxe, Rock)
    → Mine

    Use(Knife, Plant)
    → Cut / Harvest

    Use(Hammer, Object)
    → Repair

The result depends on:

- Tool properties
- Material properties
- Object state

---

### Consume

Consumes a resource.

Examples:

- Eating food
- Drinking water
- Taking medicine

---

### Strike

Applies force to a target.

Examples:

- Hit creature
- Shape material
- Damage object

Repeated strikes may create events:

    Strike(Object)
     ↓
    Durability Reduced
     ↓
    Object Breaks

---

### Repair

Restores an object's condition.

---

### Clean

Removes unwanted substances or conditions.

---

### Activate

Changes something into an active state.

Examples:

- Ignite fire
- Start machine
- Trigger mechanism

---

### Deactivate

Changes something into an inactive state.

Examples:

- Put out fire
- Stop machine
- Disable mechanism

---

## Equipment

**Description:**
Actions that modify a creature's equipped state.

---

### Equip

Moves an item into an active equipment state.

Includes:

- Wear
- Draw weapon
- Ready tool

---

### Unequip

Removes an item from an active equipment state.

Includes:

- Remove
- Sheath
- Put away

---

### Swap

Changes one equipped item for another.

---

## Communication

**Description:**
Actions that intentionally exchange information.

---

### Speak

Communicates through language or vocalization.

---

### Gesture

Communicates through visual movement or signals.

---

### Call

Creates communication intended to attract attention.

---

## Defense

**Description:**
Actions that reduce, avoid, or redirect harmful interactions.

---

### Block

Absorbs or prevents incoming force.

---

### Parry

Redirects incoming force.

---

## Biological

**Description:**
Actions directly related to reproduction.

---

### Mate

Initiates reproduction between compatible creatures.

---

## Cognitive Systems

Cognitive processes are not primitive actions.

They are internal systems that influence decision-making.

Examples:

- Learning
- Memory
- Recall
- Planning
- Reasoning
- Problem Solving

---

## Behaviors

Behaviors are higher-level combinations of primitive actions.

Examples:

### Gather

    Move
    Look
    Transfer

---

### Mine

    Move
    Use(Pickaxe, Resource)
    Transfer

---

### Deliver

    Transfer
    Move
    Transfer

---

### Hunt

    Look
    Track
    Move
    Strike
    Consume

---

### Teach

    Speak
    Gesture
    Observe

---

### Court

    Move
    Speak
    Gesture
    Touch
    Transfer

---

## Events

Events are state changes caused by actions and behaviors.

Examples:

- Conception
- Pregnancy Begins
- Birth
- Egg Laid
- Hatch
- Skill Learned
- Memory Created
- Relationship Changed
- Item Inherited

---

## Action Categories Enum

Rust:

```rust
pub enum ActionCategory {
    Movement,
    Temporal,
    Perception,
    Manipulation,
    WorldInteraction,
    Equipment,
    Communication,
    Defense,
    Biological,
}
```

C#:

```csharp
public enum ActionCategory
{
    Movement,
    Temporal,
    Perception,
    Manipulation,
    WorldInteraction,
    Equipment,
    Communication,
    Defense,
    Biological
}
```

---

## Design Rules

A primitive action should answer:

> "What physical or mechanical change occurs?"

A behavior should answer:

> "Why is the creature doing this?"

An event should answer:

> "What happened because of it?"

If a concept describes a goal, intention, or social meaning, it should not be a primitive action.

---

## Canonical Consolidation Notes

Material from the previous staged action planning note was merged here, making this file the canonical home for the system. During implementation, prefer the contracts and terminology in this file over deleted staging notes.

## Merged Legacy Planning Content

## Action System — Atomic World Operations

**Last Updated:** 2026-06-26 (plus later Gemini formatting)

### Overview
The Action System is the execution layer of creature behavior.

- Actions are the smallest meaningful units of intentional activity.
- Actions directly affect the world.
- Actions do not decide what the creature wants or what strategy it follows.

They only execute the strategy selected by the Behavior System.

### Simulation Role
Answers: **“What is the creature doing right now?”**

Examples:
- Move
- Speak
- Attack
- Eat
- Craft
- Give

### Hierarchy
Needs → Motivations → Personality → Relationships → Emotions → Behaviors → Actions → World Events

### Core Design Principles
- **Atomic:** represent a single meaningful operation
- **Reusable:** the same action can be used by many behaviors
- **Context-free:** actions contain no intrinsic intent; intent is supplied by the behavior
- **Events produced:** actions modify the world by generating events consumed by Emotion, Relationship, Memory, and World simulation

### Action Lifecycle
Select Action → Validate Requirements → Begin Action → Progress Action (Tick loop) → Complete or Fail → Generate Events

### Data Model
```csharp
public class Action
{
    public ActionType Type;

    public Entity Actor;
    public Entity Target;

    public float Progress;
    public float Duration;

    public bool IsComplete;
    public bool HasFailed;
}
```

### Action States
- Queued: waiting
- Active: executing
- Completed: successful
- Failed: could not complete due to constraints
- Interrupted: stopped mid-execution

### Action Properties
Each action defines:

- Duration (s/hours)
- Requirements (prerequisites)
- Costs (resources consumed)
- Failure conditions (environment invalidation)
- Outputs (what events get published)

### Action Categories (As described)
#### Survival
- Eat
- Drink
- Sleep
- Heal

#### Movement
- Move
- Follow
- Flee
- Carry

#### Exploration & Resource
- Observe
- Inspect
- Search
- Extract
- Obtain
- Discard / Store / Retrieve

#### Crafting
- Craft
- Repair
- Refine
- Disassemble

#### Economic
- Buy
- Sell
- Trade

#### Social
- Speak
- Request
- Give
- Help
- Negotiate
- Praise
- Apologize
- Teach
- Bond
- Partner / Mate

#### Conflict
- Challenge
- Threaten
- Attack
- Defend
- Grapple
- Guard
- Retreat

#### Equipment & Response
- Equip
- Unequip
- Use
- Accept / Reject / Ignore

### Action Selection Rule
Actions are chosen by the active behavior.

Behaviors never select themselves.

### Action Outputs
Actions publish results:

```csharp
public class ActionResult
{
    public ActionType Type;
    public bool Success;

    // derived from actor stats
    public float Quality;
    public float Duration;

    public List<Event> EventsGenerated;
}
```

### Consuming Systems
- Emotion System: uses action results → generate emotional responses
- Relationship System: uses social actions → update social bonds
- Memory System: uses action outcomes → create episodic memories
- Behavior System: uses action success/failure → continue or change strategy

### Design Goals
- ultimate reusability
- context isolation
- massive scalability
- keep actions algorithmic and atomic
- remain easy to extend with new content
