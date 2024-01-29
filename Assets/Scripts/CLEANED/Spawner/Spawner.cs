using System;
using System.Collections.Generic;
using BounceFactory;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : UpgradableObject
    {
        [SerializeField] protected List<T> Templates = new();
        [SerializeField] protected PriceChanger<T> PriceChanger;

        public abstract event Action Bought;

        protected Holder<T> Holder;

        protected virtual void Start() => Holder = FindObjectOfType<Holder<T>>();

        public virtual void Spawn() { }

        protected virtual T GetTemplateToSpawn() => Templates[UnityEngine.Random.Range(0, Templates.Count)];
    }