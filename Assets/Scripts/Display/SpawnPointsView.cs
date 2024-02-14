using System.Collections.Generic;
using BounceFactory.Logic.Spawning;
using BounceFactory.System.Game;
using UnityEngine;

namespace BounceFactory.Display
{
    public class SpawnPointsView : MonoBehaviour
    {
        [SerializeField] private LevelSwitcher _levelSwitcher;

        private List<SpawnPoint> _points = new ();

        private void Start() => _levelSwitcher.LevelChanged += OnLevelChanged;

        private void OnDestroy() => _levelSwitcher.LevelChanged -= OnLevelChanged;

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

        private void OnLevelChanged()
        {
            _points.Clear();
            _points = _levelSwitcher.CurrentLevel.ItemData.SpawnPoints;
        }
    }
}