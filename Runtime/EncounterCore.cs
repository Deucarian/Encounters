using System;
using System.Collections.Generic;
using Deucarian.GameplayFoundation;

namespace Deucarian.Encounters
{
    public readonly struct StageId : IEquatable<StageId>, IComparable<StageId> { private readonly ContentId _value; public StageId(string value) { _value = new ContentId(value); } public string Value => _value.Value; public bool IsEmpty => _value.IsEmpty; public bool Equals(StageId other) => _value.Equals(other._value); public override bool Equals(object obj) => obj is StageId other && Equals(other); public override int GetHashCode() => _value.GetHashCode(); public int CompareTo(StageId other) => _value.CompareTo(other._value); public override string ToString() => Value; }
    public readonly struct EncounterId : IEquatable<EncounterId>, IComparable<EncounterId> { private readonly ContentId _value; public EncounterId(string value) { _value = new ContentId(value); } public string Value => _value.Value; public bool IsEmpty => _value.IsEmpty; public bool Equals(EncounterId other) => _value.Equals(other._value); public override bool Equals(object obj) => obj is EncounterId other && Equals(other); public override int GetHashCode() => _value.GetHashCode(); public int CompareTo(EncounterId other) => _value.CompareTo(other._value); public override string ToString() => Value; }
    public readonly struct WaveId : IEquatable<WaveId>, IComparable<WaveId> { private readonly ContentId _value; public WaveId(string value) { _value = new ContentId(value); } public string Value => _value.Value; public bool IsEmpty => _value.IsEmpty; public bool Equals(WaveId other) => _value.Equals(other._value); public override bool Equals(object obj) => obj is WaveId other && Equals(other); public override int GetHashCode() => _value.GetHashCode(); public int CompareTo(WaveId other) => _value.CompareTo(other._value); public override string ToString() => Value; }
    public readonly struct SpawnGroupId : IEquatable<SpawnGroupId>, IComparable<SpawnGroupId> { private readonly ContentId _value; public SpawnGroupId(string value) { _value = new ContentId(value); } public string Value => _value.Value; public bool IsEmpty => _value.IsEmpty; public bool Equals(SpawnGroupId other) => _value.Equals(other._value); public override bool Equals(object obj) => obj is SpawnGroupId other && Equals(other); public override int GetHashCode() => _value.GetHashCode(); public int CompareTo(SpawnGroupId other) => _value.CompareTo(other._value); public override string ToString() => Value; }
    public readonly struct SpawnableId : IEquatable<SpawnableId>, IComparable<SpawnableId> { private readonly ContentId _value; public SpawnableId(string value) { _value = new ContentId(value); } public string Value => _value.Value; public bool IsEmpty => _value.IsEmpty; public bool Equals(SpawnableId other) => _value.Equals(other._value); public override bool Equals(object obj) => obj is SpawnableId other && Equals(other); public override int GetHashCode() => _value.GetHashCode(); public int CompareTo(SpawnableId other) => _value.CompareTo(other._value); public override string ToString() => Value; }
    public readonly struct SpawnTableId : IEquatable<SpawnTableId>, IComparable<SpawnTableId> { private readonly ContentId _value; public SpawnTableId(string value) { _value = new ContentId(value); } public string Value => _value.Value; public bool IsEmpty => _value.IsEmpty; public bool Equals(SpawnTableId other) => _value.Equals(other._value); public override bool Equals(object obj) => obj is SpawnTableId other && Equals(other); public override int GetHashCode() => _value.GetHashCode(); public int CompareTo(SpawnTableId other) => _value.CompareTo(other._value); public override string ToString() => Value; }
    public readonly struct SpawnChannelId : IEquatable<SpawnChannelId>, IComparable<SpawnChannelId> { private readonly ContentId _value; public SpawnChannelId(string value) { _value = new ContentId(value); } public string Value => _value.Value; public bool IsEmpty => _value.IsEmpty; public bool Equals(SpawnChannelId other) => _value.Equals(other._value); public override bool Equals(object obj) => obj is SpawnChannelId other && Equals(other); public override int GetHashCode() => _value.GetHashCode(); public int CompareTo(SpawnChannelId other) => _value.CompareTo(other._value); public override string ToString() => Value; }
    public readonly struct EncounterMetricId : IEquatable<EncounterMetricId>, IComparable<EncounterMetricId> { private readonly ContentId _value; public EncounterMetricId(string value) { _value = new ContentId(value); } public string Value => _value.Value; public bool IsEmpty => _value.IsEmpty; public bool Equals(EncounterMetricId other) => _value.Equals(other._value); public override bool Equals(object obj) => obj is EncounterMetricId other && Equals(other); public override int GetHashCode() => _value.GetHashCode(); public int CompareTo(EncounterMetricId other) => _value.CompareTo(other._value); public override string ToString() => Value; }
    public readonly struct EncounterFlagId : IEquatable<EncounterFlagId>, IComparable<EncounterFlagId> { private readonly ContentId _value; public EncounterFlagId(string value) { _value = new ContentId(value); } public string Value => _value.Value; public bool IsEmpty => _value.IsEmpty; public bool Equals(EncounterFlagId other) => _value.Equals(other._value); public override bool Equals(object obj) => obj is EncounterFlagId other && Equals(other); public override int GetHashCode() => _value.GetHashCode(); public int CompareTo(EncounterFlagId other) => _value.CompareTo(other._value); public override string ToString() => Value; }
    public readonly struct EncounterObjectiveId : IEquatable<EncounterObjectiveId>, IComparable<EncounterObjectiveId> { private readonly ContentId _value; public EncounterObjectiveId(string value) { _value = new ContentId(value); } public string Value => _value.Value; public bool IsEmpty => _value.IsEmpty; public bool Equals(EncounterObjectiveId other) => _value.Equals(other._value); public override bool Equals(object obj) => obj is EncounterObjectiveId other && Equals(other); public override int GetHashCode() => _value.GetHashCode(); public int CompareTo(EncounterObjectiveId other) => _value.CompareTo(other._value); public override string ToString() => Value; }
    public readonly struct RewardReferenceId : IEquatable<RewardReferenceId>, IComparable<RewardReferenceId> { private readonly ContentId _value; public RewardReferenceId(string value) { _value = new ContentId(value); } public string Value => _value.Value; public bool IsEmpty => _value.IsEmpty; public bool Equals(RewardReferenceId other) => _value.Equals(other._value); public override bool Equals(object obj) => obj is RewardReferenceId other && Equals(other); public override int GetHashCode() => _value.GetHashCode(); public int CompareTo(RewardReferenceId other) => _value.CompareTo(other._value); public override string ToString() => Value; }

    public enum EncounterLifecycleState { Created = 0, Running = 1, Paused = 2, Completed = 3, Failed = 4, Stopped = 5 }
    public enum ObjectiveRole { Completion = 0, Failure = 1 }
    public enum ObjectiveKind { AllWavesEmitted = 0, ElapsedTicksAtLeast = 1, MetricAtLeast = 2, MetricAtMost = 3, FlagEquals = 4, Manual = 5 }

    public sealed class StageDefinition
    {
        private readonly RewardReferenceId[] _rewards;
        public StageDefinition(StageId id, EncounterId encounterId, IReadOnlyList<RewardReferenceId> rewardReferences = null)
        {
            if (id.IsEmpty) throw new ArgumentException("Stage id cannot be empty.", nameof(id));
            if (encounterId.IsEmpty) throw new ArgumentException("Encounter id cannot be empty.", nameof(encounterId));
            Id = id; EncounterId = encounterId; _rewards = Copy(rewardReferences);
        }
        public StageId Id { get; }
        public EncounterId EncounterId { get; }
        public IReadOnlyList<RewardReferenceId> RewardReferences => _rewards;
        private static RewardReferenceId[] Copy(IReadOnlyList<RewardReferenceId> source) { if (source == null) return Array.Empty<RewardReferenceId>(); var copy = new RewardReferenceId[source.Count]; for (int i = 0; i < source.Count; i++) { if (source[i].IsEmpty) throw new ArgumentException("Reward id cannot be empty."); copy[i] = source[i]; } return copy; }
    }

    public readonly struct WeightedSpawnEntry
    {
        public WeightedSpawnEntry(SpawnableId spawnableId, int weight)
        {
            if (spawnableId.IsEmpty) throw new ArgumentException("Spawnable id cannot be empty.", nameof(spawnableId));
            if (weight <= 0) throw new ArgumentOutOfRangeException(nameof(weight), "Weight must be positive.");
            SpawnableId = spawnableId; Weight = weight;
        }
        public SpawnableId SpawnableId { get; }
        public int Weight { get; }
    }

    public sealed class WeightedSpawnTableDefinition
    {
        private readonly WeightedSpawnEntry[] _entries;
        public WeightedSpawnTableDefinition(SpawnTableId id, IReadOnlyList<WeightedSpawnEntry> entries)
        {
            if (id.IsEmpty) throw new ArgumentException("Spawn table id cannot be empty.", nameof(id));
            if (entries == null || entries.Count == 0) throw new ArgumentException("Spawn table needs entries.", nameof(entries));
            _entries = new WeightedSpawnEntry[entries.Count];
            long total = 0;
            for (int i = 0; i < entries.Count; i++) { _entries[i] = entries[i]; total += entries[i].Weight; if (total > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(entries), "Total weight is too large."); }
            Array.Sort(_entries, (left, right) => left.SpawnableId.CompareTo(right.SpawnableId));
            Id = id; TotalWeight = (int)total;
        }
        public SpawnTableId Id { get; }
        public int TotalWeight { get; }
        public IReadOnlyList<WeightedSpawnEntry> Entries => _entries;
    }

    public sealed class SpawnGroupDefinition
    {
        private SpawnGroupDefinition(SpawnGroupId id, SpawnableId spawnableId, SpawnTableId tableId, int count, int batchSize, long initialDelayTicks, long intervalTicks, SpawnChannelId channelId, int scalingTier, IReadOnlyList<GameplayTag> tags)
        {
            if (id.IsEmpty) throw new ArgumentException("Spawn group id cannot be empty.", nameof(id));
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (batchSize <= 0) throw new ArgumentOutOfRangeException(nameof(batchSize));
            if (initialDelayTicks < 0 || intervalTicks < 0) throw new ArgumentOutOfRangeException(nameof(intervalTicks));
            if (channelId.IsEmpty) throw new ArgumentException("Channel id cannot be empty.", nameof(channelId));
            if (spawnableId.IsEmpty == tableId.IsEmpty) throw new ArgumentException("A spawn group must reference exactly one spawnable id or spawn table id.");
            Id = id; SpawnableId = spawnableId; SpawnTableId = tableId; Count = count; BatchSize = batchSize; InitialDelayTicks = initialDelayTicks; IntervalTicks = intervalTicks; ChannelId = channelId; ScalingTier = scalingTier; Tags = Copy(tags);
        }
        public SpawnGroupId Id { get; }
        public SpawnableId SpawnableId { get; }
        public SpawnTableId SpawnTableId { get; }
        public int Count { get; }
        public int BatchSize { get; }
        public long InitialDelayTicks { get; }
        public long IntervalTicks { get; }
        public SpawnChannelId ChannelId { get; }
        public int ScalingTier { get; }
        public IReadOnlyList<GameplayTag> Tags { get; }
        public static SpawnGroupDefinition Fixed(SpawnGroupId id, SpawnableId spawnableId, int count, int batchSize, long initialDelayTicks, long intervalTicks, SpawnChannelId channelId, int scalingTier = 0, IReadOnlyList<GameplayTag> tags = null) => new SpawnGroupDefinition(id, spawnableId, default, count, batchSize, initialDelayTicks, intervalTicks, channelId, scalingTier, tags);
        public static SpawnGroupDefinition FromTable(SpawnGroupId id, SpawnTableId tableId, int count, int batchSize, long initialDelayTicks, long intervalTicks, SpawnChannelId channelId, int scalingTier = 0, IReadOnlyList<GameplayTag> tags = null) => new SpawnGroupDefinition(id, default, tableId, count, batchSize, initialDelayTicks, intervalTicks, channelId, scalingTier, tags);
        private static GameplayTag[] Copy(IReadOnlyList<GameplayTag> source) { if (source == null) return Array.Empty<GameplayTag>(); var copy = new GameplayTag[source.Count]; for (int i = 0; i < source.Count; i++) { if (source[i].IsEmpty) throw new ArgumentException("Tag cannot be empty."); copy[i] = source[i]; } return copy; }
    }

    public sealed class WaveDefinition
    {
        private readonly SpawnGroupDefinition[] _groups;
        private readonly RewardReferenceId[] _rewards;
        public WaveDefinition(WaveId id, long startTick, IReadOnlyList<SpawnGroupDefinition> spawnGroups, bool requiresManualStart = false, IReadOnlyList<RewardReferenceId> rewardReferences = null)
        {
            if (id.IsEmpty) throw new ArgumentException("Wave id cannot be empty.", nameof(id));
            if (startTick < 0) throw new ArgumentOutOfRangeException(nameof(startTick));
            if (spawnGroups == null) throw new ArgumentNullException(nameof(spawnGroups));
            Id = id; StartTick = startTick; RequiresManualStart = requiresManualStart; _groups = CopyGroups(spawnGroups); _rewards = CopyRewards(rewardReferences);
        }
        public WaveId Id { get; }
        public long StartTick { get; }
        public bool RequiresManualStart { get; }
        public IReadOnlyList<SpawnGroupDefinition> SpawnGroups => _groups;
        public IReadOnlyList<RewardReferenceId> RewardReferences => _rewards;
        private static SpawnGroupDefinition[] CopyGroups(IReadOnlyList<SpawnGroupDefinition> source) { var copy = new SpawnGroupDefinition[source.Count]; var seen = new HashSet<SpawnGroupId>(); for (int i = 0; i < source.Count; i++) { copy[i] = source[i] ?? throw new ArgumentException("Spawn group cannot be null."); if (!seen.Add(copy[i].Id)) throw new ArgumentException("Duplicate spawn group id: " + copy[i].Id); } return copy; }
        private static RewardReferenceId[] CopyRewards(IReadOnlyList<RewardReferenceId> source) { if (source == null) return Array.Empty<RewardReferenceId>(); var copy = new RewardReferenceId[source.Count]; for (int i = 0; i < source.Count; i++) copy[i] = source[i]; return copy; }
    }

    public sealed class ObjectiveDefinition
    {
        public ObjectiveDefinition(EncounterObjectiveId id, ObjectiveKind kind, ObjectiveRole role = ObjectiveRole.Completion, long threshold = 0, EncounterMetricId metricId = default, EncounterFlagId flagId = default, bool expectedFlagValue = true)
        {
            if (id.IsEmpty) throw new ArgumentException("Objective id cannot be empty.", nameof(id));
            if (threshold < 0) throw new ArgumentOutOfRangeException(nameof(threshold));
            Id = id; Kind = kind; Role = role; Threshold = threshold; MetricId = metricId; FlagId = flagId; ExpectedFlagValue = expectedFlagValue;
        }
        public EncounterObjectiveId Id { get; }
        public ObjectiveKind Kind { get; }
        public ObjectiveRole Role { get; }
        public long Threshold { get; }
        public EncounterMetricId MetricId { get; }
        public EncounterFlagId FlagId { get; }
        public bool ExpectedFlagValue { get; }
        public static ObjectiveDefinition AllWavesEmitted(EncounterObjectiveId id, ObjectiveRole role = ObjectiveRole.Completion) => new ObjectiveDefinition(id, ObjectiveKind.AllWavesEmitted, role);
        public static ObjectiveDefinition ElapsedTicksAtLeast(EncounterObjectiveId id, long ticks, ObjectiveRole role = ObjectiveRole.Completion) => new ObjectiveDefinition(id, ObjectiveKind.ElapsedTicksAtLeast, role, ticks);
        public static ObjectiveDefinition MetricAtLeast(EncounterObjectiveId id, EncounterMetricId metricId, long threshold, ObjectiveRole role = ObjectiveRole.Completion) => new ObjectiveDefinition(id, ObjectiveKind.MetricAtLeast, role, threshold, metricId);
        public static ObjectiveDefinition MetricAtMost(EncounterObjectiveId id, EncounterMetricId metricId, long threshold, ObjectiveRole role = ObjectiveRole.Failure) => new ObjectiveDefinition(id, ObjectiveKind.MetricAtMost, role, threshold, metricId);
        public static ObjectiveDefinition FlagEquals(EncounterObjectiveId id, EncounterFlagId flagId, bool expected, ObjectiveRole role) => new ObjectiveDefinition(id, ObjectiveKind.FlagEquals, role, 0, default, flagId, expected);
        public static ObjectiveDefinition Manual(EncounterObjectiveId id, ObjectiveRole role) => new ObjectiveDefinition(id, ObjectiveKind.Manual, role);
    }

    public readonly struct LinearScalingDescriptor
    {
        public LinearScalingDescriptor(double baseValue, double perTier, double minValue = 0d, double maxValue = double.MaxValue)
        {
            RequireFinite(baseValue, nameof(baseValue)); RequireFinite(perTier, nameof(perTier)); RequireFinite(minValue, nameof(minValue)); RequireFinite(maxValue, nameof(maxValue));
            if (maxValue < minValue) throw new ArgumentOutOfRangeException(nameof(maxValue));
            BaseValue = baseValue; PerTier = perTier; MinValue = minValue; MaxValue = maxValue;
        }
        public double BaseValue { get; }
        public double PerTier { get; }
        public double MinValue { get; }
        public double MaxValue { get; }
        public double Evaluate(int tier) => Math.Min(MaxValue, Math.Max(MinValue, BaseValue + (PerTier * tier)));
        private static void RequireFinite(double value, string name) { if (double.IsNaN(value) || double.IsInfinity(value)) throw new ArgumentOutOfRangeException(name); }
    }

    public sealed class EncounterDefinition
    {
        private readonly WeightedSpawnTableDefinition[] _tables;
        private readonly WaveDefinition[] _waves;
        private readonly ObjectiveDefinition[] _objectives;
        private readonly RewardReferenceId[] _rewards;
        private readonly Dictionary<SpawnTableId, WeightedSpawnTableDefinition> _tableMap;
        public EncounterDefinition(EncounterId id, IReadOnlyList<WeightedSpawnTableDefinition> spawnTables, IReadOnlyList<WaveDefinition> waves, IReadOnlyList<ObjectiveDefinition> objectives, IReadOnlyList<RewardReferenceId> rewardReferences = null, int seed = 0)
        {
            if (id.IsEmpty) throw new ArgumentException("Encounter id cannot be empty.", nameof(id));
            Id = id; Seed = seed; _tables = CopyTables(spawnTables); _tableMap = BuildTableMap(_tables); _waves = CopyWaves(waves); _objectives = CopyObjectives(objectives); _rewards = CopyRewards(rewardReferences); ValidateTableReferences(_waves, _tableMap);
        }
        public EncounterId Id { get; }
        public int Seed { get; }
        public IReadOnlyList<WeightedSpawnTableDefinition> SpawnTables => _tables;
        public IReadOnlyList<WaveDefinition> Waves => _waves;
        public IReadOnlyList<ObjectiveDefinition> Objectives => _objectives;
        public IReadOnlyList<RewardReferenceId> RewardReferences => _rewards;
        public bool TryGetSpawnTable(SpawnTableId id, out WeightedSpawnTableDefinition table) => _tableMap.TryGetValue(id, out table);
        private static WeightedSpawnTableDefinition[] CopyTables(IReadOnlyList<WeightedSpawnTableDefinition> source) { if (source == null) return Array.Empty<WeightedSpawnTableDefinition>(); var copy = new WeightedSpawnTableDefinition[source.Count]; for (int i = 0; i < source.Count; i++) copy[i] = source[i] ?? throw new ArgumentException("Spawn table cannot be null."); return copy; }
        private static Dictionary<SpawnTableId, WeightedSpawnTableDefinition> BuildTableMap(IReadOnlyList<WeightedSpawnTableDefinition> tables) { var map = new Dictionary<SpawnTableId, WeightedSpawnTableDefinition>(); for (int i = 0; i < tables.Count; i++) { if (map.ContainsKey(tables[i].Id)) throw new ArgumentException("Duplicate spawn table id: " + tables[i].Id); map.Add(tables[i].Id, tables[i]); } return map; }
        private static WaveDefinition[] CopyWaves(IReadOnlyList<WaveDefinition> source) { if (source == null || source.Count == 0) throw new ArgumentException("Encounter needs at least one wave.", nameof(source)); var copy = new WaveDefinition[source.Count]; var seen = new HashSet<WaveId>(); for (int i = 0; i < source.Count; i++) { copy[i] = source[i] ?? throw new ArgumentException("Wave cannot be null."); if (!seen.Add(copy[i].Id)) throw new ArgumentException("Duplicate wave id: " + copy[i].Id); } Array.Sort(copy, (left, right) => left.StartTick != right.StartTick ? left.StartTick.CompareTo(right.StartTick) : left.Id.CompareTo(right.Id)); return copy; }
        private static ObjectiveDefinition[] CopyObjectives(IReadOnlyList<ObjectiveDefinition> source) { if (source == null) return Array.Empty<ObjectiveDefinition>(); var copy = new ObjectiveDefinition[source.Count]; var seen = new HashSet<EncounterObjectiveId>(); for (int i = 0; i < source.Count; i++) { copy[i] = source[i] ?? throw new ArgumentException("Objective cannot be null."); if (!seen.Add(copy[i].Id)) throw new ArgumentException("Duplicate objective id: " + copy[i].Id); } return copy; }
        private static RewardReferenceId[] CopyRewards(IReadOnlyList<RewardReferenceId> source) { if (source == null) return Array.Empty<RewardReferenceId>(); var copy = new RewardReferenceId[source.Count]; for (int i = 0; i < source.Count; i++) { if (source[i].IsEmpty) throw new ArgumentException("Reward reference cannot be empty."); copy[i] = source[i]; } return copy; }
        private static void ValidateTableReferences(IReadOnlyList<WaveDefinition> waves, Dictionary<SpawnTableId, WeightedSpawnTableDefinition> tableMap) { for (int w = 0; w < waves.Count; w++) for (int g = 0; g < waves[w].SpawnGroups.Count; g++) { SpawnGroupDefinition group = waves[w].SpawnGroups[g]; if (!group.SpawnTableId.IsEmpty && !tableMap.ContainsKey(group.SpawnTableId)) throw new ArgumentException("Unknown spawn table id: " + group.SpawnTableId); } }
    }

    public readonly struct SpawnRequest
    {
        public SpawnRequest(EncounterId encounterId, WaveId waveId, SpawnGroupId groupId, SpawnableId spawnableId, SpawnChannelId channelId, long scheduledTick, long sequence, int scalingTier, long selectionOrdinal)
        {
            EncounterId = encounterId; WaveId = waveId; GroupId = groupId; SpawnableId = spawnableId; ChannelId = channelId; ScheduledTick = scheduledTick; Sequence = sequence; ScalingTier = scalingTier; SelectionOrdinal = selectionOrdinal;
        }
        public EncounterId EncounterId { get; }
        public WaveId WaveId { get; }
        public SpawnGroupId GroupId { get; }
        public SpawnableId SpawnableId { get; }
        public SpawnChannelId ChannelId { get; }
        public long ScheduledTick { get; }
        public long Sequence { get; }
        public int ScalingTier { get; }
        public long SelectionOrdinal { get; }
    }

    public readonly struct EncounterDrainResult { public EncounterDrainResult(int written, bool hasMore) { Written = written; HasMore = hasMore; } public int Written { get; } public bool HasMore { get; } }
    public readonly struct WaveProgressSnapshot { public WaveProgressSnapshot(WaveId waveId, bool started, bool emitted) { WaveId = waveId; Started = started; Emitted = emitted; } public WaveId WaveId { get; } public bool Started { get; } public bool Emitted { get; } }
    public readonly struct SpawnGroupProgressSnapshot { public SpawnGroupProgressSnapshot(WaveId waveId, SpawnGroupId groupId, int emittedCount) { WaveId = waveId; GroupId = groupId; EmittedCount = emittedCount; } public WaveId WaveId { get; } public SpawnGroupId GroupId { get; } public int EmittedCount { get; } }
    public readonly struct EncounterMetricSnapshot { public EncounterMetricSnapshot(EncounterMetricId id, long value) { Id = id; Value = value; } public EncounterMetricId Id { get; } public long Value { get; } }
    public readonly struct EncounterFlagSnapshot { public EncounterFlagSnapshot(EncounterFlagId id, bool value) { Id = id; Value = value; } public EncounterFlagId Id { get; } public bool Value { get; } }
    public readonly struct EncounterObjectiveSnapshot { public EncounterObjectiveSnapshot(EncounterObjectiveId id, bool satisfied) { Id = id; Satisfied = satisfied; } public EncounterObjectiveId Id { get; } public bool Satisfied { get; } }

    public sealed class EncounterSnapshot
    {
        public EncounterSnapshot(EncounterId encounterId, EncounterLifecycleState state, long currentTick, long nextSequence, IReadOnlyList<WaveProgressSnapshot> waves, IReadOnlyList<SpawnGroupProgressSnapshot> groups, IReadOnlyList<EncounterMetricSnapshot> metrics, IReadOnlyList<EncounterFlagSnapshot> flags, IReadOnlyList<EncounterObjectiveSnapshot> objectives)
        {
            EncounterId = encounterId; State = state; CurrentTick = currentTick; NextSequence = nextSequence; Waves = Copy(waves); Groups = Copy(groups); Metrics = Copy(metrics); Flags = Copy(flags); Objectives = Copy(objectives);
        }
        public EncounterId EncounterId { get; }
        public EncounterLifecycleState State { get; }
        public long CurrentTick { get; }
        public long NextSequence { get; }
        public IReadOnlyList<WaveProgressSnapshot> Waves { get; }
        public IReadOnlyList<SpawnGroupProgressSnapshot> Groups { get; }
        public IReadOnlyList<EncounterMetricSnapshot> Metrics { get; }
        public IReadOnlyList<EncounterFlagSnapshot> Flags { get; }
        public IReadOnlyList<EncounterObjectiveSnapshot> Objectives { get; }
        private static T[] Copy<T>(IReadOnlyList<T> source) { if (source == null) return Array.Empty<T>(); var copy = new T[source.Count]; for (int i = 0; i < source.Count; i++) copy[i] = source[i]; return copy; }
    }

    public static class WeightedSpawnSelector
    {
        public static SpawnableId Select(WeightedSpawnTableDefinition table, int seed, long ordinal)
        {
            if (table == null) throw new ArgumentNullException(nameof(table));
            uint value = Hash(seed, table.Id.Value, ordinal);
            int roll = (int)(value % (uint)table.TotalWeight);
            int running = 0;
            for (int i = 0; i < table.Entries.Count; i++) { running += table.Entries[i].Weight; if (roll < running) return table.Entries[i].SpawnableId; }
            return table.Entries[table.Entries.Count - 1].SpawnableId;
        }
        private static uint Hash(int seed, string table, long ordinal)
        {
            unchecked
            {
                uint hash = 2166136261u ^ (uint)seed;
                for (int i = 0; i < table.Length; i++) { hash ^= table[i]; hash *= 16777619u; }
                hash ^= (uint)ordinal; hash *= 16777619u; hash ^= (uint)(ordinal >> 32); hash *= 16777619u;
                hash ^= hash >> 16; hash *= 0x7feb352du; hash ^= hash >> 15; hash *= 0x846ca68bu; hash ^= hash >> 16;
                return hash;
            }
        }
    }

    public sealed class EncounterRuntime
    {
        private readonly WaveState[] _waves;
        private readonly Dictionary<EncounterMetricId, long> _metrics = new Dictionary<EncounterMetricId, long>();
        private readonly Dictionary<EncounterFlagId, bool> _flags = new Dictionary<EncounterFlagId, bool>();
        private readonly HashSet<EncounterObjectiveId> _manual = new HashSet<EncounterObjectiveId>();
        private long _nextSequence;
        public EncounterRuntime(EncounterDefinition definition)
        {
            Definition = definition ?? throw new ArgumentNullException(nameof(definition));
            _waves = new WaveState[definition.Waves.Count];
            for (int i = 0; i < _waves.Length; i++) _waves[i] = new WaveState(definition.Waves[i]);
            State = EncounterLifecycleState.Created;
        }
        public EncounterDefinition Definition { get; }
        public EncounterLifecycleState State { get; private set; }
        public long CurrentTick { get; private set; }
        public void Start() { if (State != EncounterLifecycleState.Created && State != EncounterLifecycleState.Stopped) throw new InvalidOperationException("Encounter cannot start from current state."); State = EncounterLifecycleState.Running; EvaluateTerminalState(); }
        public void Pause() { if (State == EncounterLifecycleState.Running) State = EncounterLifecycleState.Paused; }
        public void Resume() { if (State == EncounterLifecycleState.Paused) State = EncounterLifecycleState.Running; }
        public void Stop() { State = EncounterLifecycleState.Stopped; }
        public void AdvanceTicks(long ticks) { if (ticks < 0) throw new ArgumentOutOfRangeException(nameof(ticks)); if (State != EncounterLifecycleState.Running) return; CurrentTick = checked(CurrentTick + ticks); EvaluateTerminalState(); }
        public bool StartWave(WaveId waveId) { for (int i = 0; i < _waves.Length; i++) if (_waves[i].Definition.Id.Equals(waveId)) { _waves[i].ManualStarted = true; return true; } return false; }
        public void SetMetric(EncounterMetricId id, long value) { if (id.IsEmpty) throw new ArgumentException("Metric id cannot be empty.", nameof(id)); if (value < 0) throw new ArgumentOutOfRangeException(nameof(value)); _metrics[id] = value; EvaluateTerminalState(); }
        public void IncrementMetric(EncounterMetricId id, long delta) { if (delta < 0) throw new ArgumentOutOfRangeException(nameof(delta)); _metrics.TryGetValue(id, out long current); SetMetric(id, checked(current + delta)); }
        public long GetMetric(EncounterMetricId id) { _metrics.TryGetValue(id, out long value); return value; }
        public void SetFlag(EncounterFlagId id, bool value) { if (id.IsEmpty) throw new ArgumentException("Flag id cannot be empty.", nameof(id)); _flags[id] = value; EvaluateTerminalState(); }
        public bool GetFlag(EncounterFlagId id) { _flags.TryGetValue(id, out bool value); return value; }
        public void SatisfyManualObjective(EncounterObjectiveId id) { if (id.IsEmpty) throw new ArgumentException("Objective id cannot be empty.", nameof(id)); _manual.Add(id); EvaluateTerminalState(); }
        public EncounterDrainResult DrainSpawnRequests(SpawnRequest[] buffer)
        {
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            int written = 0;
            while (written < buffer.Length && TryFindNextDue(out int waveIndex, out int groupIndex, out long dueTick))
            {
                WaveState wave = _waves[waveIndex];
                SpawnGroupState group = wave.Groups[groupIndex];
                SpawnGroupDefinition definition = group.Definition;
                long selectionOrdinal = group.EmittedCount;
                SpawnableId spawnable = definition.SpawnableId;
                if (!definition.SpawnTableId.IsEmpty)
                {
                    Definition.TryGetSpawnTable(definition.SpawnTableId, out WeightedSpawnTableDefinition table);
                    spawnable = WeightedSpawnSelector.Select(table, Definition.Seed, selectionOrdinal);
                }
                buffer[written++] = new SpawnRequest(Definition.Id, wave.Definition.Id, definition.Id, spawnable, definition.ChannelId, dueTick, _nextSequence++, definition.ScalingTier, selectionOrdinal);
                group.EmittedCount++;
                wave.Groups[groupIndex] = group;
                wave.Emitted = AreGroupsEmitted(wave);
                _waves[waveIndex] = wave;
            }
            bool hasMore = TryFindNextDue(out _, out _, out _);
            EvaluateTerminalState();
            return new EncounterDrainResult(written, hasMore);
        }
        public EncounterSnapshot CreateSnapshot()
        {
            var waves = new WaveProgressSnapshot[_waves.Length];
            int groupCount = 0; for (int i = 0; i < _waves.Length; i++) groupCount += _waves[i].Groups.Length;
            var groups = new SpawnGroupProgressSnapshot[groupCount];
            int groupCursor = 0;
            for (int i = 0; i < _waves.Length; i++) { waves[i] = new WaveProgressSnapshot(_waves[i].Definition.Id, IsWaveStarted(_waves[i]), _waves[i].Emitted); for (int g = 0; g < _waves[i].Groups.Length; g++) groups[groupCursor++] = new SpawnGroupProgressSnapshot(_waves[i].Definition.Id, _waves[i].Groups[g].Definition.Id, _waves[i].Groups[g].EmittedCount); }
            return new EncounterSnapshot(Definition.Id, State, CurrentTick, _nextSequence, waves, groups, CopyMetrics(), CopyFlags(), CopyObjectives());
        }
        public static EncounterRuntime FromSnapshot(EncounterDefinition definition, EncounterSnapshot snapshot)
        {
            if (definition == null) throw new ArgumentNullException(nameof(definition));
            if (snapshot == null) throw new ArgumentNullException(nameof(snapshot));
            if (!definition.Id.Equals(snapshot.EncounterId)) throw new ArgumentException("Snapshot encounter id does not match definition.", nameof(snapshot));
            var runtime = new EncounterRuntime(definition) { State = snapshot.State, CurrentTick = snapshot.CurrentTick, _nextSequence = snapshot.NextSequence };
            for (int i = 0; i < snapshot.Waves.Count; i++) if (TryFindWave(runtime._waves, snapshot.Waves[i].WaveId, out int wi)) { runtime._waves[wi].ManualStarted = snapshot.Waves[i].Started; runtime._waves[wi].Emitted = snapshot.Waves[i].Emitted; }
            for (int i = 0; i < snapshot.Groups.Count; i++) if (TryFindWave(runtime._waves, snapshot.Groups[i].WaveId, out int wi)) for (int g = 0; g < runtime._waves[wi].Groups.Length; g++) if (runtime._waves[wi].Groups[g].Definition.Id.Equals(snapshot.Groups[i].GroupId)) { runtime._waves[wi].Groups[g].EmittedCount = snapshot.Groups[i].EmittedCount; break; }
            for (int i = 0; i < snapshot.Metrics.Count; i++) runtime._metrics[snapshot.Metrics[i].Id] = snapshot.Metrics[i].Value;
            for (int i = 0; i < snapshot.Flags.Count; i++) runtime._flags[snapshot.Flags[i].Id] = snapshot.Flags[i].Value;
            for (int i = 0; i < snapshot.Objectives.Count; i++) if (snapshot.Objectives[i].Satisfied) runtime._manual.Add(snapshot.Objectives[i].Id);
            return runtime;
        }
        public RewardReferenceId[] GetCompletionRewardReferences() { var copy = new RewardReferenceId[Definition.RewardReferences.Count]; for (int i = 0; i < copy.Length; i++) copy[i] = Definition.RewardReferences[i]; return copy; }
        private bool TryFindNextDue(out int waveIndex, out int groupIndex, out long dueTick)
        {
            waveIndex = -1; groupIndex = -1; dueTick = long.MaxValue;
            for (int w = 0; w < _waves.Length; w++)
            {
                WaveState wave = _waves[w];
                if (!IsWaveStarted(wave)) continue;
                for (int g = 0; g < wave.Groups.Length; g++)
                {
                    SpawnGroupState group = wave.Groups[g];
                    if (group.EmittedCount >= group.Definition.Count) continue;
                    long candidate = DueTick(wave.Definition, group.Definition, group.EmittedCount);
                    if (candidate > CurrentTick) continue;
                    if (candidate < dueTick || candidate == dueTick && CompareDue(w, g, waveIndex, groupIndex) < 0) { waveIndex = w; groupIndex = g; dueTick = candidate; }
                }
            }
            return waveIndex >= 0;
        }
        private int CompareDue(int w, int g, int currentW, int currentG) { if (currentW < 0) return -1; int wave = _waves[w].Definition.Id.CompareTo(_waves[currentW].Definition.Id); if (wave != 0) return wave; return _waves[w].Groups[g].Definition.Id.CompareTo(_waves[currentW].Groups[currentG].Definition.Id); }
        private static long DueTick(WaveDefinition wave, SpawnGroupDefinition group, int emittedCount) => checked(wave.StartTick + group.InitialDelayTicks + ((emittedCount / group.BatchSize) * group.IntervalTicks));
        private bool IsWaveStarted(WaveState wave) => CurrentTick >= wave.Definition.StartTick && (!wave.Definition.RequiresManualStart || wave.ManualStarted);
        private static bool AreGroupsEmitted(WaveState wave) { for (int i = 0; i < wave.Groups.Length; i++) if (wave.Groups[i].EmittedCount < wave.Groups[i].Definition.Count) return false; return true; }
        private bool AreAllWavesEmitted() { for (int i = 0; i < _waves.Length; i++) if (!_waves[i].Emitted) return false; return true; }
        private void EvaluateTerminalState()
        {
            if (State != EncounterLifecycleState.Running && State != EncounterLifecycleState.Paused) return;
            bool hasCompletion = false; bool completionSatisfied = false;
            for (int i = 0; i < Definition.Objectives.Count; i++)
            {
                ObjectiveDefinition objective = Definition.Objectives[i];
                bool satisfied = IsObjectiveSatisfied(objective);
                if (objective.Role == ObjectiveRole.Failure && satisfied) { State = EncounterLifecycleState.Failed; return; }
                if (objective.Role == ObjectiveRole.Completion) { hasCompletion = true; completionSatisfied |= satisfied; }
            }
            if (hasCompletion && completionSatisfied) State = EncounterLifecycleState.Completed;
        }
        private bool IsObjectiveSatisfied(ObjectiveDefinition objective)
        {
            switch (objective.Kind)
            {
                case ObjectiveKind.AllWavesEmitted: return AreAllWavesEmitted();
                case ObjectiveKind.ElapsedTicksAtLeast: return CurrentTick >= objective.Threshold;
                case ObjectiveKind.MetricAtLeast: return GetMetric(objective.MetricId) >= objective.Threshold;
                case ObjectiveKind.MetricAtMost: return GetMetric(objective.MetricId) <= objective.Threshold;
                case ObjectiveKind.FlagEquals: return GetFlag(objective.FlagId) == objective.ExpectedFlagValue;
                case ObjectiveKind.Manual: return _manual.Contains(objective.Id);
                default: return false;
            }
        }
        private EncounterMetricSnapshot[] CopyMetrics() { var array = new EncounterMetricSnapshot[_metrics.Count]; int i = 0; foreach (var pair in _metrics) array[i++] = new EncounterMetricSnapshot(pair.Key, pair.Value); Array.Sort(array, (left, right) => left.Id.CompareTo(right.Id)); return array; }
        private EncounterFlagSnapshot[] CopyFlags() { var array = new EncounterFlagSnapshot[_flags.Count]; int i = 0; foreach (var pair in _flags) array[i++] = new EncounterFlagSnapshot(pair.Key, pair.Value); Array.Sort(array, (left, right) => left.Id.CompareTo(right.Id)); return array; }
        private EncounterObjectiveSnapshot[] CopyObjectives() { var array = new EncounterObjectiveSnapshot[Definition.Objectives.Count]; for (int i = 0; i < array.Length; i++) array[i] = new EncounterObjectiveSnapshot(Definition.Objectives[i].Id, IsObjectiveSatisfied(Definition.Objectives[i])); return array; }
        private static bool TryFindWave(WaveState[] waves, WaveId id, out int index) { for (index = 0; index < waves.Length; index++) if (waves[index].Definition.Id.Equals(id)) return true; index = -1; return false; }
        private sealed class WaveState { public WaveState(WaveDefinition definition) { Definition = definition; Groups = new SpawnGroupState[definition.SpawnGroups.Count]; for (int i = 0; i < Groups.Length; i++) Groups[i] = new SpawnGroupState(definition.SpawnGroups[i]); } public WaveDefinition Definition; public SpawnGroupState[] Groups; public bool ManualStarted; public bool Emitted; }
        private sealed class SpawnGroupState { public SpawnGroupState(SpawnGroupDefinition definition) { Definition = definition; } public SpawnGroupDefinition Definition; public int EmittedCount; }
    }
}
