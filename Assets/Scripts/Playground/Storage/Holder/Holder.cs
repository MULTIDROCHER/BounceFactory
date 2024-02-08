using System;
using System.Collections.Generic;
using BounceFactory.BaseObjects;
using UnityEngine;

namespace BounceFactory.Playground.Storage.Holder
{
    public abstract class Holder<T> : MonoBehaviour 
    where T : UpgradableObject
    {
        private readonly List<T> _children = new ();

        private int _childCount;

        public event Action ChildAdded;

        public List<T> Contents => _children;

        private void FixedUpdate()
        {
            if (transform.childCount != _childCount)
            {
                _childCount = transform.childCount;
                UpdateContent();
            }
        }

        public void UpdateContent()
        {
            _children.Clear();

            foreach (var child in transform.GetComponentsInChildren<T>())
            {
                if (child != null)
                    _children.Add(child);
            }

            ChildAdded?.Invoke();
        }

        protected void OnLevelExit()
        {
            for (int i = _children.Count - 1; i >= 0; i--)
            {
                if (_children[i] != null)
                    Destroy(_children[i].gameObject);
            }

            _children.Clear();
        }
    }
}