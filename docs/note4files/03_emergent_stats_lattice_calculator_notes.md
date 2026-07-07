# Emergent Stat Lattice Notes (Gemini Additions)

This file captures the additional “lattice calculator / design observation / next step” content present in `docs/note4.md`.

## Emergent Stat “DNA” Mapping
Because the lattice is mathematically nested:

- Core stats → Advanced stats → Emergent stats

Gemini’s derived mapping shows each Emergent Stat as an equal blend of four Core Stats.

| Emergent Stat | Component 1 | Component 2 | Raw Core Mix |
|---|---:|---:|---|
| **Focus** | Endurance | Finesse | (Strength + Stamina + Dexterity + Perception) / 4 |
| **Insight** | Prowess | Conviction | (Strength + Dexterity + Willpower + Perception) / 4 |
| **Creativity** | Finesse | Vitality | (Dexterity + Perception + Stamina + Willpower) / 4 |
| **Fortitude** | Endurance | Conviction | (Strength + Stamina + Willpower + Perception) / 4 |
| **Momentum** | Vitality | Prowess | (Stamina + Willpower + Strength + Dexterity) / 4 |

## Design Insight: One Core Stat Omitted
Each emergent stat formula omits exactly one core stat:

- Focus excludes **Willpower**
- Momentum excludes **Perception**

This supports believable behavior decoupling:

- a creature can be blind/low-awareness (low perception)
- but still have strong initiative (high momentum)

## Strengths
- **Decoupling capability from intent** (avoid “High Strength = Aggressive” style coupling)
- **Performance**: derived stats avoid storing many values per creature
- **Believable divergence**: injuries/training drift core stats → emergent capacities change → success/failure feeds memories → personality drift

## Next Design Question (From Gemini)
Emergent Stats must ultimately feed the decision engine. The key integration choice:

- Should high **Momentum** evaluate goals more frequently?
- Or should it weight active goals (explore/hunt) with higher baseline utility than passive goals (rest/socialize)?

