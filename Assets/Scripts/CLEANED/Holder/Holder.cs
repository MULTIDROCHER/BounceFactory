using System;
using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory
{
    public abstract class Holder<T> : MonoBehaviour where T : UpgradableObject
    {
        [SerializeField] private Spawner<T> _spawner;

        protected List<T> Children = new();

        public event Action ChildAdded;

        public List<T> Contents => Children;

        protected virtual void Start()
        {
            _spawner.Bought += () => UpdateContent();
        }

        private void OnDestroy()
        {
            _spawner.Bought -= () => UpdateContent();
        }

        public virtual void Reset()
        {
            for (int i = Children.Count - 1; i >= 0; i--)
                Destroy(Children[i].gameObject);

            Children.Clear();
        }

        public void UpdateContent()
        {
            /* if (Children.Count != transform.childCount || Children.Find(child => child == null) != null)
            { */
            Children.Clear();

            var childrenComponents = transform.GetComponentsInChildren<T>();

            foreach (var child in childrenComponents)
                if (child != null)
                    Children.Add(child);

            ChildAdded?.Invoke();
            Debug.Log($"Added new children now there are ==== {Children.Count}");
            Debug.Log($"in transform ==== {transform.childCount}");
            /* } */
        }
    }
}