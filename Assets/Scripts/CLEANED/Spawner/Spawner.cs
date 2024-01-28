using System;
using System.Collections.Generic;
using BounceFactory;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : UpgradableObject
    {
        [SerializeField] protected List<T> Templates = new();
        [SerializeField] protected Seller<T> _seller;

        public abstract event Action Bought;

        protected Container<T> Container;

        protected virtual void Start() => Container = FindObjectOfType<Container<T>>();

        public virtual void Spawn() { }

        protected virtual T GetTemplateToSpawn() => Templates[UnityEngine.Random.Range(0, Templates.Count)];
    }