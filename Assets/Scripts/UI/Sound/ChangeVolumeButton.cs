using BounceFactory.System.Game.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace BounceFactory.UI.Sound
{
    [RequireComponent(typeof(Button))]
    public class ChangeVolumeButton : MonoBehaviour
    {
        private readonly VolumeChanger _volumeChanger = new ();

        [SerializeField] private Sprite _unmuted;
        [SerializeField] private Sprite _muted;
        [SerializeField] private Image _image;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ChangeVolume);
        }

        private void OnDestroy() => _button.onClick.RemoveListener(ChangeVolume);

        public void ChangeVolume()
        {
            if (AudioListener.volume == 0)
            {
                _image.sprite = _unmuted;
                _volumeChanger.Unmute();
            }
            else
            {
                _image.sprite = _muted;
                _volumeChanger.Mute();
            }
        }
    }
}