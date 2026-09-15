using System;
using System.Linq;
using Deucarian.Editor;
using Deucarian.Editor.Definitions;
using Deucarian.Encounters.Unity;
using UnityEditor;
using UnityEngine;

namespace Deucarian.Encounters.Editor.Definitions
{
    public sealed class EncounterDefinitionSchema : DeucarianSerializedDefinitionSchema<EncounterDefinitionAsset, EncounterDefinitionSpec>
    {
        public override string Id => "encounters";
        public override string DisplayName => "Encounters";
        public override void ValidateAssetReady(ScriptableObject asset)
        {
            base.ValidateAssetReady(asset);
            ((EncounterDefinitionAsset)asset).ToRuntimeDefinition();
        }
        public override void RefreshCatalog(bool validateOnly = false) { ProjectDefinitionCatalogAuthoring.Refresh(validateOnly); }
        [MenuItem("Assets/Create/Deucarian/Encounters/Encounter Definition")]
        private static void CreateDefinition() { Selection.activeObject = DeucarianDefinitionSync.Create(new EncounterDefinitionSchema(), "NewEncounter"); }
    }
}
