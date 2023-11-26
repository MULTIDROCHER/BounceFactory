using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGeneratorItem : Item
{
    private int _lifetime = 3;
    private int _amount = 2;
    private int _acceleration = 10;

    private void Start() => _type = ItemType.BallGenerator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))
            CreateClones(ball);
    }

    private void CreateClones(Ball ball)
    {
        for (int i = 0; i < _amount; i++)
        {
            var spawned = Instantiate(ball, transform);
            spawned.TryGetComponent(out Rigidbody2D rigidbody);

            rigidbody.velocity = rigidbody.velocity.normalized * _acceleration;

            Destroy(spawned, _lifetime);
        }
    }
}