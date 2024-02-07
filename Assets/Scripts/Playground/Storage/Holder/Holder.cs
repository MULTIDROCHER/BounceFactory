using System;
using System.Collections.Generic;
using BounceFactory.BaseObjects;
using BounceFactory.System.Level;
using UnityEngine;

namespace BounceFactory.Playground.Storage.Holder
{
    public abstract class Holder<T> : MonoBehaviour 
    where T : UpgradableObject
    {
        private readonly List<T> Children = new ();

        private int childCount;

        public event Action ChildAdded;

        public List<T> Contents => Children;

        private void OnEnable() => ActiveComponentsProvider.LevelExit += Reset;

        private void OnDisable() => ActiveComponentsProvider.LevelExit -= Reset;

        private void FixedUpdate()
        {
            if (transform.childCount != childCount)
            {
                childCount = transform.childCount;
                UpdateContent();
            }
        }

        private void Reset()
        {
            for (int i = Children.Count - 1; i >= 0; i--)
            {
                if (Children[i] != null)
                    Destroy(Children[i].gameObject);
            }

            Children.Clear();
        }

        public void UpdateContent()
        {
            Children.Clear();

            foreach (var child in transform.GetComponentsInChildren<T>())
            {
                if (child != null)
                    Children.Add(child);
            }

            ChildAdded?.Invoke();
        }
    }
}