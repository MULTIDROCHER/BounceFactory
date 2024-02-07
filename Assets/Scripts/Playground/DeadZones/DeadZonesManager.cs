using System;
using BounceFactory.BaseObjects;
using BounceFactory.Playground.Storage.Holder;
using BounceFactory.System.Level;
using UnityEngine;

namespace BounceFactory.Playground.DeadZones
{
    public class DeadZonesManager : MonoBehaviour
    {
        private Holder<Ball> _ballHolder;

        public event Action BallDestroyed;
        
        public event Action BallsOver;

        private void Start() => ActiveComponentsProvider.LevelChanged += OnLevelChanged;

        private void OnDestroy() => ActiveComponentsProvider.LevelChanged -= OnLevelChanged;

        public void OnBallDestroyed()
        {
            if (_ballHolder == null)
                OnLevelChanged();

            BallDestroyed?.Invoke();

            if (IsBallsOver())
                BallsOver?.Invoke();
        }

        private bool IsBallsOver() => _ballHolder.transform.childCount <= 1;

        private void OnLevelChanged() => _ballHolder = ActiveComponentsProvider.BallHolder;
    }
}