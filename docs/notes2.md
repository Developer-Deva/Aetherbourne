# Notes and Feedback

Blackbox has reviewed all of the files in docs and here is the negative ofeedback/constructive critism.

## world.md

You mention 15 biomes but don’t show the full taxonomy or the actual mapping function from the float vector → biome label(s). Right now it’s mostly descriptive categories.
“Acoustic profiles modify AI perception” is compelling, but it would benefit from being formalized: what system consumes this, and what variables does it affect (stealth score? hearing radius? communication range?).

## flora.md and minerals.md

The docs are very large property lists; that’s good for a “spec” doc, but it needs a:
short “what it does” summary at top, and
a “how to choose/extreme roll rules” section.
In minerals.md there are multiple “mechanical hooks” tables (stat bonus per property) which is excellent, but the naming and category coverage could be made more consistent (you reuse “Value/Rarity” etc. across two systems—good—but you’ll eventually want one shared vocabulary spec).
In minerals.md code section: there’s a syntax/typo issue in the snippet ({ "Value", "Standard" } formatting aside, I saw VALUE_TITLES = { and then { "Worthless"... } jammed together). This is minor for docs, but if these snippets are meant to be copied into code it will break.

## actions.md

Consider adding a small section on:
Effect resolution order (especially if multiple effects apply)
Determinism vs randomness
Event emission contract (what events must be emitted on success/failure)

## behavior.md

You say “Not always choose absolute max” and then provide scoring shape. That’s good.
But you should specify how you avoid thrashing between top-scoring actions (hysteresis / persistence thresholds). You mention “Persistence and Switching” conceptually, but the arbitration section would benefit from a concrete rule like:
“Only switch if new action utility > current + X”
“or if confidence delta exceeds threshold”
Also: it would help to explicitly state whether the behavior system uses:
single-step lookahead, or
plan evaluation, or
cached goal estimates.

## emotions.md

ould influence decision pressure” but don’t formalize how bias enters scoring in behavior. A bridge like:
BehaviorBias = f(emotion_state, action.tags, need_context)
would make cross-doc integration tighter.

## needs.md

You have “urgency (0-100)” but you don’t specify update dynamics: how urgency changes per tick, what are rates, and what are saturation effects.

## personality.md

Consistency: you say “two axes per domain” and list it; that’s fine. But the docs don’t define the exact axis modifier mapping (“AxisModifier” in drift formula). Without that, the drift equation can’t be tuned.
“Personality resistance updated during Sleep/Long Rest” is good for performance. But you should define:
when memory decays relative to drift,
and whether drift happens after memory gate or before.

## memories.md

You say: “MemoryStrength = EmotionalIntensity × DriveWeight” and DriveWeight is 25% stronger when matches Aethersign Drive. But you don’t specify:
exact Drive mapping to event categories,
and how emotional intensity becomes a comparable unit across different emotion dimensions.

## stats.md

The doc you pasted is coherent, but there’s an internal naming mismatch risk: you use “Fortitude”/“Momentum” etc. as hidden stats while personality axes are different constructs. You should explicitly state which influences which:
hidden stat → behavior bias
hidden stat → personality drift (if any)
hidden stat → skill growth

## events.md

You didn’t show any “event schema / serialization” definition (category, source, actors, etc. fields). It’s described conceptually but not as a strict structure.

## time.md

Some sections are placeholders (“Document summary placeholder”, missing concrete API section content beyond lists). You’re very close to a good spec.

## Overall

You have lots of “interfaces” described by words:

emotion biases behavior
events feed emotions/memory
memories drift personality
But some of these require explicit coupling rules:

Which tags/dimensions affect which action score terms?
When an event spawns memory: what exact threshold + which memory type?
How Aethersigns alter memory weighting vs personality resistance vs domain affinity in code terms.

Minor correctness issues in snippets
Mainly in minerals.md code blocks where I saw malformed dictionary syntax in the pasted snippet. If those code blocks are intended as real code seeds, they should be lint-clean.

What I would improve first (highest ROI)
Add “bridge contracts” between systems:
Event → Emotion (mapping table)
Emotion → Memory (gate formula with inputs)
Memory → Personality Drift (how AxisModifier is computed)
Emotion/Personality → Action Utility (how each dimension affects scoring)
Fix stubs into minimal schemas (even if gameplay is not built yet):
For relationships/skills/creatures: define data model + lifecycle hooks.
Make arbitration stable:
add explicit anti-thrash logic (hysteresis / confidence thresholds).
Make property-heavy docs “spec + rules”:
property lists are great, but each should include:
generation rule summary
extreme roll rules
how many extremes matter
fallback/default behavior
How everything “looks together so far”
Right now, the docs form a strong architecture with a coherent pipeline, but it’s like a building where:

the foundation and framework (pipeline, layering, formulas) are laid,
while many rooms are still under construction (“coming soon”),
and a few connection joints need more explicit mechanical definitions to be fully implementable without guessing.
If you want, next step would be to turn the “bridge contracts” into dedicated docs or sections inside existing ones so the whole pipeline can be implemented and tested deterministically.
