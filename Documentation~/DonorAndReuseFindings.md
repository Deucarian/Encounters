# Donor And Reuse Findings

Primary donor:

`C:/Repositories/JorisHoef/Codex-Attempted-Vampire-Project/Codex-Attempted-Vampire-Project`

## Clean Mappings

- `WaveSegmentModel` maps to `WaveDefinition` plus one or more `SpawnGroupDefinition` entries.
- `WeightedEnemyModel` maps to `WeightedSpawnEntry`.
- `WaveDirectorModel.ResolveSpawnSnapshot` maps to authored group counts, batch sizes, intervals, and optional `LinearScalingDescriptor` in product adapters.
- boss encounter times map to dedicated waves or spawn groups with reward references.
- run reward IDs map to `RewardReferenceId`; actual reward bundles remain in Progression adapters.

## Requires Adapters

- `WaveDefinition` ScriptableObjects and Odin inspectors need authoring adapters.
- donor `LevelDefinition.MatchesEnemy` content filtering belongs to a product/content adapter before requests are emitted or consumed.
- alive-count caps and stress settings belong to orchestration adapters, not the package runtime.
- radial spawn positions around the player belong to a world adapter.
- boss/final-boss semantics can be modeled as waves, objectives, and reward references, but enemy spawning and victory handling stay outside Encounters.

## Discarded Donor Assumptions

- player-centric radial spawn coordinates
- direct `GameSessionBootstrapper` coupling
- Unity time seconds in core runtime
- direct enemy registry reads inside the scheduler
- reward currency values embedded in encounter runtime

## Survivor-Specific Review

The public API avoids survivor-specific terms. `SpawnChannelId` can mean a lane, path, portal, region, offline bucket, or adapter-defined channel.

## Idle Auto Defense

Idle Auto Defense can advance ticks from online or offline elapsed time, emit requests into lane/core adapters, track core-health flags through `SetFlag`, and map completion reward references to Progression bundles.

## Classic Tower Defense

Tower Defense can author each lane/path as a `SpawnChannelId`, use `WaveDefinition` start ticks for wave cadence, emit creeps into path/pool systems, and complete waves via all-emitted or metric objectives.
