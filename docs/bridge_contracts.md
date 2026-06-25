# Bridge Contracts

All simulation subsystems must share the same event, emotion, memory, and timing contracts to avoid relying on implied logic.

---

## Event Schema
All simulation events must use the same minimum structure.

```csharp
public struct SimEvent
{
    public string Id;
    public string Category;
    public string Source;
    public string Target;
    public string Location;
    public float Severity;
    public float Relevance;
    public float Intensity;
    public bool IsSuccess;
    public bool IsFailure;
    public List<string> Tags;
    public Dictionary<string, float> Values;
    public long Tick;
}
```

### Required fields
- `Category`: high-level event type such as Social, Injury, Resource, Environment, or Goal.
- `Source`: the actor or system that caused the event.
- `Target`: the primary affected creature or object, if any.
- `Location`: tile or region reference.
- `Severity`: objective impact of the event.
- `Relevance`: how important the event is to the creature right now.
- `Intensity`: emotional magnitude after appraisal.
- `Tags`: machine-readable labels used by emotion, memory, and behavior.
- `Values`: optional numeric payload for system-specific data.

### Emission rules
- Every resolved action must emit exactly one success event or one failure event.
- Secondary effects may emit additional events, but the primary action event must always exist.
- Environmental ticks may emit events even when no creature acts.
- Events must be deterministic for a given simulation seed and tick order.

## Event Resolution Order
Event processing must happen in this order:
1. Action intent is selected.
2. Preconditions are checked.
3. Costs are applied.
4. Effects are resolved.
5. Primary event is emitted.
6. Emotional appraisal is computed.
7. Memory gate is evaluated.
8. Behavior pressure is updated.
9. Personality drift is applied later during the memory update phase.

### Determinism rule
If two effects occur in the same tick, resolve them in fixed order by:
1. priority,
2. source id,
3. action id,
4. event id.

Random rolls must use the simulation RNG stream only and must be seedable.

---

## Emotion Bridge
Emotion is generated from event appraisal, not directly from event category.

```text
EmotionInput = f(Severity, Relevance, GoalCongruence, NeedContext, PersonalityBias, RelationshipContext)
```

### Appraisal outputs
- `Valence`
- `Arousal`
- `Fear`
- `Joy`
- `Anger`
- `Sadness`
- `Relief`
- `Curiosity`
- `Attachment`

### Mapping rule
- Objective facts create appraisal.
- Appraisal creates emotional state.
- Emotional state may influence behavior and memory.
- Emotion never directly replaces action selection.

---

## Emotion to Behavior
Emotion contributes a bias term in action scoring.

```text
BehaviorBias = f(EmotionState, ActionTags, NeedContext)
```

### Example bias channels
- Fear increases avoidance and safety-seeking.
- Joy increases approach and repetition.
- Anger increases confrontation and interruption.
- Sadness increases withdrawal and low-energy behavior.
- Curiosity increases exploration and inspection.
- Attachment increases social approach and proximity seeking.

### Scoring rule
BehaviorBias is a modifier, not a command. It may raise or lower utility, confidence, or persistence, but it cannot force an invalid action.

---

## Memory Gate
A memory is stored only when emotional intensity clears the creature’s threshold.

```text
StoreIf = EmotionalIntensity >= StorageThreshold
MemoryStrength = EmotionalIntensity × DriveWeight × ContextWeight
```

### DriveWeight
- If the event category matches the creature’s Aethersign Drive, `DriveWeight = 1.25`.
- If it partially matches, `DriveWeight = 1.10`.
- If it does not match, `DriveWeight = 1.00`.

### ContextWeight
ContextWeight can amplify or dampen storage based on:
- current need pressure,
- relationship importance,
- threat level,
- repetition,
- age stage.

### Memory type selection
- Specific, one-time events become episodic memory.
- Repeated patterns become semantic memory.
- Repeated successful actions become procedural memory.

---

## Memory to Personality Drift
Personality drift occurs after memory storage and decay updates have been evaluated for the tick.

```text
DriftContribution = CurrentStrength × AxisModifier × DomainAffinity × ResistanceFactor
```

### Order of operations
1. Retrieve or create memory.
2. Apply memory decay.
3. Evaluate whether the memory is still strong enough to influence drift.
4. Apply drift contribution.
5. Update personality resistance only during rest or sleep windows.

### Drift rule
- Stronger memories have greater effect.
- Recent memories matter more than faded ones.
- Matching Aethersign domains reduce resistance and increase drift.
- Personality does not change instantly; drift accumulates gradually.

---

## Need and Personality Bridge
Needs and personality both influence action scoring, but in different ways.

### Need influence
- Needs determine urgency.
- Urgency determines baseline pressure to act.

### Personality influence
- Personality determines preference shape.
- Personality modifies how urgency becomes choice.

### Rule
Need pressure should decide *whether* the creature wants to act.  
Personality should decide *how* the creature tends to act.

---

## Hidden Stats Bridge
Hidden stats are computed creature traits that feed into other systems.

### Influence rules
- `HiddenStat -> BehaviorBias`: allowed.
- `HiddenStat -> SkillGrowth`: allowed.
- `HiddenStat -> PersonalityDrift`: only if explicitly listed.
- `HiddenStat -> DirectActionOverride`: not allowed.

### Examples
- Focus may improve memory retrieval and planning consistency.
- Fortitude may reduce stamina penalties and improve recovery.
- Momentum may increase action persistence and reduce switching.
- Creativity may expand action variety and novelty seeking.

---

## Behavior Arbitration
The AI should not always pick the maximum utility action if it is already committed to a stable choice.

### Persistence rule
Only switch actions if:
- new utility > current utility + switch threshold, or
- current action becomes invalid, or
- confidence delta exceeds threshold.

### Suggested thresholds
- `SwitchThreshold`: minimum utility advantage required to switch.
- `ConfidenceThreshold`: minimum certainty required to override the current action.
- `Cooldown`: brief lockout after repeated switching.

### Lookahead rule
The behavior system should use single-step lookahead by default.
- It may estimate immediate consequences of candidate actions.
- It should not require full long-horizon planning to function.
- Cached goal estimates are allowed as a performance optimization.

---

## Action Contract
Every action must declare:
- `Requirements`
- `Costs`
- `Effects`
- `Tags`
- `Training`
- `FailureModes`
- `EventOutputs`

### Action outcome rule
- Success and failure must both emit meaningful events.
- Effects must be resolved before the event is finalized.
- If an action changes the world, the event must encode that change.

---

## Time Bridge
Time advances in discrete ticks, but many systems should update at different cadences.

### Suggested cadence
- Needs: every tick.
- Emotions: every tick.
- Events: every tick.
- Memory decay: every tick or every short interval.
- Personality drift: at memory update time.
- Resistance rebalancing: during sleep or long rest.

### Rule
No system may assume another system has already updated unless the contract explicitly says so.

