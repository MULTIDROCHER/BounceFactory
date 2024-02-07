using BounceFactory.System.Game;

namespace BounceFactory.UI.Sound
{
    public class SFXButton : SoundButton
    {
        protected override void Start()
        {
            Source = AudioPlayer.Instance.SFXSource;
            base.Start();
        }
    }
}