# API

Namespace: `Deucarian.Encounters`

## Identifiers

- `StageId`, `EncounterId`, `WaveId`, `SpawnGroupId`
- `SpawnableId`, `SpawnTableId`, `SpawnChannelId`
- `EncounterMetricId`, `EncounterFlagId`, `EncounterObjectiveId`
- `RewardReferenceId`

All identifiers wrap Gameplay Foundation `ContentId` rules.

## Definitions

- `StageDefinition`: stage to encounter reference plus reward references.
- `EncounterDefinition`: spawn tables, waves, objectives, completion reward references, and deterministic seed.
- `WaveDefinition`: start tick, manual-start flag, spawn groups, and wave reward references.
- `SpawnGroupDefinition`: fixed or weighted-table spawn source, count, batch size, initial delay, interval, channel, tier, and tags.
- `WeightedSpawnTableDefinition` / `WeightedSpawnEntry`: deterministic weighted spawnable selection.
- `ObjectiveDefinition`: all-waves-emitted, elapsed-ticks, metric, flag, and manual completion/failure objectives.
- `LinearScalingDescriptor`: small generic scaling data helper.

## Runtime

- `EncounterRuntime.Start`, `Pause`, `Resume`, `Stop`
- `AdvanceTicks(long ticks)`
- `StartWave(WaveId waveId)`
- `DrainSpawnRequests(SpawnRequest[] buffer)`
- `SetMetric`, `IncrementMetric`, `SetFlag`, `SatisfyManualObjective`
- `CreateSnapshot` and `EncounterRuntime.FromSnapshot`
- `GetCompletionRewardReferences`

`DrainSpawnRequests` is bounded by the caller buffer. If more due requests remain, `EncounterDrainResult.HasMore` is true and no unbounded queue is created.

## Determinism

Due requests are selected by due tick, wave id, group id, and emitted ordinal. Weighted selection uses the encounter seed, table id, and selection ordinal, so restoring a snapshot preserves the request stream.

## Out Of Scope

Runtime does not depend on Combat, Progression, Persistence, UI, GameObjects, MonoBehaviours, scenes, networking, Entities, service locators, global mutable state, coordinates, pathfinding, pooling, or physics.
