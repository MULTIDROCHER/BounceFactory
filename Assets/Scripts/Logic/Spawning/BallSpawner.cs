using System;
using BounceFactory.BaseObjects;
using BounceFactory.Playground.Storage;
using BounceFactory.ScoreSystem;
using UnityEngine;

namespace BounceFactory.Logic.Spawning
{
    public class BallSpawner : Spawner<Ball>
    {
        [SerializeField] private EffectContainer _effectContainer;

        public override event Action Bought;

        public override void Spawn()
        {
            if (Holder == null)
                OnLevelChanged();

            SpawnAndSetBall();
            ScoreOperations.Buy(PriceChanger.Price);
            Bought?.Invoke();
        }

        protected override void OnLevelChanged()
        {
            Holder = LevelSwitcher.CurrentLevel.BallData.BallHolder;

            if (Holder.transform.childCount == 0)
                SpawnAndSetBall();
        }

        private void SpawnAndSetBall()
        {
            var ball = Instantiate(GetTemplateToSpawn(), Holder.transform.position, Quaternion.identity, Holder.transform);
            ball.SetEffectContainer(_effectContainer);
            ball.SetScoreOperator(ScoreOperations);
        }
    }
}