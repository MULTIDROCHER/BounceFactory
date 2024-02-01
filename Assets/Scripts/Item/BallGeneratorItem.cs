using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory
{
    [RequireComponent(typeof(EffectApplier))]
    [RequireComponent(typeof(Animator))]
    public class BallGeneratorItem : Item, IAnimated
    {
        [SerializeField] private ParticleSystem _spawnEffect;
        [SerializeField] private ParticleSystem _destroyEffect;

        private readonly int _accelerationAmount = 10;
        private readonly List<Ball> _spawned = new();

        private Animator _animator;
        private EffectApplier _effectHandler;
        private int _amount = 2;
        private int _delay = 3;

        public bool IsActive { get; private set; } = true;

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
            _effectHandler = GetComponent<EffectApplier>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Ball ball) && IsActive)
            {
                IsActive = false;
                PlayAnimation(other);
                CreateClones(ball);
                StartCoroutine(DestroyBallsAfterDelay());
            }
        }

        public override void LevelUp()
        {
            base.LevelUp();

            _delay++;
            _amount++;
        }

        public void PlayAnimation(Collider2D _) => _animator.SetTrigger(IAnimated.Trigger);

        private void OnDestroy()
        {
            foreach (var ball in _spawned)
                Destroy(ball.gameObject);
        }

        private Vector2 SetDirection() => Vector2.right * Random.Range(0, 360);

        private void CreateClones(Ball ballToClone)
        {
            for (int i = 0; i < _amount; i++)
            {
                var clone = Instantiate(ballToClone, transform.position, Quaternion.identity);
                clone.Rigidbody.velocity = SetDirection().normalized * _accelerationAmount;
                _spawned.Add(clone);
            }

            _effectHandler.DoEffect(_spawnEffect, transform.position);
        }

        private IEnumerator DestroyBallsAfterDelay()
        {
            yield return new WaitForSeconds(_delay);

            foreach (var ball in _spawned.ToArray())
                if (ball != null)
                {
                    Destroy(ball.gameObject);
                    _effectHandler.DoEffect(_destroyEffect, ball.transform.position);
                }

            Reset();
        }

        private void Reset()
        {
            StopCoroutine(DestroyBallsAfterDelay());
            _spawned.Clear();
            IsActive = true;
        }
    }
}