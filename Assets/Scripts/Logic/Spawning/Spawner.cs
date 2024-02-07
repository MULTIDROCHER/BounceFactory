using System;
using System.Collections.Generic;
using BounceFactory.BaseObjects;
using BounceFactory.Logic.Selling;
using BounceFactory.Playground.Storage.Holder;
using BounceFactory.System.Level;
using UnityEngine;

namespace BounceFactory.Logic.Spawning
{
    public abstract class Spawner<T> : MonoBehaviour 
    where T : UpgradableObject
    {
        [SerializeField] protected List<T> Templates = new ();
        [SerializeField] protected PriceChanger<T> PriceChanger;
        [SerializeField] protected Holder<T> Holder;

        public abstract event Action Bought;

        protected virtual void OnEnable() =>
            ActiveComponentsProvider.LevelChanged += OnLevelChanged;

        protected virtual void OnDisable() =>
            ActiveComponentsProvider.LevelChanged -= OnLevelChanged;

        public virtual void Spawn() 
        { 
        }

        protected abstract void OnLevelChanged();

        protected virtual T GetTemplateToSpawn() => Templates[UnityEngine.Random.Range(0, Templates.Count)];
    }
}