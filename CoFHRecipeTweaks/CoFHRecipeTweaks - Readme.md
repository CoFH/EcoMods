# CoFH Recipe Tweaks

This is a simple recipe adjustment mod - folders serve as categories for the recipes, with the exception of `/AutoGen`.

## Adjusted Recipes:

Bricks:
- Now returns half of the Wooden Mold items used (Scales with Efficiency)

Flaxseed Oil:
- 12 Flax Seeds -> Flaxseed Oil (-4 Flax Seeds Required)

Wind Turbine:
- 6 Steel Bars + 4 Fiberglass + 4 Gearboxes + 4 Advanced Circuits + 4 Servos -> Wind Turbine (-2 Steel Bars, -4 Servos, and +4 Fiberglass Required)

Wooden Molds:
- Now have a Fuel Value of 500

### Rationale:

Bricks and Lumber are far more difficult to make than Glass, resulting in lopsided balancing. Glass also stays relevant into Tier 4, so is the far superior material. These changes should smooth out progression slightly and make these materials cheaper, though Glass still wins in a strict resource comparison.

The Wind Turbine is completely outclassed by the Solar Generator. Prior to the Servos being added to the recipe in late 2023, the Turbine was seen as the superior option. Removing half of the servos splits the difference and reduces the cost a proportional amount with respect to the power generation difference.

## New Recipes:

Fish Oil:
- 36 Raw Fish -> Oil (Butchery 4; Butcher's Table, 20 Calories, 0.5 XP, 3 Minutes)

Mix Soil:
- 3 Sand + 1 Clay + 4 Compost -> 4 Dirt (Farming 4; Farmer's Table, 50 Calories, 0.5 XP, 3 Minutes)

Wet Tailings Stabilization:
- 4 Wet Tailings + 2 Quicklime -> 4 Tailings (Scales with Efficiency) (Advanced Masonry 3; Cement Kiln, 180 Calories, 1 XP, 4.8 Minutes)

### Rationale:

Fishing falls off really early and there is a lot of pressure on Millers to produce Oils (especially with Flaxseeds). This eases a bit of that pressure and boosts Hunting (Fishing) as a profession.

Compost sucks. Soil (Dirt) is made from a combination of silt, clay, sand, and organic material. This is just providing a recipe that is grounded in reality. Sand is pulling double duty as both Silt and Sand in this recipe, but it is a decent approximation.

Wet Tailings can be processed/stabilized. Using Quicklime is actually how it is done. It doesn't magically make them non-polluting but it DOES reduce their volume and their propensity for seepage. It basically dries them out. So that's what this does.

## Advanced Smelting (in `/AutoGen`):

Rebar:
- 1 Steel Bar -> 1 Rebar (-1 Steel Bar Required)

Rivets:
- 1 Steel Bar -> 4 Rivets (+1 Rivet Produced)
- Crafted in Anvil

Steel Pipe:
- Crafted in Anvil

### Rationale:

These recipes all make more sense on an Anvil than a Blast Furnace, and the upgrade level is the same, so there's not really a balance issue. (You can find a video on YouTube of a guy making a rivet on an anvil, if you are curious.) Rebar's cost for only being used in a T3 material is just a little too pricey to justify, and Rivets also felt slightly too expensive for what they are. Since Screws are produced 4 at a time (and Nails 16), 4 seemed like a good round number to use.

## Research Paper Changes:

- Modern Research Papers now require 20 Paper in addition to their previous requirements. This is a static input and does not scale with upgrade modules.

### Rationale:

Paper Milling needs the help. And...they're literally called Papers.

## Installation Instructions:

- Extract/copy the `/Mods` folder in this zip file into the root folder for your Eco server.

## Uninstallation Instructions:

In `/Mods/UserCode/AutoGen/Block`, remove the following files:
- `SteelPipe.override.cs`

In `/Mods/UserCode/AutoGen/Item`, remove the following files:
- `Rebar.override.cs`
- `Rivet.override.cs`

- Remove the `CoFHRecipeTweaks` folder from `/Mods/UserCode`
