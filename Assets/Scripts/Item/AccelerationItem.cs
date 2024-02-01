using System.Collections;
using UnityEngine;

namespace BounceFactory
{
    [RequireComponent(typeof(EffectApplier))]
    public class AccelerationItem : Item
    {
        private readonly int _accelerationAmount = 10;
        private readonly float _delay = .5f;

        private Ball _previousBall;
        private EffectApplier _effectApplier;

        protected override void Awake()
        {
            base.Awake();
            _effectApplier = GetComponent<EffectApplier>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Ball ball))
                if (_previousBall != ball)
                    StartCoroutine(SetAcceleration(ball, ball.Rigidbody));
                else
                    return;
        }

        private IEnumerator SetAcceleration(Ball ball, Rigidbody2D rigidbody)
        {
            _previousBall = ball;

            rigidbody.velocity = transform.up.normalized * _accelerationAmount;

            if (ball.GetComponentInChildren<ParticleSystem>() == null)
                _effectApplier.DoEffect(ball);

            yield return new WaitForSeconds(_delay);

            _previousBall = null;
            StopAllCoroutines();
        }
    }
}