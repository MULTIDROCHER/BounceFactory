using BounceFactory.System.Game.SoundSystem;
using BounceFactory.UI;
using UnityEngine.UI;

namespace BounceFactory.Logic.Spawning
{
    public class PurchaseButton : SoundableButton
    {
        protected override void Start()
        {
            if (SourcePool.SFXSources.TryGetValue(Sound.Purchase, out Source))
                Button.onClick.AddListener(() => SoundManager.PlayOneShot(Source));
        }
    }
}