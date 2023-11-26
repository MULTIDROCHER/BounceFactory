using UnityEngine;

public class PipeEnter : MonoBehaviour
{
    [SerializeField] private float _acceleration = 50f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))

            if (ball.TryGetComponent(out Rigidbody2D rigidBody))
                rigidBody.velocity = rigidBody.velocity.normalized * _acceleration;
    }
}