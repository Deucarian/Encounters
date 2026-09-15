using System;
using System.Linq;
using UnityEngine;

namespace Deucarian.Encounters.Unity
{
    public sealed class EncounterDefinitionCatalog : ScriptableObject
    {
        public const string ResourcePath = "Deucarian/Definitions/EncounterDefinitionCatalog";
        [SerializeField] private EncounterDefinitionAsset[] definitions = Array.Empty<EncounterDefinitionAsset>();
        public static EncounterDefinitionCatalog LoadProject() => Resources.Load<EncounterDefinitionCatalog>(ResourcePath) ?? throw new InvalidOperationException("Create a Encounter definition in Definitions before loading its project catalog.");
        public EncounterDefinition[] CreateRuntimeDefinitions()
        {
            if (definitions.Any(x => x == null) || definitions.GroupBy(x => x.Id).Any(x => x.Count() > 1)) throw new InvalidOperationException("The Encounter catalog contains missing or duplicate definitions. Synchronize it in Definitions.");
            return definitions.Select(x => x.ToRuntimeDefinition()).ToArray();
        }
    }
}
