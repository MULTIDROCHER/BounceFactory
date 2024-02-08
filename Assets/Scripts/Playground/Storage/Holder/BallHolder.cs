using BounceFactory.BaseObjects;
using BounceFactory.System.Level;

namespace BounceFactory.Playground.Storage.Holder
{
    public class BallHolder : Holder<Ball>
    {

        private void OnEnable() => BallComponentsProvider.LevelExit += OnLevelExit;

        private void OnDisable() => BallComponentsProvider.LevelExit -= OnLevelExit;
    }
}