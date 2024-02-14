using BounceFactory.Logic.Spawning;
using UnityEngine;

namespace BounceFactory.BaseObjects.ItemComponents
{
    public class PointHandler : MonoBehaviour
    {
        public SpawnPoint PreviousPoint { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsEmptyPoint(other, out SpawnPoint point))
                PreviousPoint = point;
        }

        private bool IsEmptyPoint(Collider2D collider, out SpawnPoint point)
        {
            point = collider.GetComponent<SpawnPoint>();

            return point != null && point.IsEmpty;
        }
    }
}