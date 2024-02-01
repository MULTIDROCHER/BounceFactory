using System;
using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory
{
    public abstract class Spawner<T> : MonoBehaviour where T : UpgradableObject
    {
        [SerializeField] protected List<T> Templates = new();
        [SerializeField] protected PriceChanger<T> PriceChanger;
        [SerializeField] protected Holder<T> Holder;

        public abstract event Action Bought;

        protected virtual void OnEnable() =>
            ActiveComponentsProvider.LevelChanged += OnLevelChanged;

        protected virtual void OnВшыable() =>
            ActiveComponentsProvider.LevelChanged -= OnLevelChanged;

        protected abstract void OnLevelChanged();

        public virtual void Spawn() { }

        protected virtual T GetTemplateToSpawn() => Templates[UnityEngine.Random.Range(0, Templates.Count)];
    }
}