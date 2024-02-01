using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace BounceFactory
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Ball))]
    public class TeleportableObject : MonoBehaviour
    {
        private readonly float _duration = .5f;
        private readonly float _delay = 3;
        private Vector2 _defaultSize;

        private Rigidbody2D _rigidbody;
        private Ball _ball;
        private WaitForSeconds _wait;

        public bool CanBeTeleported { get; private set; } = true;

        private void Start()
        {
            _defaultSize = transform.localScale;
            _wait = new(_delay);

            _ball = GetComponent<Ball>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Appear(Vector3 portalPosition, BonusHandler bonusHandler)
        {
            transform.position = portalPosition;
            transform.DOScale(_defaultSize, _duration).OnComplete(() =>
            {
                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
                bonusHandler.AddBonus(portalPosition, _ball);
            });
            StartCoroutine(OnAppeared());
        }

        public void Disappear(Vector3 portalPosition)
        {
            transform.DOMove(portalPosition, _duration, false);
            transform.DOScale(Vector3.zero, _duration).OnComplete(() =>
            {
                _rigidbody.bodyType = RigidbodyType2D.Static;
                CanBeTeleported = false;
            });
        }

        private IEnumerator OnAppeared()
        {
            yield return _wait;
            CanBeTeleported = true;
            StopAllCoroutines();
        }
    }
}