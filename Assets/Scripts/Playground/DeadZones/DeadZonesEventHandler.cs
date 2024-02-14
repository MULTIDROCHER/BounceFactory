using System;
using BounceFactory.BaseObjects;
using BounceFactory.Playground.Storage.Holder;
using BounceFactory.System.Game;
using UnityEngine;

namespace BounceFactory.Playground.DeadZones
{
    public class DeadZonesEventHandler : MonoBehaviour
    {
        [SerializeField] private LevelSwitcher _levelSwitcher;

        private Holder<Ball> _ballHolder;

        public event Action BallDestroyed;

        public event Action BallsOver;

        private void Start() => _levelSwitcher.LevelChanged += OnLevelChanged;

        private void OnDestroy() => _levelSwitcher.LevelChanged -= OnLevelChanged;

        public void OnBallDestroyed()
        {
            if (_ballHolder == null)
                OnLevelChanged();

            BallDestroyed?.Invoke();

            if (IsBallsOver())
                BallsOver?.Invoke();
        }

        private bool IsBallsOver() => _ballHolder.transform.childCount <= 1;

        private void OnLevelChanged() => _ballHolder = _levelSwitcher.CurrentLevel.BallData.BallHolder;
    }
}