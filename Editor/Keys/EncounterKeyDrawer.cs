using System;
using Deucarian.Editor;
using UnityEditor;

namespace Deucarian.Encounters.Editor
{
    [CustomPropertyDrawer(typeof(EncounterKey), true)]
    public sealed class EncounterKeyDrawer : DeucarianKeyDrawer
    {
        public override Type KeyType => typeof(EncounterKey);
        public override Type DefinitionSetAttribute => typeof(EncounterKeySetAttribute);
        public override string SetupHint => "Select an existing EncounterKey; declare reusable keys once in a [EncounterKeySet] class.";
    }
}
