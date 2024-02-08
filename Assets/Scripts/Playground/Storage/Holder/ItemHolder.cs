using BounceFactory.BaseObjects;
using BounceFactory.System.Level;

namespace BounceFactory.Playground.Storage.Holder
{
    public class ItemHolder : Holder<Item>
    {

        private void OnEnable() => ItemComponentsProvider.LevelExit += OnLevelExit;

        private void OnDisable() => ItemComponentsProvider.LevelExit -= OnLevelExit;
    }
}