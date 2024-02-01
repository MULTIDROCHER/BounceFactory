using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory
{
    public class SpawnPointsView : MonoBehaviour
    {
        private List<SpawnPoint> _points = new();
        private List<Item> _items = new();

        private ItemSpawner _spawner;

        private void Start()
        {
            _spawner = ActiveComponentsProvider.ItemSpawner as ItemSpawner;

            if (_spawner != null)
                _spawner.ItemSpawned += OnItemSpawned;

            ActiveComponentsProvider.LevelChanged += OnLevelChanged;
        }

        private void OnDestroy()
        {
            if (_spawner != null)
                _spawner.ItemSpawned -= OnItemSpawned;

            ActiveComponentsProvider.LevelChanged += OnLevelChanged;
        }

        public void ShowPoints()
        {
            foreach (var point in _points)
                point.ShowPoint();
        }

        public void HidePoints()
        {
            foreach (var point in _points)
                point.HidePoint();
        }

        public void OnLevelChanged()
        {
            _points.Clear();
            _points = ActiveComponentsProvider.ActivePoints;
        }

        private void OnItemSpawned(Item item) => _items.Add(item);
    }
}