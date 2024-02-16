using BounceFactory.System.Game.SoundSystem;
using BounceFactory.UI;

namespace BounceFactory.Logic.Spawning
{
    public class PurchaseButton : SoundableButton
    {
        protected override void Start()
        {
            Sound = SoundName.Purchase;
            base.Start();
        }
    }
}