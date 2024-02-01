using UnityEngine.UI;
using UnityEngine;

namespace BounceFactory
{
    [RequireComponent(typeof(Button))]
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private Sprite _unmuted;
        [SerializeField] private Sprite _muted;
        [SerializeField] private Image _image;

        protected AudioSource Source;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        protected virtual void Start()
        {
            if (Source.volume == 0)
                Mute();
            else
                Unmute();
        }

        private void OnEnable() => _button.onClick.AddListener(() => AudioManager.Instance.SwitchSource(Source, this));

        private void OnDisable() => _button.onClick.RemoveAllListeners();

        public void Mute() => _image.sprite = _muted;

        public void Unmute() => _image.sprite = _unmuted;
    }
}