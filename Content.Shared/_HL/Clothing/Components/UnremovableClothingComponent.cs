using Content.Shared.Clothing.EntitySystems;
using Robust.Shared.GameStates;

namespace Content.Shared.Clothing.Components;

/// <summary>
///     The component prohibits ANYONE from taking off clothes on them that have this component.
/// </summary>
[NetworkedComponent]
[RegisterComponent]
[Access(typeof(UnremovableClothingSystem))]
public sealed partial class UnremovableClothingComponent : Component
{

}
