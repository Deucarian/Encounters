using System;

namespace Deucarian.Encounters
{
    /// <summary>Marks an authoritative set of named EncounterKey fields or properties for the Inspector.</summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class EncounterKeySetAttribute : Attribute { }
}
