using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EffectHandler))]
public class AccelerationItem : Item
{
    private readonly int _acceleration = 10;
    private readonly float _delay = .5f;

    private Ball _previousBall;
    private EffectHandler _effectHandler;

    private void Start() => TryGetComponent(out _effectHandler);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball))
            if (_previousBall != ball)
                StartCoroutine(SetAcceleration(ball));
            else
                return;
    }

    private IEnumerator SetAcceleration(Ball ball)
    {
        _previousBall = ball;
        ball.TryGetComponent(out Rigidbody2D rigidBody);

        rigidBody.velocity = transform.up.normalized * _acceleration;

        if (ball.GetComponentInChildren<ParticleSystem>() == null)
            _effectHandler.DoEffect(ball);

        yield return new WaitForSeconds(_delay);

        _previousBall = null;
        StopAllCoroutines();
    }
}