namespace Deucarian.Encounters.Samples.SimpleUsage
{
    [EncounterKeySet]
    public static class Encounters
    {
        public static EncounterKey FirstWave => new Definition();
        private sealed class Definition : EncounterKey
        {
            public Definition() : base("sample.first-wave") { }
        }
    }
}
