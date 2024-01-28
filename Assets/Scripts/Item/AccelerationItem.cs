using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EffectHandler))]
public class AccelerationItem : Item
{
    private readonly int _acceleration = 10;
    private readonly float _delay = .5f;

    private Ball _previousBall;
    private EffectHandler _effectHandler;

    protected override void Awake()
    {
        base.Awake();
        _effectHandler = GetComponent<EffectHandler>();
    }

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
        ball.Rigidbody.velocity = transform.up.normalized * _acceleration;

        if (ball.GetComponentInChildren<ParticleSystem>() == null)
            _effectHandler.DoEffect(ball);

        yield return new WaitForSeconds(_delay);

        _previousBall = null;
        StopAllCoroutines();
    }
}