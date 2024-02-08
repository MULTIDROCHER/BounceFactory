using BounceFactory.Playground.Storage;
using UnityEngine;

namespace BounceFactory.BaseObjects
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Ball : UpgradableObject
    {
        private Rigidbody2D _rigidbody;
        private Collider2D _collider;
        private EffectContainer _effectContainer;

        public Rigidbody2D Rigidbody => _rigidbody;
        
        public Collider2D Collider => _collider;

        public EffectContainer EffectContainer => _effectContainer;

        protected override void Awake()
        {
            base.Awake();

            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();

            BonusIncrease = 2;
            ObjectsAmount = 3;
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