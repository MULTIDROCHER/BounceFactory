using System;
using System.Collections.Generic;
using System.Linq;
using BounceFactory.BaseObjects;
using BounceFactory.Playground.DeadZones;
using BounceFactory.System.Game;
using BounceFactory.Tutorial;

namespace BounceFactory.Logic.Selling
{
    public class BallPriceChanger : PriceChanger<Ball>, ITutorialEvent
    {
        private readonly int _startPrice = 50;
        private readonly float _priceIncrease = 1.5f;

        private List<DeadZone> _deadZones = new();

        public event Action Performed;

        public event Action BallDestroyed;

        private void Awake() => LevelSwitcher.LevelChanged += SetActiveDeadZones;

        private void OnDestroy() => LevelSwitcher.LevelChanged -= SetActiveDeadZones;

        protected override void SetPrices()
        {
            Performed?.Invoke();
            Price = _startPrice;
            PriceIncrease = _priceIncrease;
        }

        private void SetActiveDeadZones()
        {
            if (_deadZones.Count != 0)
            {
                foreach (var zone in _deadZones)
                {
                    zone.BallDestroyed -= OnBallDestroyed;
                    zone.BallsOver -= OnBallsOver;
                }
            }

            _deadZones.Clear();
            _deadZones = LevelSwitcher.CurrentLevel.BallData.DeadZones.ToList();

            foreach (var zone in _deadZones)
            {
                zone.BallDestroyed += OnBallDestroyed;
                zone.BallsOver += OnBallsOver;
            }
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