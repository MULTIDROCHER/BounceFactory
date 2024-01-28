using UnityEngine;

public abstract class PurchaseStep<T> : TutorialStep where T : UpgradableObject
{
    protected Seller<T> Seller;
    protected PriceView<T> PriceView;
    protected ITutorialEvent Performer;

    public override void Enter()
    {
        PriceView = Object.FindFirstObjectByType<PriceView<T>>();
        Seller = PriceView.Seller;
        Performer = Seller as ITutorialEvent;
        Performer.Performed += OnPerformed;
    }

    public override void Exit() => Performer.Performed -= OnPerformed;
}