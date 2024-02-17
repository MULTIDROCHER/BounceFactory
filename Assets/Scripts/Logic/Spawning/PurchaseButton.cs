using BounceFactory.System.Game.Sound;
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