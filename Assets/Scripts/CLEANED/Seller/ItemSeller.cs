using System;

public class ItemPriceChanger : PriceChanger<Item>, ITutorialEvent
{
    private readonly int _startPrice = 25;
    private readonly float _priceIncrease = 1.7f;

    public event Action Performed;

    protected override void OnBought()
    {
        Performed?.Invoke();
        base.OnBought();
    }

    protected override void SetPrices()
    {
        Price = _startPrice;
        PriceIncrease = _priceIncrease;
    }
}