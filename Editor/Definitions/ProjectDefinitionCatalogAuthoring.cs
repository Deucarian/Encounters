using System;
using System.Linq;
using Deucarian.Editor.Definitions;
using Deucarian.Encounters.Unity;
using UnityEditor;

namespace Deucarian.Encounters.Editor.Definitions
{
    internal static class ProjectDefinitionCatalogAuthoring
    {
        internal static void Refresh(bool validateOnly = false)
        {
            var definitions = AssetDatabase.FindAssets("t:EncounterDefinitionAsset", new[] { "Assets" })
                .Select(x => AssetDatabase.LoadAssetAtPath<EncounterDefinitionAsset>(AssetDatabase.GUIDToAssetPath(x)))
                .Where(x => x != null).OrderBy(x => x.Id, StringComparer.Ordinal).ToArray();
            if (definitions.GroupBy(x => x.Id).Any(x => x.Count() > 1)) throw new InvalidOperationException("Encounter definition IDs must be unique.");
            DeucarianDefinitionCatalog.Update<EncounterDefinitionCatalog>("Assets/DeucarianDefinitions/Resources/Deucarian/Definitions/EncounterDefinitionCatalog.asset", "definitions", definitions, validateOnly);
        }
    }
}
