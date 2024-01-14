using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckPreventer : MonoBehaviour
{
    private readonly float _delay = 2;
    private float _count;
    private Vector3 _previousPosition;
    private Vector3 _step = new(2, 2, 0);
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _previousPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_previousPosition == transform.position)
            _count += Time.deltaTime;


        if (_count >= _delay)
        {
            Push();
            _count = 0;
        }

        _previousPosition = transform.position;
    }

    private void OnMouseDown() => Push();

    private void Push() => _rigidbody.AddForce(_step);
}