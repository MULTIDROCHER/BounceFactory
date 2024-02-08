using System;
using BounceFactory.BaseObjects;
using BounceFactory.Playground.DeadZones;
using BounceFactory.System.Level;
using BounceFactory.Tutorial;
using UnityEngine;

namespace BounceFactory.Logic.Selling
{
    public class BallPriceChanger : PriceChanger<Ball>, ITutorialEvent
    {
        private readonly int _startPrice = 50;
        private readonly float _priceIncrease = 1.5f;

        [SerializeField] private DeadZonesProcessor _zonesProcessor;

        public event Action Performed;
        
        public event Action BallDestroyed;

        private void Start()
        {
            _zonesProcessor.BallDestroyed += OnBallDestroyed;
            _zonesProcessor.BallsOver += OnBallsOver;
        }

        protected override void OnEnable()
        {
            BallComponentsProvider.LevelChanged += OnLevelChanged;
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            BallComponentsProvider.LevelChanged -= OnLevelChanged;
            base.OnDisable();
        }

        private void OnDestroy()
        {
            _zonesProcessor.BallDestroyed -= OnBallDestroyed;
            _zonesProcessor.BallsOver -= OnBallsOver;
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