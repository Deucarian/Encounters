# ADR-0001: Encounter Scheduler Boundary

## Status

Accepted for 0.1.0.

## Decision

`com.deucarian.encounters` owns pure encounter scheduling and state only. It defines stage, encounter, wave, spawn group, weighted spawn table, objective, reward-reference, scaling, lifecycle, and snapshot primitives. Runtime emits `SpawnRequest` values into caller-provided buffers.

The package does not instantiate GameObjects, pick coordinates, query physics, move agents, apply Combat, grant Progression rewards, write Persistence documents, or drive UI.

## Rationale

The donor project mixes reusable wave concepts with Unity-specific spawn positions, content filtering, alive caps, boss spawning, stress settings, and session orchestration. The reusable part is the deterministic schedule and request stream. Keeping requests data-only lets the same API support:

- survivor-style horde waves through a world adapter that chooses positions around the player
- Idle Auto Defense through lane/core adapters and offline tick advancement
- classic Tower Defense through lane/path adapters and wave-completion conditions

## Consequences

Consumers must provide adapters for content catalogs, spawn placement, pooling, alive-count gating, reward redemption, save/load DTOs, and combat outcomes. This is intentional and prevents Encounters from owning responsibilities already assigned to other packages.
