using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory
{
    public abstract class Container<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected List<T> _contents = new();
        private Spawner<UpgradableObject> _spawner;
        private int _childCount;

        private void Awake() => _spawner = FindFirstObjectByType<Spawner<UpgradableObject>>();

        private void OnEnable() => _spawner.Bought += () => CheckForNewChildren();

        private void OnDisable()
        {
            _spawner.Bought -= () => CheckForNewChildren();
            Reset();
        }

        public virtual void Reset()
        {
            foreach (var item in _contents)
                if (item != null)
                    Destroy(item.gameObject);
        }

        private void CheckForNewChildren()
        {
            if (transform.childCount != _childCount)
            {
                _childCount = transform.childCount;
                _contents.Clear();
                _contents.AddRange(transform.GetComponentsInChildren<T>());
            }
        }
    }
}