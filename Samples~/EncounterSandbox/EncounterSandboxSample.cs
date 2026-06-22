using System;
using Deucarian.Encounters;

namespace Deucarian.Encounters.Samples
{
    public static class EncounterSandboxSample
    {
        public static void Run()
        {
            WeightedSpawnTableDefinition table = new WeightedSpawnTableDefinition(
                new SpawnTableId("spawn-table.basic"),
                new[] { new WeightedSpawnEntry(new SpawnableId("enemy.runner"), 3), new WeightedSpawnEntry(new SpawnableId("enemy.guard"), 1) });

            EncounterDefinition definition = new EncounterDefinition(
                new EncounterId("encounter.sample"),
                new[] { table },
                new[]
                {
                    new WaveDefinition(
                        new WaveId("wave.opening"),
                        0,
                        new[] { SpawnGroupDefinition.FromTable(new SpawnGroupId("group.runners"), new SpawnTableId("spawn-table.basic"), 4, 2, 0, 3, new SpawnChannelId("channel.default")) })
                },
                new[] { ObjectiveDefinition.AllWavesEmitted(new EncounterObjectiveId("objective.clear")) },
                new[] { new RewardReferenceId("reward.sample.clear") },
                seed: 1234);

            EncounterRuntime runtime = new EncounterRuntime(definition);
            SpawnRequest[] buffer = new SpawnRequest[8];
            runtime.Start();
            runtime.AdvanceTicks(6);
            EncounterDrainResult drained = runtime.DrainSpawnRequests(buffer);
            Console.WriteLine("Spawn requests: " + drained.Written);
        }
    }
}
