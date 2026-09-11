using System;

using UnityEngine;

namespace Deucarian.Encounters.Unity
{
    /// <summary>Reusable defaults for code calls and serialized typed keys; runtime state remains in the core service.</summary>
    public sealed class EncounterDefinitionAsset : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private string displayName;
        [SerializeField] private EncounterWaveData[] waves = Array.Empty<EncounterWaveData>();
        [SerializeField] private long durationTicks = 120L;
        [SerializeField] private int seed = 1;
        public string Id => id;
        public string DisplayName => displayName;
        public EncounterKey Key => new AssetKey(id);
        public EncounterDefinition ToRuntimeDefinition()
        {
            var definitions = new WaveDefinition[waves.Length];
            var ids = new System.Collections.Generic.HashSet<string>(StringComparer.Ordinal);
            for (int i = 0; i < definitions.Length; i++)
            {
                var wave = waves[i];
                if (wave == null || string.IsNullOrWhiteSpace(wave.Id) || !ids.Add(wave.Id)) throw new InvalidOperationException("Give each wave in '" + DisplayName + "' a unique stable Id.");
                if (wave.Spawnable == null || wave.Channel == null) throw new InvalidOperationException("Choose spawnable and channel definitions for wave '" + wave.Id + "'.");
                definitions[i] = new WaveDefinition(new WaveId(Id + ".wave." + wave.Id), wave.StartTick,
                    new[] { SpawnGroupDefinition.Fixed(new SpawnGroupId(Id + ".group." + wave.Id), new SpawnableId(wave.Spawnable.Id), wave.Count, wave.BatchSize, 0, wave.IntervalTicks, new SpawnChannelId(wave.Channel.Id), wave.ScalingTier) });
            }
            var objective = definitions.Length == 0
                ? ObjectiveDefinition.ElapsedTicksAtLeast(new EncounterObjectiveId(Id + ".complete"), durationTicks)
                : ObjectiveDefinition.AllWavesEmitted(new EncounterObjectiveId(Id + ".complete"));
            return new EncounterDefinition(new EncounterId(Id), Array.Empty<WeightedSpawnTableDefinition>(), definitions, new[] { objective }, seed: seed);
        }
        private sealed class AssetKey : EncounterKey { public AssetKey(string value) : base(value) { } }
    }
}
