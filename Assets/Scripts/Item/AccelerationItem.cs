using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationItem : Item
{
    private int _acceleration = 20;

    private void Start() => _type = ItemType.Acceleration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))
            if (ball.TryGetComponent(out Rigidbody2D rigidBody))
                rigidBody.velocity = rigidBody.velocity.normalized * _acceleration;
    }
}