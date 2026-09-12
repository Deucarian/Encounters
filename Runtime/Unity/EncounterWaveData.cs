using System;
using Deucarian.WorldSpawning.Unity;

namespace Deucarian.Encounters.Unity
{
    /// <summary>Authored schedule data; the caller still consumes spawn requests and chooses the world adapter.</summary>
    [Serializable]
    public sealed class EncounterWaveData
    {
        public string Id = "wave1";
        public SpawnableDefinitionAsset Spawnable;
        public long StartTick;
        public int Count = 4;
        public int BatchSize = 1;
        public long IntervalTicks = 12;
        public SpawnChannelDefinitionAsset Channel;
        public int ScalingTier;
    }
}
