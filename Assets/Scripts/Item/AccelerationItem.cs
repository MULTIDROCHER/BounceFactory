using UnityEngine;

public class AccelerationItem : Item
{
    private readonly int _acceleration = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball)
        && ball.TryGetComponent(out Rigidbody2D rigidBody))
            rigidBody.velocity = transform.up.normalized * _acceleration;
    }
}