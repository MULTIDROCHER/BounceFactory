using System;
using BounceFactory.BaseObjects;
using BounceFactory.Logic.Spawning;
using BounceFactory.System.Game;
using UnityEngine;

namespace BounceFactory.Logic.Selling
{
    public abstract class PriceChanger<T> : MonoBehaviour
    where T : UpgradableObject
    {
        protected readonly int FreePurchaseCount = 2;

        [SerializeField] protected Spawner<T> Spawner;
        [SerializeField] protected LevelSwitcher LevelSwitcher;

        protected int PurchasesCount;

        public event Action<int> PriceChanged;

        public float PriceIncrease { get; protected set; }

        public int Price { get; protected set; }

        private void OnEnable()
        {
            LevelSwitcher.LevelChanged += OnLevelChanged;
            Spawner.Bought += OnBought;
        }

        private void OnDisable()
        {
            LevelSwitcher.LevelChanged -= OnLevelChanged;
            Spawner.Bought -= OnBought;
        }

        protected virtual void OnBought() => IncreasePrices();

        protected virtual void OnLevelChanged() => Reset();

        protected void ReducePrices()
        {
            if (Price != 0)
                Price = Convert.ToInt32(Price / PriceIncrease);

            PriceChanged?.Invoke(Price);
        }

        protected abstract void SetPrices();

        private void IncreasePrices()
        {
            PurchasesCount++;

            if (PurchasesCount == FreePurchaseCount)
                SetPrices();

            Price = Convert.ToInt32(Price * PriceIncrease);
            PriceChanged?.Invoke(Price);
        }

        private void Reset()
        {
            PurchasesCount = 0;
            Price = 0;
            PriceChanged?.Invoke(Price);
        }
    }
}