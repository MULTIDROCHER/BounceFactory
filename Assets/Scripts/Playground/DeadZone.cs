using System;
using BounceFactory;
using UnityEngine;

namespace BounceFactory
{
    public class DeadZone : MonoBehaviour
    {
        private Holder<Ball> _holder;

        public event Action BallDestroyed;
        public event Action BallsOver;

        private void OnEnable() => ActiveComponentsProvider.LevelChanged += OnLevelChanged;

        private void OnDisable() => ActiveComponentsProvider.LevelChanged -= OnLevelChanged;

        public void OnLevelChanged() => _holder = ActiveComponentsProvider.BallHolder;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Ball ball))
            {
                if (IsNotClone(ball))
                    BallDestroyed?.Invoke();

                Destroy(ball.gameObject);

                if (_holder.transform.childCount <= 1)
                    BallsOver?.Invoke();
            }
        }

        private bool IsNotClone(Ball ball)
        {
            if (_holder == null)
                _holder = ActiveComponentsProvider.BallHolder;

            return _holder.Contents.Contains(ball);
        }
    }
}