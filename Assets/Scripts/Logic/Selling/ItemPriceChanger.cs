using System;
using BounceFactory.BaseObjects;
using BounceFactory.System.Level;
using BounceFactory.Tutorial;

namespace BounceFactory.Logic.Selling
{
    public class ItemPriceChanger : PriceChanger<Item>, ITutorialEvent
    {
        private readonly int _startPrice = 25;
        private readonly float _priceIncrease = 1.7f;

        public event Action Performed;

        protected override void OnEnable()
        {
            ItemComponentsProvider.LevelChanged += OnLevelChanged;
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            ItemComponentsProvider.LevelChanged -= OnLevelChanged;
            base.OnDisable();
        }

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
}