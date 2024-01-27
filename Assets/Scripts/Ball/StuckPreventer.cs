using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StuckPreventer : MonoBehaviour
{
    private readonly float _delay = 2;
    private float _count;
    private Rigidbody2D _rigidbody;
    private Vector2 _step = new(2, 2);

    private void Start() => _rigidbody = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.magnitude <= .5f)
            _count += Time.deltaTime;
        else
            _count = 0;

        if (_count >= _delay)
        {
            Push();
            _count = 0;
        }
    }

    private void OnMouseDown() => Push();

    private void Push() => _rigidbody.velocity += _step;
}