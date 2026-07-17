# Encounter Sandbox

This headless sample creates a weighted spawn table and one timed wave, advances the deterministic encounter clock, then drains the emitted spawn requests.

Call `EncounterSandboxSample.Run()` from an EditMode test or application bootstrap. World spawning, navigation, combat, and reward payout remain caller-owned concerns.
