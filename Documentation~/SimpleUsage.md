# Simple usage

Copy the reference example into your project, add SimpleUsageExample and assign its scoped host references. Its serialized definition fields use the same typed keys as code.

Construct EncounterProfile from the existing EncounterDefinition catalog and call EncounterHost.Configure once. The simulation owner calls profile.AdvanceTicks, drains spawn requests and acknowledges spawns/deaths through profile.Active, exactly as with EncounterRuntime. A second Start while running/paused returns AlreadyRunning. This host does not introduce a second simulation clock or spawn loop.

Definitions are authored once in SampleDefinitions.cs where applicable; the caller never invents an ID. Replace the sample set with your project's central definitions. A selected key proves its identity and payload type; startup still needs to bind that definition in the correct scope. Missing configuration reports how to fix it. Dynamic targets and choices are issued by their owner instead of selected from a definition dropdown.
```csharp
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
```
