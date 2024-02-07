# CoFH Recipe Tweaks

This is a simple recipe adjustment mod - folders serve as categories for the recipes, with the exception of `/AutoGen`. Changes to files in `/AutoGen` have been marked with `CHANGED BY CoFHRecipeTweaks` as comments.

If you like what you see here, you should check out Team CoFH's Minecraft mods.
[Team CoFH Discord](https://discord.gg/uRKrnbH)

## Adjusted Recipes:

Bricks:
- Now returns half of the Wooden Mold items used (Scales with Efficiency)

Corrugated Steel:
- 2 Steel Bars -> 2 Corrugated Steel (+1 Corrugated Steel Produced) 

Flat Steel:
- 3 Steel Bars + 2 Epoxy -> 2 Flat Steel (+1 Flat Steel Produced)

Flaxseed Oil:
- 12 Flax Seeds -> Flaxseed Oil (-4 Flax Seeds Required)

Wind Turbine:
- 6 Steel Bars + 4 Fiberglass + 4 Gearboxes + 4 Advanced Circuits + 4 Servos -> Wind Turbine (-2 Steel Bars, -4 Servos, and +4 Fiberglass Required)

Windmill:
- Now works with any Fabric, not just Linen

Wooden Molds:
- Now have a Fuel Value of 500

### Rationale:

Bricks and Lumber are far more difficult to make than Glass, resulting in lopsided balancing. Glass also stays relevant into Tier 4, so is the far superior material. These changes should smooth out progression slightly and make these materials cheaper, though Glass still wins in a strict resource comparison.

Corrugated Steel is very expensive for what it is, and Tier 3 materials are very underrepresented in general. This makes it a bit more plentiful.

Flat Steel is quite expensive compared to other T4 materials. This helps with that, though it's still pricey compared to Composites or Ashlar Stone.

The Wind Turbine is completely outclassed by the Solar Generator. Prior to the Servos being added to the recipe in late 2023, the Turbine was seen as the superior option. Removing half of the servos splits the difference and reduces the cost a proportional amount with respect to the power generation difference.

The Windmill puts far too much pressure on Linen Fabric specifically, and therefore, Flax. Given the large amount of items which are just made with "Fabric," this seems a reasonable change to make.

## New Recipes:

Fish Oil:
- 28 Raw Fish -> Oil (Butchery 2; Butcher's Table, 20 Calories, 0.5 XP, 2 Minutes)

Fish Stock:
- 8 Raw Fish -> Meat Stock (Cooking 2; Cast Iron Stove, 15 Calories, 1 XP, 8 Minutes)

Mix Soil:
- 3 Sand + 1 Clay + 2 Compost -> 6 Dirt (Farming 4; Farmer's Table, 50 Calories, 0.5 XP, 3 Minutes)

Strip Pelt:
- 1 Fur Pelt -> 1 Leather Hide + 1 Tallow (Butchery 2; Butcher's Table, 20 Calories, 0.5 XP, 2 Minutes)

Wet Tailings Stabilization:
- 4 Wet Tailings + 2 Quicklime -> 4 Tailings (Scales with Efficiency) (Advanced Masonry 3; Cement Kiln, 180 Calories, 1 XP, 4.8 Minutes)

### Rationale:

Fishing falls off really early and there is a lot of pressure on Millers to produce Oils (especially with Flaxseeds). This eases a bit of that pressure and boosts Hunting (Fishing) as a profession.

Also, using Fish to ease a bit of the pressure on Meat Stock makes sense - Fish are used interchangably in many of the early Campfire Cooking recipes which use non-specific meat and this is a natural continuation of that.

Compost sucks. Soil (Dirt) is made from a combination of silt, clay, sand, and organic material. This is just providing a recipe that is grounded in reality. Sand is pulling double duty as both Silt and Sand in this recipe, but it is a decent approximation.

Wet Tailings can be processed/stabilized. Using Quicklime is actually how it is done. It doesn't magically make them non-polluting but it DOES reduce their volume and their propensity for seepage. It basically dries them out. So that's what this does.

## `/AutoGen` Override Files:

Fiberglass:
- Crafted in Spin Melter (Instead of Electronics Assembly)

Rebar:
- 1 Steel Bar -> 1 Rebar (-1 Steel Bar Required)
- Crafted in Rolling Mill (Instead of Blast Furnace)

Rivets:
- 1 Steel Bar -> 4 Rivets (+1 Rivet Produced)
- Crafted in Anvil (Instead of Blast Furnace)

Steel Pipe:
- Crafted in Rolling Mill (Instead of Blast Furnace)

### Rationale:

These recipes all make a bit more sense in other workstations, and the upgrade level is the same, so there's not really a balance issue. (You can find a video on YouTube of a guy making a rivet on an anvil, if you are curious.)

Rebar's cost for only being used in a T3 material is just a little too pricey to justify, and Rivets also felt slightly too expensive for what they are. Since Screws are produced 4 at a time (and Nails 16), 4 seemed like a good round number to use.

For Fiberglass, look up how it's made and you can see this is the more appropriate workstation for it. It also gives the Spin Melter another recipe which is definitely needs - Nylon Thread just isn't *that* in demand.

## Research Paper Changes:

- Modern Research Papers now require 20 Paper in addition to their previous requirements. This is a static input and does not scale with upgrade modules.

### Rationale:

Paper Milling needs the help. And...they're literally called Papers. It doesn't apply to Advanced and Basic because that would entail a massive rework of everything and be generally unfun.

## Installation Instructions:

- Extract/copy the `/Mods` folder in this zip file into the root folder for your Eco server.

## Uninstallation Instructions:

In `/Mods/UserCode/AutoGen/Block`, remove the following file:

- `SteelPipe.override.cs`

In `/Mods/UserCode/AutoGen/Item`, remove the following files:

- `Fiberglass.override.cs`
- `Rebar.override.cs`
- `Rivet.override.cs`

- Remove the `CoFHRecipeTweaks` folder from `/Mods/UserCode`
