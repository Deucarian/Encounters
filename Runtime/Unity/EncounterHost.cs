using Deucarian.Diagnostics;
using System;
using UnityEngine;

namespace Deucarian.Encounters.Unity
{
    /// <summary>One encounter scope; the existing integration supplies ticks and consumes spawn requests.</summary>
    [DisallowMultipleComponent]
    public sealed class EncounterHost : MonoBehaviour, IDiagnosticProvider
    {
        private EncounterProfile profile;
        private bool destroyed;
        public void Configure(EncounterProfile value)
        {
            if (destroyed) throw new ObjectDisposedException(nameof(EncounterHost));
            if (profile != null) throw new InvalidOperationException("EncounterHost '" + name + "' is already configured.");
            profile = value ?? throw new ArgumentNullException(nameof(value));
        }
        public EncounterStartStatus Start(EncounterKey encounter) => Profile.Start(encounter);
        public void Stop() => Profile.Stop();
        public EncounterSnapshot Snapshot => Profile.Snapshot;
        private EncounterProfile Profile => profile ?? throw new InvalidOperationException("EncounterHost '" + name + "' is not configured. Supply its EncounterProfile and connect your existing tick/spawn-request integration during startup.");
        private void OnDestroy() { diagnosticRegistration?.Dispose(); diagnosticRegistration = null;  destroyed = true; profile = null; }
        private DiagnosticProviderRegistration diagnosticRegistration;
        private void Awake() => diagnosticRegistration = DiagnosticProviderRegistry.Register(this);
        string IDiagnosticProvider.ProviderId => "encounters.host." + GetInstanceID();
        string IDiagnosticProvider.DisplayName => "EncounterHost";
        void IDiagnosticProvider.Collect(DiagnosticReportBuilder builder)
        {
            bool configured = profile != null;
            builder.AddSection(((IDiagnosticProvider)this).ProviderId, "EncounterHost")
                .AddItem("configured", "Configured", configured ? "Ready" : "Call Configure during startup",
                    configured ? DiagnosticSeverity.Info : DiagnosticSeverity.Warning)
                .AddItem("enabled", "Enabled", isActiveAndEnabled.ToString());
        }
    }
}
