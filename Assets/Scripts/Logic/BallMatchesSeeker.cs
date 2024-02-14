using System.Collections.Generic;
using System.Linq;
using BounceFactory.BaseObjects;
using BounceFactory.Playground.Storage.Holder;

namespace BounceFactory.Logic
{
    public class BallMatchesSeeker
    {
        private readonly int _requiredAmount = 3;

        public int RequiredAmount => _requiredAmount;

        public List<Ball> GetMatch(Holder<Ball> holder)
        {
            if (TryFindMatches(holder, out List<Ball> match))
            {
                if (match != null && match.Count == _requiredAmount)
                    return match;
            }

            return null;
        }

        private bool TryFindMatches(Holder<Ball> holder, out List<Ball> match)
        {
            var balls = holder.Contents;
            int maxLevel = balls.Max(ball => ball.Level);

            for (int level = maxLevel; level > 0; level--)
            {
                var matchingBalls = balls.Where(ball => ball != null && ball.Level == level).ToList();

                if (matchingBalls.Count >= _requiredAmount)
                {
                    match = matchingBalls.GetRange(0, _requiredAmount);
                    return true;
                }
            }

            match = null;
            return false;
        }
    }
}