using UnityEngine;

public class PipeEnter : MonoBehaviour
{
    private readonly float _acceleration = 100f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))

            if (ball.TryGetComponent(out Rigidbody2D rigidBody))
                rigidBody.velocity = rigidBody.velocity.normalized * _acceleration;
    }
}