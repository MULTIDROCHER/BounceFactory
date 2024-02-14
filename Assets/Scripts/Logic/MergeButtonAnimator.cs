using DG.Tweening;
using UnityEngine;

namespace BounceFactory
{
    [RequireComponent(typeof(MergeButton))]
    public class MergeButtonAnimator : MonoBehaviour
    {
        private readonly float _duration = .5f;

        private Vector3 _defaultScale;
        private Vector3 _scale = new (.3f, .3f, 0);
        private Tween _animation;

        private void Awake()
        {
            _defaultScale = transform.localScale;
            gameObject.SetActive(false);
        }

        private void OnEnable() => _animation = transform.DOScale(_scale, _duration).SetLoops(-1, LoopType.Yoyo);

        private void OnDisable()
        {
            _animation.Kill();
            transform.localScale = _defaultScale;
        }
    }
}