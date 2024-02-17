using BounceFactory.System.Game.Sound;

namespace BounceFactory.UI.Sound
{
    public class SFXButton : SoundButton
    {
        private void OnEnable()
        {
            Button.onClick.AddListener(VolumeChanger.SwitchSFXSources);
            VolumeChanger.SFXVolumeChanged += OnVolumeChanged;
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(VolumeChanger.SwitchSFXSources);
            VolumeChanger.SFXVolumeChanged -= OnVolumeChanged;
        }
    }
}