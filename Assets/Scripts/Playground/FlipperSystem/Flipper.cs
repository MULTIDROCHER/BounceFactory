using BounceFactory.BaseObjects;
using BounceFactory.System.Game.Sound;
using DG.Tweening;
using UnityEngine;

namespace BounceFactory.Playground.FlipperSystem
{
    public class Flipper : MonoBehaviour
    {
        private readonly float _delay = .1f;
        private readonly int _acceleration = 10;

        [SerializeField] private float _angle;

        private Vector3 _rotation;
        private SoundPlayer _player;
        private bool _isOpened = false;

        private void Start()
        {
            _rotation = new (0, 0, _angle);
            _player = new (SoundName.Flipper);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Ball ball) && _isOpened)
                AddAcceleration(ball);
        }

        public void Open()
        {
            _player.PlaySound();
            _isOpened = true;

            transform.DORotate(_rotation, _delay).OnComplete(() =>
            {
                transform.DORotate(Vector3.zero, _delay)
                .OnComplete(() => _isOpened = false);
            });
        }

        private void AddAcceleration(Ball ball) => ball.Rigidbody.velocity = new (0, _acceleration);
    }
}