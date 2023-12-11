using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Seller : MonoBehaviour
{
    private int FreePurchaseCount = 2;
    protected int _purchasesCount;

    public float PriceChange { get; protected set; }
    public int Price { get; protected set; }

    public event Action<int> PriceChanged;

    protected void OnBought() => /*Debug.Log("purchase"); */IncreasePrices() ;

    private void IncreasePrices()
    {
        _purchasesCount++;

        if (_purchasesCount == FreePurchaseCount)
            SetPrices();

        Price = Convert.ToInt32(Price * PriceChange);
        PriceChanged?.Invoke(Price);
    }

    protected void ReducePrices()
    {
        Price = Convert.ToInt32(Price / PriceChange);
        PriceChanged?.Invoke(Price);
    }

    protected abstract void SetPrices();
}