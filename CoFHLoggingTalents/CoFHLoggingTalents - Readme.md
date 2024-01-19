# CoFH Logging Talents

Simple mod which implements both of the unimplemented Level 6 Logging specialization talents. Descriptions are below, but essentially the tradeoff is instant (and free) stump removal or free debris clearing.

### Logger's Luck:

Tree stumps are automatically cleared when a tree is felled.

### Cleanup Crew:

Hits on tree debris no longer expend calories or tool durability.

## Installation Instructions:

- Extract/copy the `/Mods` folder in this zip file into the root folder for your Eco server.

## Uninstallation Instructions:

In `/Mods/UserCode/AutoGen/Benefit`, remove the following files:
- `CleanupCrew.override.cs`
- `LoggersLuck.override.cs`

In `/Mods/UserCode/Objects`, remove the following file:
- `TreeObject.override.cs`

In `/Mods/UserCode/Tools`, remove the following file:
- `AxeItem.override.cs`
