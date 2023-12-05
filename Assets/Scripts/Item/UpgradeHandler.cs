using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Item _current;
    private Item _itemToMerge;

    private void Awake()
    {
        TryGetComponent(out _renderer);
        TryGetComponent(out _current);
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) => HandleCollision(other.gameObject);

    private void OnCollisionEnter2D(Collision2D other) => HandleCollision(other.gameObject);

    private void OnTriggerExit2D(Collider2D other) => ResetItem(other.gameObject);

    private void OnCollisionExit2D(Collision2D other) => ResetItem(other.gameObject);

    private void OnMouseUp()
    {
        if (_itemToMerge != null)
            LevelUp(_itemToMerge);
        else
            enabled = false;
    }

    private void HandleCollision(GameObject other)
    {
        if (_itemToMerge != null)
            _renderer.color = Color.cyan;
        else if (other.TryGetComponent(out Item _))
            _itemToMerge = GetItem();
    }

    private void ResetItem(GameObject item)
    {
        if (_itemToMerge == item.GetComponent<Item>())
        {
            _itemToMerge = null;
            _renderer.color = Color.white;
        }
    }

    private void LevelUp(Item item)
    {
        ItemMerger merger = new(_current, item);
        merger.GetNewItemData(out ItemType type, out Sprite sprite);

        _current.LevelUp(type, sprite);
        Destroy(item.gameObject);
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
}