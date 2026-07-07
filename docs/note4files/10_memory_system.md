# Memory System — Storage, Retrieval, Reinforcement, Decay, Personality Influence

**Last Updated:** 2026-06-27

## Overview
The Memory System stores significant experiences and learned information.

- Memory serves as personal history.
- Memories influence:
  - decision making
  - emotional appraisal
  - relationship formation
  - skill development
  - knowledge acquisition
  - personality drift
  - goal selection
  - social behavior

Memory is both an output of experiences and an input to future cognitive systems.

## Simulation Role
Answers: **“What has happened to me before?”**

## System Hierarchy
Perception ↓ Event ↓ Emotion appraisal ↓ Memory gate ↓ Storage ↓ Retrieval ↓ Decision making ↓ Behavior ↓ Actions ↓ New experiences

## Design Philosophy
- Memory is **selective**: not every event is stored.
- Memory is **dynamic**: memories strengthen/decay, get reinforced/forgotten, can become generalized.
- Memory biases future decisions without directly controlling behavior.
- Memory creates individuality and divergence.

## Memory Pipeline
Event → Appraisal → Memory Gate → Memory Type Determination → Storage → Reinforcement / Decay → Retrieval → Decision Influence → Personality Drift

## Memory Layers
- **Working Memory**
  - seconds to minutes
  - small capacity, high accessibility
  - current target, conversation target, active threat, current goal/task characteristics

- **Short-Term Memory (STM)**
  - minutes to days
  - moderate capacity, fast retrieval
  - recent events, conversations, observations, locations

- **Long-Term Memory (LTM)**
  - days to lifetime
  - large capacity, slower retrieval
  - important events, learned knowledge, relationships, skills, life history

## Memory Categories
- **Episodic**: specific experiences
  - location, participants, time, outcome, emotional context

- **Semantic**: learned facts/knowledge
  - “Wolves are dangerous”

- **Procedural**: skills and habits
  - mining/crafting/fishing

- **Relational**: social experiences involving specific creatures
  - “Bob helped me”

## Memory Structure
```csharp
public class Memory
{
    public MemoryType Type;

    public float Strength;       // 0..100
    public float Importance;     // base weight assigned by type
    public float EmotionalWeight;
    public float Relevance;

    public float Age;

    public MemoryTag[] Tags;
}
```

## Memory Formation (Gate)
Events only become memories through a memory gate.

Memory gate evaluates:

- emotional intensity
- personal relevance
- goal relevance
- novelty
- repetition
- relationship importance
- survival importance

Recommended memory strength formula:

- `MemoryStrength = EventImportance × EmotionalIntensity × Relevance × DriveWeight`

Drive weighting:
- aethersign drives adjust memory formation strength

## Memory Importance / Persistence
- Importance determines persistence
- Range: 0–100

Examples given:
- tree seen = 5
- finding food = 25
- winning duel = 50
- marriage = 80
- child birth = 95
- near death experience = 100

## Memory Tags (for retrieval)
Memories store emotional/semantic tags used for query indexing.

Examples:
Food, Water, Danger, Family, Friendship, Courtship, Partnership, Parenting,
Trade, Teaching, Achievement, Failure, Conflict, Betrayal, Trust,
Discovery, Shelter, Loss, Leadership, Status.

## Reinforcement
Memories strengthen through repetition.

Reinforcement example formula:

- `NewStrength = CurrentStrength + (ReinforcementValue × Modifier)`

## Decay
Memory strength decays over time.

Exponential decay (Ebbinghaus-style):

- `CurrentStrength = InitialStrength × e^(-DecayRate × Time)`

Fast vs slow decay examples were specified:
- fast: minor conversations, routine activities
- slow: trauma, major achievements, life-changing events

## Forgetting / Pruning
A memory may be removed when:

- Strength < MinimumThreshold
- storage capacity exceeded and memory has low importance

## Retrieval
Memories are retrieved when triggered by similarity:

- situations
- people
- locations
- emotions
- goals

Recall ranking:

- `RecallScore = Strength × Relevance × Similarity × Recency`

Associative recall:
- recalled memory chains can trigger related memories

## Knowledge Generation & Skill Learning
Repeated episodic memories can become:

- semantic knowledge (e.g., found berries near rivers → berries often grow near rivers)
- procedural memory via repeated actions (craft → improved crafting skill)

## Relationship Integration
Relational memory influences:

- trust, affection, attraction, respect, loyalty, rivalry, fear

Example:
- repeated help → trust increases
- repeated betrayal → trust decreases

## Emotion Integration
Emotion affects:

- memory formation strength
- memory retrieval likelihood

Strong emotional states create stronger memories.

## Decision Integration
Memory modifies utility calculations:

- known food source → foraging utility increase
- known predator territory → exploration utility decrease

## Personality Drift
Personality drift is driven by long-term memory trends.

Drift contribution formula:

- `DriftContribution = MemoryStrength × EmotionalWeight × AxisModifier`

Examples:
- repeated betrayal → affiliation down, trust down, cooperation down, fear up
- repeated mentorship → empathy up, generativity up, purpose up
- repeated exploration → curiosity up, breadth up

## Design Goals
- store meaningful experiences
- enable learning/adaptation
- influence decisions without controlling them
- drive long-term personality growth
- create unique life histories
- support relationships/social memory
- support procedural learning and knowledge acquisition
- scale efficiently
- produce believable emergent behavior over a lifetime

