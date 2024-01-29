using System;
using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory
{
    public abstract class Holder<T> : MonoBehaviour where T : UpgradableObject
    {
        protected List<T> Children = new();

        private Spawner<T> _spawner;

        public event Action ChildAdded;

        public List<T> Contents => Children;

        private void Awake()
        {
            _spawner = FindFirstObjectByType<Spawner<T>>();
            CheckForNewChildren();
        }

        private void OnEnable() => _spawner.Bought += () => CheckForNewChildren();

        private void OnDisable()
        {
            _spawner.Bought -= () => CheckForNewChildren();
            Reset();
        }

        public virtual void Reset() => Children.Clear();

        private void CheckForNewChildren()
        {
            if (transform.childCount != Children.Count)
            {
                Reset();
                Children.AddRange(transform.GetComponentsInChildren<T>());
                ChildAdded?.Invoke();
                Debug.Log("Added new children");
            }
        }
    }
}