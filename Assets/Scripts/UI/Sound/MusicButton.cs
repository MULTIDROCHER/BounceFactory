using BounceFactory.System.Game.Sound;

namespace BounceFactory.UI.Sound
{
    public class MusicButton : SoundButton
    {
        private void OnEnable()
        {
            Button.onClick.AddListener(VolumeChanger.SwitchMusicSource);
            VolumeChanger.MusicVolumeChanged += OnVolumeChanged;
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(VolumeChanger.SwitchMusicSource);
            VolumeChanger.MusicVolumeChanged -= OnVolumeChanged;
        }
    }
}