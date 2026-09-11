// <deucarian-definition schema="encounters" />
// Editable declaration. Use the package definition editor or edit the values below.
namespace Deucarian.ProjectDefinitions.Definition_encounters
{
    public static class Definition_EncounterSampleWave
    {
        public static global::Deucarian.Encounters.Editor.Definitions.EncounterDefinitionSpec Value =>
        // definition-value
        new global::Deucarian.Encounters.Editor.Definitions.EncounterDefinitionSpec
        {
            DurationTicks = 120L,
            Id = "aa2e65dd52054071829baaf2b99d4bc9",
            Name = "EncounterSampleWave",
            Seed = 1,
            Waves = new global::Deucarian.Encounters.Unity.EncounterWaveData[]
            {
                new global::Deucarian.Encounters.Unity.EncounterWaveData
                {
                    BatchSize = 1,
                    Channel = global::Deucarian.Editor.Definitions.DeucarianDefinitionAssets.Load<global::Deucarian.WorldSpawning.Unity.SpawnChannelDefinitionAsset>("f1fb3fe2e4566e54f95d5c757be8e9cd", 11400000L),
                    Count = 1,
                    Id = "first",
                    IntervalTicks = 1L,
                    ScalingTier = 0,
                    Spawnable = global::Deucarian.Editor.Definitions.DeucarianDefinitionAssets.Load<global::Deucarian.WorldSpawning.Unity.SpawnableDefinitionAsset>("db5294d6162d092409506666d72b5aa2", 11400000L),
                    StartTick = 0L,
                },
            },
        };
        // end-definition-value
    }
}
