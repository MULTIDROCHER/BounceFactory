public class SFXButton : SoundButton
{
    override protected void Start()
    {
        Source = SoundManager.Instance.SFXSource;
        base.Start();
    }
}