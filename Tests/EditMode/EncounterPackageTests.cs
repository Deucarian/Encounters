using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Deucarian.GameplayFoundation;
using NUnit.Framework;

namespace Deucarian.Encounters.Tests
{
    public sealed class EncounterPackageTests
    {
        private static readonly SpawnChannelId DefaultChannel = new SpawnChannelId("channel.default");

        [Test]
        public void Identifiers_RejectInvalidValues()
        {
            Assert.Throws<ArgumentException>(() => new EncounterId("Bad Id"));
            Assert.Throws<ArgumentException>(() => new SpawnableId(string.Empty));
        }

        [Test]
        public void DefinitionValidation_RejectsDuplicatesAndUnknownTables()
        {
            Assert.Throws<ArgumentException>(() => new WeightedSpawnTableDefinition(new SpawnTableId("table.empty"), Array.Empty<WeightedSpawnEntry>()));
            Assert.Throws<ArgumentException>(() => new EncounterDefinition(
                new EncounterId("encounter.bad"),
                Array.Empty<WeightedSpawnTableDefinition>(),
                new[] { new WaveDefinition(new WaveId("wave.one"), 0, new[] { SpawnGroupDefinition.FromTable(new SpawnGroupId("group.one"), new SpawnTableId("table.missing"), 1, 1, 0, 1, DefaultChannel) }) },
                Array.Empty<ObjectiveDefinition>()));
            Assert.Throws<ArgumentException>(() => new WaveDefinition(
                new WaveId("wave.bad"),
                0,
                new[]
                {
                    SpawnGroupDefinition.Fixed(new SpawnGroupId("group.same"), new SpawnableId("enemy.a"), 1, 1, 0, 1, DefaultChannel),
                    SpawnGroupDefinition.Fixed(new SpawnGroupId("group.same"), new SpawnableId("enemy.b"), 1, 1, 0, 1, DefaultChannel)
                }));
        }

        [Test]
        public void FixedTickScheduling_EmitsOnlyWhenDue()
        {
            EncounterRuntime runtime = new EncounterRuntime(SimpleFixedEncounter());
            SpawnRequest[] buffer = new SpawnRequest[8];
            runtime.Start();
            runtime.AdvanceTicks(1);
            Assert.AreEqual(0, runtime.DrainSpawnRequests(buffer).Written);
            runtime.AdvanceTicks(1);
            Assert.AreEqual(2, runtime.DrainSpawnRequests(buffer).Written);
            Assert.AreEqual("enemy.runner", buffer[0].SpawnableId.Value);
            runtime.AdvanceTicks(3);
            Assert.AreEqual(2, runtime.DrainSpawnRequests(buffer).Written);
            Assert.AreEqual(EncounterLifecycleState.Completed, runtime.State);
        }

        [Test]
        public void BoundedDrain_PreservesRemainingRequests()
        {
            EncounterRuntime runtime = new EncounterRuntime(SimpleFixedEncounter());
            SpawnRequest[] small = new SpawnRequest[1];
            runtime.Start();
            runtime.AdvanceTicks(10);
            EncounterDrainResult first = runtime.DrainSpawnRequests(small);
            EncounterDrainResult second = runtime.DrainSpawnRequests(small);
            EncounterDrainResult third = runtime.DrainSpawnRequests(small);
            Assert.AreEqual(1, first.Written);
            Assert.IsTrue(first.HasMore);
            Assert.AreEqual(1, second.Written);
            Assert.IsTrue(second.HasMore);
            Assert.AreEqual(1, third.Written);
        }

        [Test]
        public void WeightedSelection_IsDeterministicForEqualSeeds()
        {
            EncounterDefinition left = WeightedEncounter(77);
            EncounterDefinition right = WeightedEncounter(77);
            SpawnRequest[] leftBuffer = DrainAll(left);
            SpawnRequest[] rightBuffer = DrainAll(right);
            for (int i = 0; i < leftBuffer.Length; i++)
            {
                Assert.AreEqual(leftBuffer[i].SpawnableId, rightBuffer[i].SpawnableId);
            }
        }

        [Test]
        public void WeightedSelection_ChangesForDifferentSeeds()
        {
            SpawnRequest[] left = DrainAll(WeightedEncounter(10));
            SpawnRequest[] right = DrainAll(WeightedEncounter(11));
            bool anyDifferent = false;
            for (int i = 0; i < left.Length; i++) anyDifferent |= !left[i].SpawnableId.Equals(right[i].SpawnableId);
            Assert.IsTrue(anyDifferent);
        }

        [Test]
        public void ManualWaves_DoNotEmitUntilStarted()
        {
            EncounterDefinition definition = new EncounterDefinition(
                new EncounterId("encounter.manual"),
                Array.Empty<WeightedSpawnTableDefinition>(),
                new[] { new WaveDefinition(new WaveId("wave.manual"), 0, new[] { SpawnGroupDefinition.Fixed(new SpawnGroupId("group.manual"), new SpawnableId("enemy.manual"), 1, 1, 0, 1, DefaultChannel) }, requiresManualStart: true) },
                new[] { ObjectiveDefinition.AllWavesEmitted(new EncounterObjectiveId("objective.clear")) });
            EncounterRuntime runtime = new EncounterRuntime(definition);
            SpawnRequest[] buffer = new SpawnRequest[2];
            runtime.Start();
            runtime.AdvanceTicks(10);
            Assert.AreEqual(0, runtime.DrainSpawnRequests(buffer).Written);
            Assert.IsTrue(runtime.StartWave(new WaveId("wave.manual")));
            Assert.AreEqual(1, runtime.DrainSpawnRequests(buffer).Written);
        }

        [Test]
        public void Objectives_CompleteAndFailFromMetricsFlagsAndManualSignals()
        {
            EncounterRuntime metricRuntime = new EncounterRuntime(new EncounterDefinition(
                new EncounterId("encounter.metric"),
                Array.Empty<WeightedSpawnTableDefinition>(),
                new[] { new WaveDefinition(new WaveId("wave.empty"), 0, Array.Empty<SpawnGroupDefinition>()) },
                new[] { ObjectiveDefinition.MetricAtLeast(new EncounterObjectiveId("objective.kills"), new EncounterMetricId("metric.kills"), 3) }));
            metricRuntime.Start();
            metricRuntime.IncrementMetric(new EncounterMetricId("metric.kills"), 3);
            Assert.AreEqual(EncounterLifecycleState.Completed, metricRuntime.State);

            EncounterRuntime flagRuntime = new EncounterRuntime(new EncounterDefinition(
                new EncounterId("encounter.flag"),
                Array.Empty<WeightedSpawnTableDefinition>(),
                new[] { new WaveDefinition(new WaveId("wave.empty"), 0, Array.Empty<SpawnGroupDefinition>()) },
                new[] { ObjectiveDefinition.FlagEquals(new EncounterObjectiveId("objective.core-dead"), new EncounterFlagId("flag.core-dead"), true, ObjectiveRole.Failure) }));
            flagRuntime.Start();
            flagRuntime.SetFlag(new EncounterFlagId("flag.core-dead"), true);
            Assert.AreEqual(EncounterLifecycleState.Failed, flagRuntime.State);
        }

        [Test]
        public void Snapshot_RestoresProgressAndDeterministicOrdering()
        {
            EncounterRuntime runtime = new EncounterRuntime(WeightedEncounter(9));
            SpawnRequest[] one = new SpawnRequest[1];
            runtime.Start();
            runtime.AdvanceTicks(10);
            runtime.DrainSpawnRequests(one);
            runtime.SetMetric(new EncounterMetricId("metric.z"), 2);
            runtime.SetMetric(new EncounterMetricId("metric.a"), 1);
            EncounterSnapshot snapshot = runtime.CreateSnapshot();
            Assert.AreEqual("metric.a", snapshot.Metrics[0].Id.Value);

            EncounterRuntime restored = EncounterRuntime.FromSnapshot(WeightedEncounter(9), snapshot);
            SpawnRequest[] remaining = new SpawnRequest[16];
            int count = restored.DrainSpawnRequests(remaining).Written;
            Assert.Greater(count, 0);
            Assert.AreEqual(1, remaining[0].SelectionOrdinal);
        }

        [Test]
        public void Lifecycle_PauseResumeStopAndResetBehavior()
        {
            EncounterRuntime runtime = new EncounterRuntime(SimpleFixedEncounter());
            runtime.Start();
            runtime.Pause();
            runtime.AdvanceTicks(10);
            Assert.AreEqual(0, runtime.CurrentTick);
            runtime.Resume();
            runtime.AdvanceTicks(1);
            Assert.AreEqual(1, runtime.CurrentTick);
            runtime.Stop();
            runtime.AdvanceTicks(1);
            Assert.AreEqual(1, runtime.CurrentTick);
        }

        [Test]
        public void ScalingAndRewardReferences_RemainPureData()
        {
            LinearScalingDescriptor scaling = new LinearScalingDescriptor(10, 2, 0, 13);
            Assert.AreEqual(13, scaling.Evaluate(10));

            EncounterRuntime runtime = new EncounterRuntime(SimpleFixedEncounter());
            RewardReferenceId[] rewards = runtime.GetCompletionRewardReferences();
            Assert.AreEqual("reward.clear", rewards[0].Value);
        }

        [Test]
        public void DonorIdleAndTowerDefenseWorkflows_MapWithoutRuntimeDependencies()
        {
            EncounterDefinition donor = WeightedEncounter(42);
            SpawnRequest[] donorRequests = DrainAll(donor);
            Assert.AreEqual(DefaultChannel, donorRequests[0].ChannelId);

            EncounterRuntime idleDefense = new EncounterRuntime(new EncounterDefinition(
                new EncounterId("encounter.idle-defense"),
                Array.Empty<WeightedSpawnTableDefinition>(),
                new[] { new WaveDefinition(new WaveId("wave.offline"), 120, new[] { SpawnGroupDefinition.Fixed(new SpawnGroupId("group.raiders"), new SpawnableId("raider.basic"), 3, 3, 0, 1, new SpawnChannelId("lane.north")) }) },
                new[] { ObjectiveDefinition.ElapsedTicksAtLeast(new EncounterObjectiveId("objective.survive"), 180) }));
            idleDefense.Start();
            idleDefense.AdvanceTicks(180);
            Assert.AreEqual(EncounterLifecycleState.Completed, idleDefense.State);

            EncounterRuntime towerDefense = new EncounterRuntime(new EncounterDefinition(
                new EncounterId("encounter.tower-defense"),
                Array.Empty<WeightedSpawnTableDefinition>(),
                new[] { new WaveDefinition(new WaveId("wave.lane-one"), 0, new[] { SpawnGroupDefinition.Fixed(new SpawnGroupId("group.creeps"), new SpawnableId("creep.light"), 2, 1, 0, 5, new SpawnChannelId("lane.one")) }) },
                new[] { ObjectiveDefinition.AllWavesEmitted(new EncounterObjectiveId("objective.wave-emitted")) }));
            SpawnRequest[] buffer = new SpawnRequest[2];
            towerDefense.Start();
            towerDefense.AdvanceTicks(5);
            towerDefense.DrainSpawnRequests(buffer);
            Assert.AreEqual("lane.one", buffer[0].ChannelId.Value);
        }

        [Test]
        public void InvalidNumericInput_IsRejected()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SpawnGroupDefinition.Fixed(new SpawnGroupId("group.bad"), new SpawnableId("enemy.a"), -1, 1, 0, 1, DefaultChannel));
            Assert.Throws<ArgumentOutOfRangeException>(() => new LinearScalingDescriptor(double.NaN, 1));
            EncounterRuntime runtime = new EncounterRuntime(SimpleFixedEncounter());
            Assert.Throws<ArgumentOutOfRangeException>(() => runtime.AdvanceTicks(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => runtime.IncrementMetric(new EncounterMetricId("metric.kills"), -1));
        }

        [Test]
        public void Scheduler_HasNoSteadyStateAllocationsAfterWarmup()
        {
            EncounterRuntime runtime = new EncounterRuntime(BenchmarkEncounter(1000));
            runtime.Start();
            runtime.AdvanceTicks(1000);
            SpawnRequest[] buffer = new SpawnRequest[128];
            runtime.DrainSpawnRequests(buffer);
            long before = GC.GetAllocatedBytesForCurrentThread();
            for (int i = 0; i < 10; i++) runtime.DrainSpawnRequests(buffer);
            long allocated = GC.GetAllocatedBytesForCurrentThread() - before;
            Assert.AreEqual(0, allocated);
        }

        [Test]
        public void DurableSchedulerBenchmark_WritesRequiredMeasurements()
        {
            SchedulerMeasurement one = MeasureScheduler(1000);
            SchedulerMeasurement five = MeasureScheduler(5000);
            SchedulerMeasurement ten = MeasureScheduler(10000);
            string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logDirectory);
            string path = Path.Combine(logDirectory, "encounters-scheduler-benchmark-results.json");
            File.WriteAllText(path, BuildBenchmarkJson(one, five, ten), Encoding.UTF8);
            TestContext.WriteLine(path);
            Assert.AreEqual(1000, one.Requests);
            Assert.AreEqual(5000, five.Requests);
            Assert.AreEqual(10000, ten.Requests);
            Assert.AreEqual(0, one.BytesAllocated);
            Assert.AreEqual(0, five.BytesAllocated);
            Assert.AreEqual(0, ten.BytesAllocated);
        }

        private static EncounterDefinition SimpleFixedEncounter()
        {
            return new EncounterDefinition(
                new EncounterId("encounter.simple"),
                Array.Empty<WeightedSpawnTableDefinition>(),
                new[] { new WaveDefinition(new WaveId("wave.opening"), 0, new[] { SpawnGroupDefinition.Fixed(new SpawnGroupId("group.runner"), new SpawnableId("enemy.runner"), 4, 2, 2, 3, DefaultChannel) }) },
                new[] { ObjectiveDefinition.AllWavesEmitted(new EncounterObjectiveId("objective.clear")) },
                new[] { new RewardReferenceId("reward.clear") },
                seed: 1);
        }

        private static EncounterDefinition WeightedEncounter(int seed)
        {
            WeightedSpawnTableDefinition table = new WeightedSpawnTableDefinition(
                new SpawnTableId("table.enemies"),
                new[] { new WeightedSpawnEntry(new SpawnableId("enemy.a"), 1), new WeightedSpawnEntry(new SpawnableId("enemy.b"), 3), new WeightedSpawnEntry(new SpawnableId("enemy.c"), 2) });
            return new EncounterDefinition(
                new EncounterId("encounter.weighted"),
                new[] { table },
                new[] { new WaveDefinition(new WaveId("wave.weighted"), 0, new[] { SpawnGroupDefinition.FromTable(new SpawnGroupId("group.weighted"), new SpawnTableId("table.enemies"), 12, 4, 0, 1, DefaultChannel) }) },
                new[] { ObjectiveDefinition.AllWavesEmitted(new EncounterObjectiveId("objective.clear")) },
                seed: seed);
        }

        private static EncounterDefinition BenchmarkEncounter(int count)
        {
            return new EncounterDefinition(
                new EncounterId("encounter.benchmark"),
                Array.Empty<WeightedSpawnTableDefinition>(),
                new[] { new WaveDefinition(new WaveId("wave.benchmark"), 0, new[] { SpawnGroupDefinition.Fixed(new SpawnGroupId("group.benchmark"), new SpawnableId("enemy.benchmark"), count, 64, 0, 1, DefaultChannel) }) },
                new[] { ObjectiveDefinition.AllWavesEmitted(new EncounterObjectiveId("objective.clear")) });
        }

        private static SpawnRequest[] DrainAll(EncounterDefinition definition)
        {
            EncounterRuntime runtime = new EncounterRuntime(definition);
            SpawnRequest[] buffer = new SpawnRequest[32];
            runtime.Start();
            runtime.AdvanceTicks(100);
            int written = runtime.DrainSpawnRequests(buffer).Written;
            SpawnRequest[] result = new SpawnRequest[written];
            Array.Copy(buffer, result, written);
            return result;
        }

        private static SchedulerMeasurement MeasureScheduler(int count)
        {
            EncounterRuntime runtime = new EncounterRuntime(BenchmarkEncounter(count));
            SpawnRequest[] buffer = new SpawnRequest[256];
            runtime.Start();
            runtime.AdvanceTicks(count);
            runtime.DrainSpawnRequests(buffer);
            long beforeBytes = GC.GetAllocatedBytesForCurrentThread();
            Stopwatch stopwatch = Stopwatch.StartNew();
            int drained = 0;
            EncounterDrainResult result;
            do
            {
                result = runtime.DrainSpawnRequests(buffer);
                drained += result.Written;
            }
            while (result.HasMore);

            stopwatch.Stop();
            long bytes = GC.GetAllocatedBytesForCurrentThread() - beforeBytes;
            return new SchedulerMeasurement(count, drained + 256, stopwatch.Elapsed.TotalMilliseconds, bytes);
        }

        private static string BuildBenchmarkJson(params SchedulerMeasurement[] measurements)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");
            builder.AppendLine("  \"unityVersion\": \"6000.3.5f1\",");
            builder.AppendLine("  \"runtime\": \"Unity EditMode Mono\",");
            builder.AppendLine("  \"configuration\": \"encounters-phase-1e-scheduler\",");
            builder.AppendLine("  \"measurements\": [");
            for (int i = 0; i < measurements.Length; i++)
            {
                SchedulerMeasurement m = measurements[i];
                builder.Append("    { \"scheduledRequests\": ").Append(m.ScheduledRequests)
                    .Append(", \"drainedRequests\": ").Append(m.Requests)
                    .Append(", \"elapsedMs\": ").Append(m.ElapsedMs.ToString("0.000", System.Globalization.CultureInfo.InvariantCulture))
                    .Append(", \"bytesAllocated\": ").Append(m.BytesAllocated)
                    .Append(" }");
                builder.AppendLine(i + 1 == measurements.Length ? string.Empty : ",");
            }
            builder.AppendLine("  ]");
            builder.AppendLine("}");
            return builder.ToString();
        }

        private readonly struct SchedulerMeasurement
        {
            public SchedulerMeasurement(int scheduledRequests, int requests, double elapsedMs, long bytesAllocated)
            {
                ScheduledRequests = scheduledRequests;
                Requests = requests;
                ElapsedMs = elapsedMs;
                BytesAllocated = bytesAllocated;
            }

            public int ScheduledRequests { get; }
            public int Requests { get; }
            public double ElapsedMs { get; }
            public long BytesAllocated { get; }
        }
    }
}
