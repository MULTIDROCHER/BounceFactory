using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    private Item _current;
    private Item _itemToMerge;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        TryGetComponent(out _current);
        TryGetComponent(out _renderer);
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_itemToMerge != null)

            _renderer.color = Color.cyan;
        else if (other.TryGetComponent(out Item _))
            _itemToMerge = GetItem();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_itemToMerge != null)
            _renderer.color = Color.cyan;
        else if (other.gameObject.TryGetComponent(out Item _))
            _itemToMerge = GetItem();
    }

    private void OnTriggerExit2D(Collider2D other) => ResetItem(other.gameObject);

    private void OnCollisionExit2D(Collision2D other) => ResetItem(other.gameObject);

    private void OnMouseUp()
    {
        if (_itemToMerge != null)
            LevelUp(_itemToMerge);
        else
            enabled = false;
    }

    private void LevelUp(Item item)
    {
        SetNewItem(item, out ItemType type, out Sprite sprite);
        _current.LevelUp(type, sprite);
        Destroy(item.gameObject);
    }

    private void SetNewItem(Item item, out ItemType type, out Sprite sprite)
    {
        int chance = Random.Range(0, 2);
        Debug.Log(chance);

        if (item.Type == _current.Type
        && item.Type == ItemType.Common)
        {
            type = ItemType.Common;
            sprite = ChooseSprite(item, chance);
        }
        else
        {
            var baseItem = ChooseItem(item, chance);
            type = baseItem.Type;
            sprite = baseItem.Sprite.sprite;
        }
    }

    private Item ChooseItem(Item item, int chance)
    {
        if (chance == 0)
            return item;
        else
            return _current;
    }

    private Sprite ChooseSprite(Item item, int chance)
    {
        if (chance == 0)
            return item.Sprite.sprite;
        else
            return _current.Sprite.sprite;
    }

    private Item GetItem()
    {
        float radius = 1f;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
            if (collider.TryGetComponent(out Item item)
            && item.CanBeUpgraded
            && item.Level == _current.Level
            && item != _current)
                return item;

        return null;
    }

    private void ResetItem(GameObject item)
    {
        if (_itemToMerge == item.GetComponent<Item>())
        {
            _itemToMerge = null;
            _renderer.color = Color.white;
        }
    }
}