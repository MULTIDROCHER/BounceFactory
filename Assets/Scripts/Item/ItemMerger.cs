using UnityEngine;

public class ItemMerger
{
    private Item _current;
    private Item _target;

    public ItemMerger(Item current, Item target)
    {
        _current = current;
        _target = target;
    }

    public Item ChooseItem()
    {
        int chance = Random.Range(0, 2);

        if (chance == 0)
            return _target;
        else
            return _current;
    }
}