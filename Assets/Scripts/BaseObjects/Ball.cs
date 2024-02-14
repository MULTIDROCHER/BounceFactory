using BounceFactory.BaseObjects.ItemComponents;
using BounceFactory.Playground.Storage;
using UnityEngine;

namespace BounceFactory.BaseObjects
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(EffectApplier))]
    public class Ball : UpgradableObject
    {
        private Rigidbody2D _rigidbody;
        private Collider2D _collider;
        private EffectContainer _effectContainer;
        private EffectApplier _effectApplier;

        public Rigidbody2D Rigidbody => _rigidbody;

        public Collider2D Collider => _collider;

        public EffectContainer EffectContainer => _effectContainer;

        protected override void Awake()
        {
            base.Awake();

            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
            _effectApplier = GetComponent<EffectApplier>();

            BonusIncrease = 2;
            ObjectsAmount = 3;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_effectContainer != null)
                _effectApplier.DoEffect(other.GetContact(0).point, _effectContainer.transform);
        }

        public override void LevelUp()
        {
            base.LevelUp();

            _rigidbody.velocity = Vector2.zero;
        }

        public void ChangeColor(Color color) => Renderer.color = color;

        public void GetEffectContainer(EffectContainer container) => _effectContainer = container;
    }
}