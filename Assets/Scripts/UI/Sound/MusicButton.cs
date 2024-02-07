using BounceFactory.System.Game;

namespace BounceFactory.UI.Sound
{
    public class MusicButton : SoundButton
    {
        protected override void Start()
        {
            Source = AudioPlayer.Instance.MusicSource;
            base.Start();
        }
    }
}