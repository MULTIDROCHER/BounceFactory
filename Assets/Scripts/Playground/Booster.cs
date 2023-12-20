using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    private float _acceleration = 60f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            ball.TryGetComponent(out Rigidbody2D rigidbody);
            rigidbody.velocity = _direction.normalized * _acceleration;
        }
    }
}
