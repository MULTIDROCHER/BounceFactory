using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EffectHandler))]
public class AccelerationItem : Item
{
    private readonly int _acceleration = 10;
    private readonly float _delay = .2f;

    private bool _isActive = true;
    private EffectHandler _effectHandler;

    private void Start() => TryGetComponent(out _effectHandler);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball) && _isActive)
            StartCoroutine(SetAcceleration(ball));
    }

    private IEnumerator SetAcceleration(Ball ball)
    {
        if (ball.TryGetComponent(out Rigidbody2D rigidBody))
        {
            rigidBody.velocity = transform.up.normalized * _acceleration;
            _isActive = false;

            if (ball.GetComponentInChildren<ParticleSystem>() == null)
                _effectHandler.DoEffect(ball);
        }

        yield return new WaitForSeconds(_delay);

        _isActive = true;
        StopAllCoroutines();
    }
}