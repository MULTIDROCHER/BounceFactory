using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGeneratorItem : Item
{
    private Collider2D _collider;
    private int _amount = 2;
    private int _acceleration = 10;
    private List<Ball> _spawned;
    private int _delay = 3;

    private void Awake()
    {
        Type = ItemType.BallGenerator;
        _collider = GetComponent<Collider2D>();
        _spawned = new List<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            _collider.enabled = false;
            CreateClones(ball);
            StartCoroutine(DestroyBallsAfterDelay());
        }
    }

    private void CreateClones(Ball ball)
    {
        for (int i = 0; i < _amount; i++)
        {
            var clone = Instantiate(ball, transform.position, Quaternion.identity);
            clone.TryGetComponent(out Rigidbody2D rigidbody);
            rigidbody.velocity = rigidbody.velocity.normalized * _acceleration;
            _spawned.Add(clone);
        }
    }

    private IEnumerator DestroyBallsAfterDelay()
    {
        yield return new WaitForSeconds(_delay);

        foreach (var item in _spawned)
            Destroy(item.gameObject);

        Reset();
    }

    private void Reset()
    {
        _spawned.Clear();
        _collider.enabled = true;
    }
}