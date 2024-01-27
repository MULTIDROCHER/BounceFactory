using UnityEngine;

public class ItemMerger
{
    private readonly Item _current;
    private readonly Item _target;

    public ItemMerger(Item current, Item target)
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