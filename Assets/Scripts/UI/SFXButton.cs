public class SFXButton : SoundButton
{
    override protected void Start()
    {
        Source = AudioManager.Instance.SFXSource;
        base.Start();
    }
}