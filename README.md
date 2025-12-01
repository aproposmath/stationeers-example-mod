# Stationeers Example Mod (Code-only with BepInEx)

This serves as a template for a code-only Stationeers mod using BepInEx.

## Features

- Simple code base
- Builds on Windows and Linux
- Github workflow to build releases automatically
- Uses Krafs.Publicizer to access private members
- Example patches demonstrating common techniques:
  - Prefix and Postfix patches
  - Prefix patch skipping the original method
  - Transpiler patch modifying IL code

## Get started with your own mod

- Fork and clone the project
- Run `dotnet build` to build the mod
- Copy the resulting dll from `bin/Debug/net48` to your `BepInEx/plugins` folder

**Before** publishing your mod change the following names in the source code:
- `Main.cs:6`: `namespace ExampleMod`
- `Patches.cs:8`: `namespace ExampleMod`
- `Main.cs:12`: `pluginGuid = "aproposmath-stationeers-example-mod";`
- `Main.csproj:7`: `ExampleMod`

## Release a new Version

Just create a new git tag and push it to GitHub. The workflow will automatically build the release and upload it to the [releases page](https://github.com/aproposmath/stationeers-example-mod/releases) page on github.

```bash
git tag v1.2.3
git push origin v1.2.3
```

## Installation

This mode requires [BepInEx](https://github.com/BepInEx/BepInEx).
Download the latest release from the [releases page](https://github.com/aproposmath/stationeers-example-mod/releases) and put it into your `BepInEx/plugins` folder.
