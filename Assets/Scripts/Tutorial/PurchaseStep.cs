using BounceFactory.BaseObjects;
using BounceFactory.Display.Price;
using BounceFactory.Logic.Selling;
using UnityEngine;

namespace BounceFactory.Tutorial
{
    public abstract class PurchaseStep<T> : TutorialStep 
    where T : UpgradableObject
    {
        protected PriceChanger<T> PriceChanger;
        protected PriceView<T> PriceView;
        protected ITutorialEvent Performer;

        public override void Enter()
        {
            PriceView = Object.FindFirstObjectByType<PriceView<T>>();
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