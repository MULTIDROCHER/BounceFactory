using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationItem : Item
{
    //public override ItemType Type { get => Type; protected set => Type = ItemType.Acceleration; }
    //public override ItemType Type { get { return ItemType.Acceleration; } protected set { } }
    private int _acceleration = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))
            if (ball.TryGetComponent(out Rigidbody2D rigidBody))
                rigidBody.velocity = transform.up.normalized * _acceleration;
    }
}