using UnityEngine;
using DG.Tweening;

namespace BounceFactory
{
    public class Flipper : MonoBehaviour
    {
        private readonly float _delay = .1f;
        private readonly int _acceleration = 10;

        [SerializeField] private float _angle;
        [SerializeField] private AudioClip _sound;

        private Vector3 _rotation;
        private bool _isOpened = false;

        private void Start() => _rotation = new(0, 0, _angle);

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Ball ball) && _isOpened)
                AddAcceleration(ball);
        }

        public void Open()
        {
            AudioManager.Instance.SFXSource.PlayOneShot(_sound);
            _isOpened = true;

            transform.DORotate(_rotation, _delay).OnComplete(() =>
            {
                transform.DORotate(Vector3.zero, _delay)
                .OnComplete(() => _isOpened = false);
            });
        }

        private void AddAcceleration(Ball ball) => ball.Rigidbody.velocity = new(0, _acceleration);
    }
}