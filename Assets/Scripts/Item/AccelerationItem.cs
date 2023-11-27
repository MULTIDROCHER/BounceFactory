using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationItem : Item
{
    private int _acceleration = 10;

    private void Awake() => Type = ItemType.Acceleration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))
            if (ball.TryGetComponent(out Rigidbody2D rigidBody))
                rigidBody.velocity = transform.up.normalized * _acceleration;
    }
}