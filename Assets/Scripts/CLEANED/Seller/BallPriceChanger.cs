using System;
using System.Collections.Generic;

namespace BounceFactory
{
    public class BallPriceChanger : PriceChanger<Ball>, ITutorialEvent
    {
        private readonly int _startPrice = 50;
        private readonly float _priceIncrease = 1.5f;

        private List<DeadZone> _ballDestroyer => ActiveComponentsProvider.DeadZones;

        public event Action Performed;
        public event Action BallDestroyed;

        private void Start()
        {
            foreach (var destroyer in _ballDestroyer)
            {
                destroyer.BallDestroyed += OnBallDestroyed;
                destroyer.BallsOver += OnBallsOver;
            }
        }

        private void OnDestroy()
        {
            foreach (var destroyer in _ballDestroyer)
            {
                destroyer.BallDestroyed -= OnBallDestroyed;
                destroyer.BallsOver -= OnBallsOver;
            }
        }

        protected override void SetPrices()
        {
            Performed?.Invoke();
            Price = _startPrice;
            PriceIncrease = _priceIncrease;
        }

        private void OnBallDestroyed()
        {
            BallDestroyed?.Invoke();
            ReducePrices();
        }

        private void OnBallsOver()
        {
            Price = 0;
            PurchasesCount = 0;
            OnBought();
        }
    }
}