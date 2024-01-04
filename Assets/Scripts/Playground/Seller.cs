using System;
using UnityEngine;

public abstract class Seller : MonoBehaviour
{
    protected readonly int FreePurchaseCount = 2;
    protected int PurchasesCount;

    public float PriceChange { get; protected set; }
    public int Price { get; protected set; }

    public event Action<int> PriceChanged;

    protected void OnBought() => IncreasePrices();

    private void IncreasePrices()
    {
        PurchasesCount++;

        if (PurchasesCount == FreePurchaseCount)
            SetPrices();

        Price = Convert.ToInt32(Price * PriceChange);
        PriceChanged?.Invoke(Price);
    }

    protected void ReducePrices()
    {
        if (Price != 0)
            Price = Convert.ToInt32(Price / PriceChange);
            
        PriceChanged?.Invoke(Price);
    }

    protected abstract void SetPrices();

    public void Reset(){
        PurchasesCount = 0;
        Price = 0;
        PriceChanged?.Invoke(Price);
    }
}