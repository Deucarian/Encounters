using System;
using UnityEngine;

namespace Deucarian.Encounters.Unity
{
    [AddComponentMenu("Deucarian/Encounters/Encounter Trigger")]
    public sealed class EncounterTrigger : MonoBehaviour
    {
        [SerializeField] private EncounterHost host;
        [SerializeField] private EncounterKey encounter;
        public void Begin()
        {
            if (host == null) throw new InvalidOperationException("Assign a configured EncounterHost to EncounterTrigger '" + name + "'.");
            host.Begin(encounter);
        }
        public void Stop()
        {
            if (host == null) throw new InvalidOperationException("Assign an EncounterHost before stopping this encounter.");
            host.Stop();
        }
    }
}
