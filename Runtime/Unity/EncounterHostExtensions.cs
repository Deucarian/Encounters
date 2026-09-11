namespace Deucarian.Encounters.Unity
{
    /// <summary>Keeps existing calls working without declaring a Unity Start message with arguments.</summary>
    public static class EncounterHostExtensions
    {
        public static EncounterStartStatus Start(this EncounterHost host, EncounterKey encounter) => host.Begin(encounter);
    }
}
