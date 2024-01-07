using UnityEngine;

[RequireComponent(typeof(EffectHandler))]
public class AccelerationItem : Item
{
    private readonly int _acceleration = 10;
    
    private EffectHandler _effectHandler;

    private void Start() => TryGetComponent(out _effectHandler);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball)
        && ball.TryGetComponent(out Rigidbody2D rigidBody))
        {
            rigidBody.velocity = transform.up.normalized * _acceleration;

            if (ball.GetComponentInChildren<ParticleSystem>() == null)
                _effectHandler.DoEffect(ball);
        }
    }
}