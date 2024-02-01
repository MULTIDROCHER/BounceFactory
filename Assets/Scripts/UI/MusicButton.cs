namespace BounceFactory
{
    public class MusicButton : SoundButton
    {
        override protected void Start()
        {
            Source = AudioManager.Instance.MusicSource;
            base.Start();
        }
    }
}