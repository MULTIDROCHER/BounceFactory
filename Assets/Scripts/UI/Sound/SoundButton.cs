using BounceFactory.System.Game.Sound;
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

        protected VolumeChanger VolumeChanger => SourceProvider.SoundSystem.VolumeChanger;

        protected void OnVolumeChanged(bool muted) => _image.sprite = muted ? _unmuted : _muted;

        private void Awake() => Button = GetComponent<Button>();
    }
}