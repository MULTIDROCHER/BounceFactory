using System;
using System.Collections.Generic;
using BounceFactory.BaseObjects;
using BounceFactory.Logic.Selling;
using BounceFactory.Playground.Storage.Holder;
using BounceFactory.Score;
using BounceFactory.System.Game;
using UnityEngine;

namespace BounceFactory.Logic.Spawning
{
    public abstract class Spawner<T> : MonoBehaviour
    where T : UpgradableObject
    {
        [SerializeField] protected List<T> Templates = new ();
        [SerializeField] protected PriceChanger<T> PriceChanger;
        [SerializeField] protected Holder<T> Holder;
        [SerializeField] protected ScoreOperations ScoreOperations;
        [SerializeField] protected LevelSwitcher LevelSwitcher;

        public abstract event Action Bought;

        private void OnEnable() => LevelSwitcher.LevelChanged += OnLevelChanged;

        private void OnDisable() => LevelSwitcher.LevelChanged -= OnLevelChanged;

        public virtual void Spawn()
        {
        }

        protected abstract void OnLevelChanged();

        protected virtual T GetTemplateToSpawn() => Templates[UnityEngine.Random.Range(0, Templates.Count)];
    }
}