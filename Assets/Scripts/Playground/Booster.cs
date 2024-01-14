using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    
    private readonly float _acceleration = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            ball.TryGetComponent(out Rigidbody2D rigidbody);
            rigidbody.velocity = _direction.normalized * _acceleration;
        }
    }
}