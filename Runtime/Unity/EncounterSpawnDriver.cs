using System;
using System.Collections.Generic;
using Deucarian.WorldSpawning;
using UnityEngine;
using UnityEngine.Events;
namespace Deucarian.Encounters.Unity
{
    /// <summary>Optional scene adapter: consumes scheduled requests through the existing spawn host.</summary>
    public sealed class EncounterSpawnDriver : MonoBehaviour
    {
        [SerializeField] private EncounterHost encounter;
        [SerializeField] private WorldSpawnHost spawning;
        [SerializeField] private bool tickOnFixedUpdate = true;
        [SerializeField] private UnityEvent spawnFailed = new UnityEvent();
        private readonly SpawnRequest[] requests = new SpawnRequest[128];
        private readonly List<SpawnInstanceId> instances = new List<SpawnInstanceId>();
        public int SpawnedCount => instances.Count;
        public int FailedCount { get; private set; }
        public string LastError { get; private set; }
        public void Step()
        {
            if (encounter == null || spawning == null) throw new InvalidOperationException("Assign an EncounterHost and WorldSpawnHost to EncounterSpawnDriver.");
            encounter.AdvanceTicks(1);
            var drained = encounter.DrainSpawnRequests(requests);
            for (int i = 0; i < drained.Written; i++)
            {
                var request = requests[i];
                var result = spawning.Spawn(new Spawnable(request.SpawnableId.Value), new Channel(request.ChannelId.Value));
                if (result.Succeeded) instances.Add(result.InstanceId);
                else { FailedCount++; LastError = result.Message; spawnFailed.Invoke(); }
            }
        }
        public void ClearSpawned()
        {
            if (spawning != null) foreach (var instance in instances) spawning.Despawn(instance);
            instances.Clear();
        }
        private void FixedUpdate() { if (tickOnFixedUpdate) Step(); }
        private void OnDisable() => ClearSpawned();
        private sealed class Spawnable : SpawnableKey { public Spawnable(string id) : base(id) { } }
        private sealed class Channel : SpawnChannelKey { public Channel(string id) : base(id) { } }
    }
}
