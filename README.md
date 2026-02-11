# Stationeers Example Mod

This serves as a template for a code-only Stationeers mod using [Stationeers Launchpad](https://github.com/StationeersLaunchPad/StationeersLaunchPad) and [BepInEx](https://github.com/BepInEx/BepInEx).

## Features

- Simple code base
- Builds on Windows and Linux
- Github workflow to build releases automatically
- Uses Krafs.Publicizer to access private members
- Generates/updates version numbers automatically from git tags
- Example patches demonstrating common techniques:
  - Prefix and Postfix patches
  - Prefix patch skipping the original method
  - Transpiler patch modifying IL code

## Getting started

### 1 Build

- Install [Stationeers Launchpad](https://github.com/StationeersLaunchPad/StationeersLaunchPad) and [BepInEx](https://github.com/BepInEx/BepInEx). You should have this already if you have mods installed.
- Fork and clone the project
- Run `dotnet build` to build and install the mod
- Start the game

### 2 Customize

**Before** publishing your mod change the following entries:
- `Main.props`:  `ModID`, `AssemblyName` and `Description`
- `src/Main.cs:6`: `namespace ExampleMod`
- `src/Patches.cs:8`: `namespace ExampleMod`

(Anything else you might change: update `About/About.xml` metadata and images, and rename the repository/solution artifacts to match your mod. Avoid editing the build template files unless you know why.)

### 3 Publish

Create a new git tag and push it to GitHub. The workflow will automatically build the release and upload it to the releases page of your github fork.

```bash
git tag v0.1
git push origin v0.1
```

### Directory Structure

- `./src/` — **Edit this**. Your mod’s C# code lives here.
  - `./src/Main.cs` — Entry point/plugin setup.
  - `./src/Patches.cs` — Harmony patches/examples.
- `./About/` — **Edit this** when preparing to distribute.
  - `./About/About.xml` — Mod metadata (name/author/description, etc.). `ModID` and `Version` will be automatically replaced
  - `./About/Preview.png`, `./About/thumb.png` — Workshop/manager images.
- `./Main.props` — **Edit this**. Primary mod identity/config (`ModID`, `AssemblyName`, `Description`).
- `./README.md` — **Edit this**. Project documentation.
- `./LICENSE` — Optional to change depending on how you want to license your mod.
- `./VersionInfo.g.cs` — **Do not edit**. Auto-generated version info (from git tags/build).
- `./Main.csproj` — **Generally do not edit** unless you need extra dependencies or build changes.
- `./NuGet.Config` — **Usually do not edit**. Only change if you need custom package feeds.
- `./Template/` — **Do not edit**. Internal build/template support used by the project.
