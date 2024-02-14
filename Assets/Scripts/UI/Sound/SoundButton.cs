using UnityEngine;
using UnityEngine.UI;

namespace BounceFactory.UI.Sound
{
    [RequireComponent(typeof(Button))]
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private Sprite _unmuted;
        [SerializeField] private Sprite _muted;
        [SerializeField] private Image _image;

        protected Button Button;

        private void Awake() => Button = GetComponent<Button>();

        protected void OnVolumeChanged(bool muted) => _image.sprite = muted ? _unmuted : _muted;
    }
}