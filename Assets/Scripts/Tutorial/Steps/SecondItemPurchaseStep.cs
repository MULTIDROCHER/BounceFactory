using System.Collections.Generic;
using BounceFactory.BaseObjects;
using BounceFactory.Display.Price;

namespace BounceFactory.Tutorial.Steps
{
    public class SecondItemPurchaseStep : PurchaseStep<Item>
    {
        public SecondItemPurchaseStep(TutorialGuide guide, PriceView<Item> priceView)
        : base(guide, priceView)
        {
        }

        public override void Enter()
        {
            base.Enter();
            OnUnneedMask(CommonMessages()[Language]);
        }

        protected override Dictionary<string, string> CommonMessages()
        {
            return new Dictionary<string, string>()
        {
            { "ru", "теперь добавь еще один предмет" },
            { "en", "now add one more item" },
            { "tr", "şimdi bir öğe daha ekleyin" },
        };
        }
    }
}