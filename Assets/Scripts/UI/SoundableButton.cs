using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

[RequireComponent(typeof(Button))]
public class SoundableButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private AudioClip _clip;

    private AudioSource _source;
    private Button _button;
    private Vector3 _increasedScale = new(.1f, .1f, 0);
    private Vector3 _defaultScale;

    private void Start()
    {
        _source = SoundManager.Instance.SFXSource;
        _button = GetComponent<Button>();
        _defaultScale = transform.localScale;

        _button.onClick.AddListener(() => PlaySound());
    }

    public void OnPointerDown(PointerEventData eventData) => IncreaseScale();

    public void OnPointerUp(PointerEventData eventData) => SetDefaultScale();

    public void OnPointerExit(PointerEventData eventData)
    {
        if (YandexGame.EnvironmentData.isDesktop)
            SetDefaultScale();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (YandexGame.EnvironmentData.isDesktop)
            IncreaseScale();
    }

    private void IncreaseScale()
    {
        if (_button.interactable)
            transform.localScale += _increasedScale;
    }

    private void SetDefaultScale() => transform.localScale = _defaultScale;

    private void PlaySound() => _source.PlayOneShot(_clip);
}