using System;
using UnityEngine;

namespace Deucarian.Encounters.Unity.Samples.DefinitionWorkflow
{
    /// <summary>Small caller example. The configured scene hosts own services and resource lifetimes.</summary>
    public sealed class EncountersWorkflow : MonoBehaviour
    {
        [SerializeField] private EncounterHost host;
        [SerializeField] private EncounterKey encounter;
        [SerializeField] private EncounterSpawnDriver driver;
        private string status = "Ready. Choose an action below.";
        public string Status => status;
        public void BeginEncounter() { status = "Begin: " + host.Begin(encounter); }
        public void Step() { driver.Step(); status = "Spawned: " + driver.SpawnedCount + ". Failures: " + driver.FailedCount; }
        public void Stop() { host.Stop(); driver.ClearSpawned(); status = "Encounter stopped and its sample instances returned to the pool."; }
        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(24, 24, Math.Min(540, Screen.width - 48), Screen.height - 48), GUI.skin.box);
            GUILayout.Label("Encounters — definition workflow");
            GUILayout.Label("A wave selects existing spawnable and channel definitions. This scene steps the optional spawn driver manually so you can see when each scheduled request is emitted.");
            GUILayout.Space(12);
            if (GUILayout.Button("Begin encounter", GUILayout.Height(32))) { try { BeginEncounter(); } catch (Exception error) { status = error.Message; } }
            if (GUILayout.Button("Advance one tick", GUILayout.Height(32))) { try { Step(); } catch (Exception error) { status = error.Message; } }
            if (GUILayout.Button("Stop and clear", GUILayout.Height(32))) { try { Stop(); } catch (Exception error) { status = error.Message; } }
            GUILayout.Space(12);
            GUILayout.Label(status);
            GUILayout.EndArea();
        }
    }
}
