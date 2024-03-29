using System.Collections;
using System.Collections.Generic;
using BounceFactory.BaseObjects.ItemComponents;
using UnityEngine;

namespace BounceFactory.BaseObjects
{
    [RequireComponent(typeof(EffectApplier))]
    [RequireComponent(typeof(Animator))]
    public class BallGeneratorItem : Item
    {
        private readonly int _accelerationAmount = 3;
        private readonly List<Ball> _spawned = new ();

        [SerializeField] private ParticleSystem _spawnEffect;
        [SerializeField] private ParticleSystem _destroyEffect;

        private EffectApplier _effectHandler;
        private Accelerator _accelerator;
        private AnimationPlayer _player;
        private Animator _animator;
        private WaitForSeconds _wait;
        private int _amount = 2;
        private int _delay = 3;

        public bool IsActive { get; private set; } = true;

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
            _player = new (_animator);
            _effectHandler = GetComponent<EffectApplier>();
            _accelerator = new (_accelerationAmount, GetRandomDirection());
            _wait = new (_delay);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Ball ball) && IsActive && Movement.IsDragging == false)
            {
                IsActive = false;
                _player.PlayAnimation();
                CreateClones(ball);
                StartCoroutine(DestroyBallsAfterDelay());
                BonusAdder.GiveRevard(transform.position, ball);
            }
        }

        private void OnDestroy()
        {
            foreach (var ball in _spawned)
            {
                if (ball != null)
                    Destroy(ball.gameObject);
            }
        }

        public override void LevelUp()
        {
            base.LevelUp();

            _delay++;
            _amount++;
        }

        private Vector2 GetRandomDirection()
        {
            var minAngle = 0;
            var maxAngle = 360;

            return Vector2.right * Random.Range(minAngle, maxAngle);
        }

        private void CreateClones(Ball ballToClone)
        {
            for (int i = 0; i < _amount; i++)
            {
                var clone = Instantiate(ballToClone, transform.position, Quaternion.identity);
                _accelerator.SetAcceleration(clone.Rigidbody);
                _spawned.Add(clone);
            }

            _effectHandler.DoEffect(_spawnEffect, transform.position);
        }

        private IEnumerator DestroyBallsAfterDelay()
        {
            yield return _wait;

            foreach (var ball in _spawned.ToArray())
            {
                if (ball != null)
                {
                    Destroy(ball.gameObject);
                    _effectHandler.DoEffect(_destroyEffect, ball.transform.position);
                }
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