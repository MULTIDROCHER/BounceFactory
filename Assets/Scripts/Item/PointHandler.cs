using UnityEngine;

namespace BounceFactory
{
    public class PointHandler : MonoBehaviour
    {
        public SpawnPoint PreviousPoint { get; private set; }

        private void Start() => TryGetPoint();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out SpawnPoint point) && point.IsEmpty)
                PreviousPoint = point;
        }

        private void TryGetPoint()
        {
            float radius = .5f;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

            foreach (Collider2D collider in colliders)
                if (collider.TryGetComponent(out SpawnPoint point) && point.IsEmpty)
                    PreviousPoint = point;
        }
    }
}