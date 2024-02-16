using BounceFactory.System.Game.SoundSystem;

namespace BounceFactory.UI.Sound
{
    public class MusicButton : SoundButton
    {
        private void OnEnable()
        {
            Button.onClick.AddListener(SoundManager.VolumeChanger.SwitchMusicSource);
            SoundManager.VolumeChanger.MusicVolumeChanged += OnVolumeChanged;
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(SoundManager.VolumeChanger.SwitchMusicSource);
            SoundManager.VolumeChanger.MusicVolumeChanged -= OnVolumeChanged;
        }
    }
}