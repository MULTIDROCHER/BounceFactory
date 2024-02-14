using BounceFactory.System.Game.SoundSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

namespace BounceFactory.UI
{
    [RequireComponent(typeof(Button))]
    public class SoundableButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        protected AudioSource Source;
        protected Button Button;

        private Vector3 _increasedScale = new(.1f, .1f, 0);
        private Vector3 _defaultScale;

        private void Awake()
        {
            Button = GetComponent<Button>();
            _defaultScale = transform.localScale;
        } 

        protected virtual void Start()
        {
            if (SourcePool.SFXSources.TryGetValue(System.Game.SoundSystem.Sound.Click, out Source))
                Button.onClick.AddListener(() => SoundManager.PlayOneShot(Source));
        }

        private void OnDestroy() => Button.onClick.RemoveAllListeners();

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
            if (Button.interactable)
                transform.localScale += _increasedScale;
        }

        private void SetDefaultScale() => transform.localScale = _defaultScale;
    }
}