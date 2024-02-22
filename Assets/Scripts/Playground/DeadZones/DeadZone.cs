using System;
using BounceFactory.BaseObjects;
using BounceFactory.Playground.Storage.Holder;
using BounceFactory.System.Game;
using UnityEngine;

namespace BounceFactory.Playground.DeadZones
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] private LevelSwitcher _levelSwitcher;

        private Holder<Ball> _ballHolder;

        public event Action BallDestroyed;

        public event Action BallsOver;

        private void Start() => _levelSwitcher.LevelChanged += OnLevelChanged;

        private void OnDestroy() => _levelSwitcher.LevelChanged -= OnLevelChanged;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Ball ball))
            {
                if (_ballHolder == null)
                    OnLevelChanged();

                if (IsNotClone(ball))
                    BallDestroyed?.Invoke();

                if (IsBallsOver())
                    BallsOver?.Invoke();

                Destroy(ball.gameObject);
            }
        }

        private bool IsNotClone(Ball ball) => ball.transform.parent != null;

        private bool IsBallsOver() => _ballHolder.transform.childCount <= 1;

        private void OnLevelChanged() => _ballHolder = _levelSwitcher.CurrentLevel.BallData.BallHolder;
    }
}