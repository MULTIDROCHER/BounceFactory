using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class MergeButton : MonoBehaviour
{
    private readonly float _duration = .5f;

    private Vector3 _defaultScale;
    private Vector3 _scale = new(.3f, .3f, 0);
    private Button _button;
    private Tween _animation;

    public Button Button => _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _defaultScale = transform.localScale;
        gameObject.SetActive(false);
    }

    private void OnEnable() => _animation = transform.DOScale(_scale, _duration).SetLoops(-1, LoopType.Yoyo);

    private void OnDisable()
    {
        _animation.Kill();
        transform.localScale = _defaultScale;
        _button.onClick.RemoveAllListeners();
    }
}