using BounceFactory.BaseObjects;
using BounceFactory.Logic.Spawning;
using BounceFactory.System.Level;
using System;
using UnityEngine;

namespace BounceFactory.Logic.Selling
{
    public abstract class PriceChanger<T> : MonoBehaviour where T : UpgradableObject
    {
        [SerializeField] protected Spawner<T> _spawner;

        protected readonly int FreePurchaseCount = 2;
        protected int PurchasesCount;

        public float PriceIncrease { get; protected set; }
        public int Price { get; protected set; }

        public event Action<int> PriceChanged;

        protected virtual void OnEnable()
        {
            ActiveComponentsProvider.LevelChanged += OnLevelChanged;
            _spawner.Bought += OnBought;
        }

        protected virtual void OnDisable()
        {
            ActiveComponentsProvider.LevelChanged -= OnLevelChanged;
            _spawner.Bought -= OnBought;
        }

        private void Reset()
        {
            PurchasesCount = 0;
            Price = 0;
            PriceChanged?.Invoke(Price);
        }

        protected virtual void OnBought() => IncreasePrices();

        protected virtual void OnLevelChanged() => Reset();

        private void IncreasePrices()
        {
            PurchasesCount++;

            if (PurchasesCount == FreePurchaseCount)
                SetPrices();

            Price = Convert.ToInt32(Price * PriceIncrease);
            PriceChanged?.Invoke(Price);
        }

        protected void ReducePrices()
        {
            if (Price != 0)
                Price = Convert.ToInt32(Price / PriceIncrease);

            PriceChanged?.Invoke(Price);
        }

        protected abstract void SetPrices();
    }
}