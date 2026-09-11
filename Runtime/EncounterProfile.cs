using System;
using System.Collections.Generic;

namespace Deucarian.Encounters
{
    public enum EncounterStartStatus { Started, AlreadyRunning }

    /// <summary>Owns one active encounter runtime and its immutable definition catalog.</summary>
    public sealed class EncounterProfile
    {
        private readonly Dictionary<EncounterId, EncounterDefinition> definitions = new Dictionary<EncounterId, EncounterDefinition>();
        private EncounterRuntime active;
        public EncounterProfile(IEnumerable<EncounterDefinition> definitions)
        {
            if (definitions == null) throw new ArgumentNullException(nameof(definitions));
            foreach (var definition in definitions)
            {
                if (definition == null) throw new ArgumentException("An encounter definition is null. Supply a valid definition for each catalog entry.", nameof(definitions));
                if (this.definitions.ContainsKey(definition.Id)) throw new ArgumentException("Encounter '" + definition.Id + "' is registered twice. Keep one definition per ID.", nameof(definitions));
                this.definitions.Add(definition.Id, definition);
            }
        }
        public EncounterStartStatus Start(IEncounterKey encounter)
        {
            if (encounter == null) throw new ArgumentNullException(nameof(encounter), "Select an EncounterKey or pass a named encounter definition.");
            var id = new EncounterId(encounter.Id);
            if (!definitions.TryGetValue(id, out var definition)) throw new InvalidOperationException("Encounter '" + encounter.Id + "' is absent from this profile. Add its definition to this profile's catalog.");
            if (active != null && (active.State == EncounterLifecycleState.Running || active.State == EncounterLifecycleState.Paused))
                return EncounterStartStatus.AlreadyRunning;
            active = new EncounterRuntime(definition);
            active.Start();
            return EncounterStartStatus.Started;
        }
        public void Stop() => active?.Stop();
        public void AdvanceTicks(long ticks) => Active.AdvanceTicks(ticks);
        public EncounterDrainResult DrainSpawnRequests(SpawnRequest[] buffer) => Active.DrainSpawnRequests(buffer);
        public EncounterSnapshot Snapshot => active?.CreateSnapshot();
        /// <summary>Advanced commands for metrics and objectives use the same authoritative runtime.</summary>
        public EncounterRuntime Active => active ?? throw new InvalidOperationException("No encounter has started. Call Start with an EncounterKey before advancing or draining spawn requests.");
    }
}
