# CoFH Talent Tweaks

Simple mod which fixes up some issues with talents which were explicitly or implicitly unimplemented/non-functional. Descriptions have been changed to match the new implementations, as the talents as written in vanilla are either non-feasible or meaningless. Changes to files in `/AutoGen` have been marked with `CHANGED BY CoFHTalentTweaks` as comments.

If you like what you see here, you should check out Team CoFH's Minecraft mods.
[Team CoFH Discord](https://discord.gg/uRKrnbH)

## New/Fixed:

### Logger's Luck (Logging):

Tree stumps are automatically cleared when a tree is felled.

### Cleanup Crew (Logging):

Hits on tree debris no longer expend calories or tool durability.

### Tool Strength (Gathering):

Increases the yield of plants which require a tool to harvest by 10 percent.

### Power Shot (Hunting):

Increases the damage of Bows by 10 percent.

## Changed:

### Deadeye (Hunting)

The headshot damage increase is now multiplicative. (Without this mod, it is additive, which makes it effectively only a 33% increase.)

## Installation Instructions:

- Extract/copy the `/Mods` folder in this zip file into the root folder for your Eco server.

## Uninstallation Instructions:

In `/Mods/UserCode/AutoGen/Benefit`, remove the following files:

- `CleanupCrew.override.cs`
- `LoggersLuck.override.cs`
- `PowerShot.override.cs`
- `ToolStrength.override.cs`

In `/Mods/UserCode/AutoGen/Tool`, remove the following files:

- `CompositeBow.override.cs`
- `RecurveBow.override.cs`
- `WoodenBow.override.cs`

In `/Mods/UserCode/Objects`, remove the following file:

- `TreeObject.override.cs`

In `/Mods/UserCode/Tools`, remove the following files:

- `AxeItem.override.cs`
- `BowItem.override.cs`
