using BounceFactory.System.Game.SoundSystem;

namespace BounceFactory.UI.Sound
{
    public class MusicButton : SoundButton
    {
        private void OnEnable()
        {
            Button.onClick.AddListener(SoundAssets.Instance.SwitchMusicSource);
            SoundManager.VolumeChanger.MusicVolumeChanged += OnVolumeChanged;
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(SoundAssets.Instance.SwitchMusicSource);
            SoundManager.VolumeChanger.MusicVolumeChanged -= OnVolumeChanged;
        }
    }
}