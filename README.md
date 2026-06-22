# Deucarian Encounters

`com.deucarian.encounters` is a pure C# Unity package for deterministic encounter scheduling.

It owns stage, encounter, wave, spawn group, weighted table, objective, reward-reference, scaling descriptor, lifecycle, and snapshot primitives. It emits spawn requests into caller-owned buffers and does not instantiate, move, damage, reward, save, render, or query world objects.

Runtime dependency:

- `com.deucarian.gameplay-foundation`

Deliberately out of scope for runtime:

- GameObjects, MonoBehaviours, scenes, UI, networking, persistence, Entities, service locators, global mutable state
- health, damage, weapons, progression redemption, currencies, saving, pathfinding, coordinates, lane logic, physics, and pooling

Remote publication and Package Registry registration are deferred release steps.
