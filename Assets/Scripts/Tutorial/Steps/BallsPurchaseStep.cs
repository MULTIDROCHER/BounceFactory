using System.Collections.Generic;
using BounceFactory.BaseObjects;
using BounceFactory.Display.Price;

namespace BounceFactory.Tutorial.Steps
{
    public class BallsPurchaseStep : PurchaseStep<Ball>
    {
        public BallsPurchaseStep(TutorialGuide guide, PriceView<Ball> priceView) : base(guide, priceView)
        {
        }

        public override void Enter()
        {
            base.Enter();
            OnNeedMask(CommonMessages()[Language], PriceView.transform.parent.parent);
        }

        protected override Dictionary<string, string> CommonMessages()
        {
            return new Dictionary<string, string>() 
        {
            { "ru", "отлично, теперь купи пару шаров" },
            { "en", "Great, now buy a couple balls" },
            { "tr", "Harika, şimdi birkaç balon al" },
        };
        }
    }
}