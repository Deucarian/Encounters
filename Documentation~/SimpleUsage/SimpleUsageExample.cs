using UnityEngine;
using Deucarian.Encounters.Unity;
namespace Deucarian.Encounters.Samples.SimpleUsage
{
    public sealed class SimpleUsageExample : MonoBehaviour
    {
        [SerializeField] private EncounterHost encounters;
        [SerializeField] private EncounterKey encounter = Encounters.FirstWave;
        public EncounterStartStatus Begin() => encounters.Start(encounter);
        public void End() => encounters.Stop();
    }
}
