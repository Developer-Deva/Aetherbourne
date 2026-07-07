# Flora Generation Rules

## 1) Macro Global Drivers (Planetary Context)

All flora generation references normalized environment parameters in the range **0.0 → 1.0**:

- **Latitude**: 0.0 = equator/hot → 1.0 = poles/cold (thermal/biome selection)
- **Altitude**: 0.0 = sea level → 1.0 = mountain peaks (pressure/growth constraints)
- **Humidity**: 0.0 = arid → 1.0 = saturated (water dependency & form)
- **Distance From Water**: 0.0 = shoreline → 1.0 = landlocked (aquatic vs xerophytic)
- **Depth Layer**: 0 = surface, 1 = subterranean, 2 = mantle (light level/biome type)
- **System Flags**:
  - `IsMagicalAnomaly`
  - `IsContaminated`
  These trigger special mystical or toxic mutations.

## 2) Growth Model (Deterministic Delta Tick)

Plants grow, propagate, mutate, and decay by continuously evaluating local **PlanetaryContext** factors rather than running expensive per-plant timers.

### Growth Rate Formula

\[
G_{\text{Delta}} = G_{\text{Base}} \times H_{\text{Soil}} \times W_{\text{Availability}} \times L_{\text{Match}}
\]

Where:

- **GBase**: species taxonomy **GrowthRate** baseline
- **HSoil**: soil match efficiency between plant **SoilPreference** and tile **Fertility**
- **WAvailability**: local hydrology saturation, scaled by plant **WaterDependency**
- **LMatch**: lighting modifier matrix mapping chunk light vs plant **LightRequirements**

## 3) Lifecycle Behavior

Botanical entities are dynamic systems rather than static decorations.

Lifecycle behavior includes:

- Seasonal and perennial activity
- Ephemeral/annual/biennial/perennial/ancient activity states
- Regeneration and harvest timing
- Spread and invasion logic
- Dormancy and decay handling
- Mutation handling under anomaly/contamination flags

## 4) Mutation Loop

If `IsMagicalAnomaly = true` or `IsContaminated = true`, the generation pass performs a mutation check during the plant lifecycle step.

- A successful roll forces permanent drift in phenotypic attributes.
- Drift biases values toward:
  - **ElementalAffinity** expressions
  - **ToxicityLevel** tracking

## 5) Color Generation Pipeline (Simulation → Presentation)

Color belongs in the **generation logic** first, then is consumed by presentation.

### Recommended Inputs

- Base species palette
- Biome tint
- Bloom season tint
- Elemental affinity
- Mana saturation
- Toxicity level
- Color vibrancy
- Magical anomaly / contamination flags

### Recommended Outputs

- `HueFamily`
- `Saturation`
- `Brightness`
- `AccentColor`
- `GlowIntensity`
- `PatternType`

### Suggested Behavior Rules

- Base hue from species/family identity
- Biome/season gently shift hue family
- Mana/elemental affinity bias toward unnatural/arcane tones
- Toxicity biases toward sickly/corrosive/warning-like palettes
- Vibrancy controls intensity
- Magical anomaly can add prismatic/luminous/impossible gradients
