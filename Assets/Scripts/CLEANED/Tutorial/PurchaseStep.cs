using UnityEngine;

public abstract class PurchaseStep<T> : TutorialStep where T : UpgradableObject
{
    protected PriceChanger<T> PriceChanger;
    protected PriceView<T> PriceView;
    protected ITutorialEvent Performer;

    public override void Enter()
    {
        PriceView = Object.FindFirstObjectByType<PriceView<T>>();
        PriceChanger = PriceView.PriceChanger;
        Performer = PriceChanger as ITutorialEvent;
        Performer.Performed += OnPerformed;
    }

    public override void Exit() => Performer.Performed -= OnPerformed;
}