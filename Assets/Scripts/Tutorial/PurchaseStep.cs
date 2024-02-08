using BounceFactory.BaseObjects;
using BounceFactory.Display.Price;
using BounceFactory.Logic.Selling;

namespace BounceFactory.Tutorial
{
    public abstract class PurchaseStep<T> : TutorialStep 
    where T : UpgradableObject
    {
        protected PriceChanger<T> PriceChanger;
        protected PriceView<T> PriceView;
        protected ITutorialEvent Performer;

        public PurchaseStep(TutorialGuide guide) : base(guide)
        {
        }

        protected PurchaseStep(TutorialGuide guide, PriceView<T> priceView) : base(guide)
        {
            PriceView = priceView;
        }

        public override void Enter()
        {
            base.Enter();
            PriceChanger = PriceView.PriceChanger;
            Performer = PriceChanger as ITutorialEvent;

            if (Performer != null)
                Performer.Performed += OnPerformed;
        }

        public override void Exit()
        {
            if (Performer != null)
                Performer.Performed -= OnPerformed;
        }
    }
}