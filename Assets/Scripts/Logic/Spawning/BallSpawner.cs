using System;
using BounceFactory.BaseObjects;
using BounceFactory.Playground.Storage;
using BounceFactory.Score;
using BounceFactory.System.Level;
using UnityEngine;

namespace BounceFactory.Logic.Spawning
{
    public class BallSpawner : Spawner<Ball>
    {
        [SerializeField] private EffectContainer _effectContainer;

        public override event Action Bought;

        protected virtual void OnEnable() => BallComponentsProvider.LevelChanged += OnLevelChanged;

        protected virtual void OnDisable() => BallComponentsProvider.LevelChanged -= OnLevelChanged;

        public override void Spawn()
        {
            if (Holder == null)
                OnLevelChanged();

            SpawnAndSetBall();
            ScoreCounter.Buy(PriceChanger.Price);
            Bought?.Invoke();
        }

        protected override void OnLevelChanged()
        {
            Holder = BallComponentsProvider.BallHolder;

            if (Holder.transform.childCount == 0)
                SpawnAndSetBall();
        }

        private void SpawnAndSetBall()
        {
            var ball = Instantiate(GetTemplateToSpawn(), Holder.transform.position, Quaternion.identity, Holder.transform);
            ball.GetEffectContainer(_effectContainer);
            ball.GetCounter(ScoreCounter);
        }
    }
}