using BounceFactory.System.Game.SoundSystem;

namespace BounceFactory.UI.Sound
{
    public class SFXButton : SoundButton
    {
        private void OnEnable()
        {
            Button.onClick.AddListener(SoundAssets.Instance.SwitchSFXSources);
            SoundManager.VolumeChanger.SFXVolumeChanged += OnVolumeChanged;
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(SoundAssets.Instance.SwitchSFXSources);
            SoundManager.VolumeChanger.SFXVolumeChanged -= OnVolumeChanged;
        }
    }
}