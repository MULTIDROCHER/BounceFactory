using System.Collections.Generic;

public class BallsPurchaseStep : PurchaseStep<Ball>
{
    protected override Dictionary<string, string> CommonMessages()
    {
        return new Dictionary<string, string>() {
{ "ru", "отлично, теперь купи пару шаров" },
{ "en", "Great, now buy a couple balls" },
{ "tr", "Harika, şimdi birkaç balon al" },
    };
    }

    public override void Enter()
    {
        base.Enter();

        OnNeedMask(CommonMessages()[Language], PriceView.transform.parent.parent);
    }
}