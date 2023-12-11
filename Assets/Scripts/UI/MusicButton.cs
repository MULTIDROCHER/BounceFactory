public class MusicButton : SoundButton
{
    override protected void Start()
    {
        Source = SoundManager.Instance.MusicSource;
        base.Start();
    }
}