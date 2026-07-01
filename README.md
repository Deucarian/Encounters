# Deucarian Encounters

`com.deucarian.encounters` is a pure C# Unity package for deterministic encounter scheduling.

It owns stage, encounter, wave, spawn group, weighted table, objective, reward-reference, scaling descriptor, lifecycle, and snapshot primitives. It emits spawn requests into caller-owned buffers and does not instantiate, move, damage, reward, save, render, or query world objects.

Runtime dependency:

- `com.deucarian.gameplay-foundation`

Deliberately out of scope for runtime:

- GameObjects, MonoBehaviours, scenes, UI, networking, persistence, Entities, service locators, global mutable state
- health, damage, weapons, progression redemption, currencies, saving, pathfinding, coordinates, lane logic, physics, and pooling

Remote publication and Package Registry registration are deferred release steps.

## Install

Stable:

```json
"com.deucarian.encounters": "https://github.com/Deucarian/Encounters.git#main"
```

Development:

```json
"com.deucarian.encounters": "https://github.com/Deucarian/Encounters.git#develop"
```

Use `#main` for stable package consumption and `#develop` when testing active package work.

## When To Use This

Use this package when you need Pure C# encounter foundations for stages, waves, spawn request scheduling, weighted selection, objective state, reward references, scaling descriptors, and snapshots.

Do not use this package to take ownership of capabilities outside its `AGENTS.md` boundary. Reusable behavior should stay with the package that owns that capability in the Package Registry governance docs.

## Quick Start

1. Install the package through Deucarian Package Installer or Unity Package Manager using the URL above.
2. Let Unity finish resolving packages and compiling assemblies.
3. Import the `Encounter Sandbox` sample if you want a working reference scene or setup.
4. Start from the package README sections above and the public runtime/editor APIs in this repository.

## Integrations

Direct Deucarian package dependencies:

- `com.deucarian.gameplay-foundation`

Install optional companion packages only when their owned capability is needed by production code, samples, or tests.

## Validation

Run the shared package validator from this repository root:

```powershell
python C:/Repositories/Package-Registry/Tools/deucarian_package_validator.py --registry-root C:/Repositories/Package-Registry --repository-root . --config deucarian-package.json
```

Documentation-only updates should still pass:

```powershell
git diff --check
```

## Troubleshooting

- Package does not resolve: confirm the stable or development Git URL matches the Package Registry entry and that required Deucarian dependencies are installed.
- Unity compile errors after install: let Package Manager finish resolving dependencies, then check asmdef references against `package.json` dependencies.
- Behavior appears to belong in another package: consult `AGENTS.md` and the Package Registry governance docs before moving or duplicating code.
