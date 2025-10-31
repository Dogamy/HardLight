using Content.Shared.Cloning.Events;
using Content.Shared.Inventory;
using Content.Shared.Medical;
using Content.Shared.Traits.Assorted;

namespace Content.Server.Traits.Assorted;

public sealed class UnrevivableSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<UnrevivableComponent, CloningAttemptEvent>(OnCloningAttempt);
        SubscribeLocalEvent<UnrevivableComponent, DefibrillationAttemptEvent>(OnDefibrillationAttempt); //HL
        SubscribeLocalEvent<UnrevivableComponent, AnalyzeUnrevivableAttemptEvent>(OnAnalyzeUnrevivableAttempt); //HL
    }

    private void OnCloningAttempt(Entity<UnrevivableComponent> ent, ref CloningAttemptEvent args)
    {
        if (!ent.Comp.Cloneable)
            args.Cancelled = true;
    }

    //START HL
    private void OnDefibrillationAttempt(Entity<UnrevivableComponent> ent, ref DefibrillationAttemptEvent args)
    {
        if (!ent.Comp.Defibrillatable)
            args.Cancelled = true;
    }

    private void OnAnalyzeUnrevivableAttempt(Entity<UnrevivableComponent> ent, ref AnalyzeUnrevivableAttemptEvent args)
    {
        if (!ent.Comp.Analyzable)
            args.Cancelled = true;
    }
    //END HL
}
