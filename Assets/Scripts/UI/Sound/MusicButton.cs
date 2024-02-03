using BounceFactory.System.Game;

namespace BounceFactory.UI.Sound
{
    public class MusicButton : SoundButton
    {
        override protected void Start()
        {
            Source = AudioPlayer.Instance.MusicSource;
            base.Start();
        }
    }
}