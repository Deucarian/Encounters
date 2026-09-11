using System;
using System.Linq;
using Deucarian.Editor;
using Deucarian.Editor.Definitions;
using Deucarian.Encounters.Unity;
using UnityEditor;
using UnityEngine;

namespace Deucarian.Encounters.Editor.Definitions
{
    public sealed class EncounterKeySource : DeucarianAssetKeySource<EncounterDefinitionAsset>
    {
        public override Type KeyType => typeof(EncounterKey);
        public override Type DefinitionSetAttribute => typeof(EncounterKeySetAttribute);
        public override string GeneratedClassName => "ProjectEncounters";
        protected override DeucarianKeyChoice ReadDefinition(EncounterDefinitionAsset asset) => new DeucarianKeyChoice(asset.Id, asset.DisplayName);
    }
}
