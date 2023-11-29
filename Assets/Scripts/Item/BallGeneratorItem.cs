using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGeneratorItem : Item
{
    //public override ItemType Type { get => base.Type; protected set => base.Type = ItemType.BallGenerator; }
    //public override ItemType Type { get { return ItemType.BallGenerator; } protected set { } }
    private int _amount = 2;
    private int _acceleration = 10;
    private int _delay = 3;
    private bool _isActive = true;
    private List<Ball> _spawned;

    private void Awake()
    {
        //Type = ItemType.BallGenerator;
        _spawned = new List<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball) && _isActive)
        {
            _isActive = false;
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
            rigidbody.velocity = SetDirection().normalized * _acceleration;
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
        _isActive = true;
    }

    private Vector2 SetDirection() => Vector2.right * Random.Range(0, 360);
}