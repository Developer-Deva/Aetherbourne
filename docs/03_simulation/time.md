# Time System

**Description:** Document summary placeholder
**Last Updated:** 2026-06-21

---

## Overview

The Time System defines how time progresses throughout the simulation.

Time is measured through recurring natural cycles including the passage of light and darkness, seasonal transitions, annual calendar progression, and the movements of the moons Selene and Karael.

These cycles influence creature behavior, agriculture, ecology, scheduling systems, astrology, culture, and long-term world simulation.

---

## Design Philosophy

Time should provide a predictable simulation framework while still feeling natural and alive.

The calendar and celestial systems are designed to:

- Create meaningful seasonal variation
- Support scheduling and long-term planning
- Drive agricultural and ecological systems
- Enable astrology and cultural traditions
- Provide deterministic simulation timing
- Allow creatures to reason about recurring cycles

The simulation should remain deterministic when provided the same seed and inputs.

## Core Concepts

- Tick rate and simulation step
- Day and night progression
- Seasonal cycles
- Calendar and date tracking
- Celestial body simulation
- Event scheduling
- Astrological timing

## Time Units

In Aetherbourne, one simulation tick is equivalent to one minute.

| Common Term | Aetherbourne Term |
| --- | --- |
| Minute | Moment |
| Hour | Bell |
| Day | Turn |
| Week | Cycle |
| Month | Phase |
| Year | Span |

## Calendar Structure

- 60 Moments per Bell
- 24 Bells per Turn
- 10 Turns per Cycle
- 34–38 Turns per Phase
- 10 Phases per Span
- 360 Turns per Span

The calendar year contains ten Phases whose lengths vary slightly to create a more natural rhythm.

## Times of Day

| Period | Description |
| --- | --- |
| Firstlight | Dawn |
| Brightrise | Morning |
| Highsun | Midday |
| Lightwane | Afternoon |
| Duskbloom | Evening |
| Dreamfall | Early Night |
| Starveil | Midnight |
| Twilitide | Late Night |

These periods are used culturally and socially throughout the world.

Most creatures think in Bells and named periods rather than precise numerical time.

## Phases

The ten annual Phases in order are:

| **Phase** | **Season** |
| --- | --- |
| Brigide | Voidgleam |
| Imbolka | Seedwake |
| Floralis | Seedwake |
| Lithara | Sunreach |
| Heliax | Sunreach |
| Aestium | Sunreach |
| Mabonel | Amberwane |
| Ceresio | Amberwane |
| Yulith | Voidgleam |
| Hibernis | Voidgleam |

## Seasons

The world experiences four primary seasons.

## Seedwake

**Phases**: Imbolka, Floralis

The season of renewal.

Snow retreats, rains return, and new growth begins.

Associated with beginnings, fertility, and opportunity.

## Sunreach

**Phases**: Lithara, Heliax, Aestium

The season of abundance.

Long days, warm weather, and rapid growth.

Associated with prosperity, energy, and achievement.

## Amberwane

**Phases**: Mabonel, Ceresio

The season of harvest.

Growth slows and resources are gathered for the colder months.

Associated with preparation, gratitude, and reflection.

## Voidgleam

**Phases**: Brigide, Yulith, Hibernis

The season of long nights.

Cold settles across the land while stars and moonlight dominate the sky.

Associated with mystery, dreams, memory, and the unseen.

The Span begins during Brigide.

## Celestial Bodies

## Selene

The Greater Moon.

Domains

- Dreams
- Memory
- Reflection
- Community

Characteristics

- Large
- Pale
- Slow-moving

Orbital Cycle

29 Turns

## Karael

The Lesser Moon.

Domains

- Change
- Instinct
- Omens
- Transformation

Characteristics

- Small
- Silver-blue
- Swift-moving

Orbital Cycle

17 Turns

Its shorter orbit causes constantly shifting alignments with Selene.

These alignments form the foundation of Aetherbourne astrology.

## Moon Phases

Both moons pass through eight visible phases.

1. New
2. Waxing Crescent
3. First Quarter
4. Waxing Gibbous
5. Full
6. Waning Gibbous
7. Last Quarter
8. Waning Crescent

Because Selene and Karael move at different speeds, their relative positions are constantly changing.

Rare alignments may occur only once every several Spans.

### Rare Celestial Events

#### Convergence

Both moons are Full.

Associated with destiny, leadership, and major societal change.

#### Veilnight

Both moons are New.

Associated with mystery, prophecy, dreams, and spiritual significance.

#### Split Alignment

One moon is Full while the other is New.

Associated with contradiction, innovation, upheaval, and transformation.

## Date Format

Dates are commonly written as:

«Third Turn of Heliax, 214th Span»

or

«Heliax, Third Turn, 214th Span»

Informally, most creatures simply refer to the current Phase and Turn.

---

## Implementation / Notes

## Simulation Time

1 Tick = 1 Moment
60 Ticks = 1 Bell
24 Bells = 1 Turn

## Event Scheduling

Examples:

- Daily routines
- Seasonal crop growth
- Creature aging
- Festival triggers
- Moon phase transitions
- Weather updates

Example Event Hooks

OnTurnStarted
OnTurnEnded

OnPhaseStarted
OnPhaseEnded

OnSeasonStarted
OnSeasonEnded

OnMoonPhaseChanged

OnSpanStarted
OnSpanEnded

## Clock API

The time system should expose:

- Current Moment
- Current Bell
- Current Turn
- Current Cycle
- Current Phase
- Current Season
- Current Span
- Current Selene Phase
- Current Karael Phase

These values should be accessible by AI, simulation systems, event schedulers, world generation systems, and gameplay systems.