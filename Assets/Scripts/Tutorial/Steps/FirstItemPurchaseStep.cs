using System.Collections.Generic;
using BounceFactory.BaseObjects;
using BounceFactory.Display.Price;

namespace BounceFactory.Tutorial.Steps
{
    public class FirstItemPurchaseStep : PurchaseStep<Item>
    {
        public FirstItemPurchaseStep(TutorialGuide guide, PriceView<Item> priceView)
        : base(guide, priceView)
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
            { "ru", "теперь создай предмет,\nчтобы шарам было с чем сталкиваться" },
            { "en", "Now create an object so the balls\nhave something to collide with" },
            { "tr", "Şimdi bir nesne oluşturun, böylece\ntopların uğraşacağı bir şey olsun" },
        };
        }
    }
}