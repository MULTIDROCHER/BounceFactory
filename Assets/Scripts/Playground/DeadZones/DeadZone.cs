using BounceFactory.BaseObjects;
using UnityEngine;

namespace BounceFactory.Playground.DeadZones
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] private DeadZonesProcessor _processor;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Ball ball))
            {
                if (IsNotClone(ball))
                    _processor.OnBallDestroyed();

                Destroy(ball.gameObject);
            }
        }

        private bool IsNotClone(Ball ball) => ball.transform.parent != null;
    }
}