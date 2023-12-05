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

    public void GetNewItemData(out ItemType type, out Sprite sprite)
    {
        int chance = Random.Range(0, 2);
        Debug.Log(chance);

        if (_target.Type == _current.Type
        && _target.Type == ItemType.Common)
        {
            type = ItemType.Common;
            sprite = ChooseSprite(chance);
        }
        else
        {
            var baseItem = ChooseItem(chance);
            type = baseItem.Type;
            sprite = baseItem.Renderer.sprite;
        }
    }

    private Item ChooseItem(int chance)
    {
        if (chance == 0)
            return _target;
        else
            return _current;
    }

    private Sprite ChooseSprite(int chance)
    {
        if (chance == 0)
            return _target.Renderer.sprite;
        else
            return _current.Renderer.sprite;
    }
}