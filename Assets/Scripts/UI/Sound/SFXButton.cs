using BounceFactory.System.Game;

namespace BounceFactory.UI.Sound
{
    public class SFXButton : SoundButton
    {
        override protected void Start()
        {
            Source = AudioPlayer.Instance.SFXSource;
            base.Start();
        }
    }
}