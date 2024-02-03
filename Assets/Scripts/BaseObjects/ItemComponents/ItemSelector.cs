using UnityEngine;

namespace BounceFactory.BaseObjects.ItemComponents
{
    public class ItemSelector
    {
        private readonly Item _current;
        private readonly Item _target;

        public ItemSelector(Item current, Item target)
        {
            _current = current;
            _target = target;
        }

        public Item GetRandom()
        {
            int minRange = 0;
            int maxRange = 2;

            int chance = Random.Range(minRange, maxRange);

            if (chance == minRange)
                return _target;
            else
                return _current;
        }
    }
}