using BounceFactory.BaseObjects.ItemComponents;
using System.Collections;
using UnityEngine;

namespace BounceFactory.BaseObjects
{
    [RequireComponent(typeof(EffectApplier))]
    public class AccelerationItem : Item
    {
        private readonly int _accelerationAmount = 10;
        private readonly float _delay = .5f;

        private Ball _previousBall;
        private EffectApplier _effectApplier;
        private Accelerator _accelerator;
        private WaitForSeconds _wait;

        protected override void Awake()
        {
            base.Awake();
            _wait = new (_delay);
            _effectApplier = GetComponent<EffectApplier>();
            _accelerator = new (_accelerationAmount, transform.up.normalized);
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
            _accelerator.SetAcceleration(rigidbody);

            if (ball.GetComponentInChildren<ParticleSystem>() == null)
                _effectApplier.DoEffect(ball);

            yield return _wait;

            _previousBall = null;
            StopAllCoroutines();
        }
    }
}