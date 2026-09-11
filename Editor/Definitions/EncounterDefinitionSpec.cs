using System;
using System.Linq;
using Deucarian.Editor;
using Deucarian.Editor.Definitions;
using Deucarian.Encounters.Unity;
using UnityEditor;
using UnityEngine;

namespace Deucarian.Encounters.Editor.Definitions
{
    [Serializable]
    public sealed class EncounterDefinitionSpec : DeucarianDefinitionSpec
    {
        [DefinitionField("waves")] public EncounterWaveData[] Waves = Array.Empty<EncounterWaveData>();
        [DefinitionField("durationTicks")] public long DurationTicks = 120L;
        [DefinitionField("seed")] public int Seed = 1;
    }
}
