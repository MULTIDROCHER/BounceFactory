using System.Collections.Generic;
using BounceFactory.BaseObjects;
using BounceFactory.Logic.Spawning;
using BounceFactory.System.Level;
using UnityEngine;

namespace BounceFactory.Display
{
    public class SpawnPointsView : MonoBehaviour
    {
        private List<SpawnPoint> _points = new ();

        private void Start() => ActiveComponentsProvider.LevelChanged += OnLevelChanged;

        private void OnDestroy() => ActiveComponentsProvider.LevelChanged -= OnLevelChanged;

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
            _points = ActiveComponentsProvider.ActivePoints;
        }
    }
}