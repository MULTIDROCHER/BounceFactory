using System.Collections.Generic;

namespace BounceFactory
{
    public class SecondItemPurchaseStep : PurchaseStep<Item>
    {
        protected override Dictionary<string, string> CommonMessages()
        {
            return new Dictionary<string, string>() {
{ "ru", "теперь добавь еще один предмет" },
{ "en", "now add one more item" },
{ "tr", "şimdi bir öğe daha ekleyin" },
    };
        }

        public override void Enter()
        {
            base.Enter();

            OnUnneedMask(CommonMessages()[Language]);
        }
    }
}