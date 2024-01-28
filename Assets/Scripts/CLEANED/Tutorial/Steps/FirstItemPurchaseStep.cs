using System.Collections.Generic;

public class FirstItemPurchaseStep : PurchaseStep<Item>
{
    protected override Dictionary<string, string> CommonMessages()
    {
        return new Dictionary<string, string>() {
{ "ru", "теперь создай предмет,\nчтобы шарам было с чем сталкиваться" },
{ "en", "Now create an object so the balls\nhave something to collide with" },
{ "tr", "Şimdi bir nesne oluşturun, böylece\ntopların uğraşacağı bir şey olsun" },
    };
    }

    public override void Enter()
    {
        base.Enter();
        
        OnNeedMask(CommonMessages()[Language], PriceView.transform.parent.parent);
    }
}