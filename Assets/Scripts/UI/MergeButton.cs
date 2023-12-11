using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MergeButton : MonoBehaviour
{
    private Tween _animation;
    private Vector3 _defaultScale;
    private Vector3 _scale = new(.3f, .3f, 0);
    private float _duration = .5f;
    private Button _button;

    private void Start()
    {
        _defaultScale = transform.localScale;

        TryGetComponent(out _button);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _animation = transform.DOScale(_scale, _duration).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable()
    {
        _animation.Kill();
        transform.localScale = _defaultScale;
        _button.onClick.RemoveAllListeners();
    }
}
