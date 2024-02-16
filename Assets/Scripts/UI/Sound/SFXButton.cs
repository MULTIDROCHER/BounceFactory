using BounceFactory.System.Game.SoundSystem;

namespace BounceFactory.UI.Sound
{
    public class SFXButton : SoundButton
    {
        private void OnEnable()
        {
            Button.onClick.AddListener(SoundManager.VolumeChanger.SwitchSFXSources);
            SoundManager.VolumeChanger.SFXVolumeChanged += OnVolumeChanged;
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(SoundManager.VolumeChanger.SwitchSFXSources);
            SoundManager.VolumeChanger.SFXVolumeChanged -= OnVolumeChanged;
        }
    }
}