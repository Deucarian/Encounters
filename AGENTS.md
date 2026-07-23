# Deucarian Encounters Agent Notes

Package ID: `com.deucarian.encounters`
Repository: `Deucarian/Encounters`

Follow the canonical Deucarian governance docs in [Package Registry](https://github.com/Deucarian/Package-Registry/blob/main/ARCHITECTURE.md), especially capability ownership and dependency rules.

## Ownership

This package owns:

- Pure C# encounter foundations for stages, waves, spawn request scheduling, weighted selection, objective state, reward references, scaling descriptors, and snapshots.

Registered capabilities:
- None.

This package must not own:

- GameObject spawning, navigation, combat resolution, weapons, persistence, progression reward application, UI, or product-specific encounter content.

## Dependencies

Allowed dependency shape:

- May depend on Gameplay Foundation for deterministic IDs, ticks, random, tags, and validation primitives.
- Runtime assembly keeps `noEngineReferences` enabled.

Required dependencies and why:

- `com.deucarian.gameplay-foundation`: shared identifiers, deterministic random/tick primitives, and validation helpers.

Optional/version-defined dependencies:

- None.

Architecture exceptions:

- None.

## Policies

- Keep encounter scheduling deterministic and content-agnostic.
- Do not add spawning, navigation, combat, save, UI, or template-specific behavior here.
- Logging: Do not introduce direct Unity Debug calls.
- Testing: Keep stages, waves, spawn scheduling, weighted selection, objectives, reward references, scaling, snapshots, and validation covered by EditMode tests.

## Validation

Run the shared validator before committing:

```powershell
python C:/Repositories/Package-Registry/Tools/deucarian_package_validator.py --registry-root C:/Repositories/Package-Registry --repository-root . --config deucarian-package.json
```

Also run existing repository tests when changing code or asmdefs. Documentation-only updates should still run `git diff --check`.

## Codex Guidance

- Inspect current files before changing anything.
- Work on `develop`; do not edit or merge `main` unless the task is promotion-only.
- Do not edit `Library/PackageCache`.
- Do not guess package versions or dependency versions.
- Do not add package dependencies casually; update asmdefs, `package.json`, `deucarian-package.json`, Package Registry, and fallback catalogs together when a dependency is truly required.
- Do not create local copies of shared helpers.
- Keep commits focused and report exactly what changed and what was validated.

