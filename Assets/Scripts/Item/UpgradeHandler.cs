using System;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour, ITutorialEvent
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private LevelDisplay _display;
    [SerializeField] private Material _mergeMaterial;

    private Material _defaultMaterial;
    private SpriteRenderer _renderer;
    private Item _current;
    private Item _itemToMerge;

    public event Action Performed;

    private void Awake()
    {
        TryGetComponent(out _renderer);
        TryGetComponent(out _current);
        enabled = false;

        Instantiate(_display, transform);
        _defaultMaterial = _renderer.material;
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

    private void DoEffect(Transform parent) => Instantiate(_effect, parent);

    private void HandleCollision(GameObject other)
    {
        if (_itemToMerge == null)
            _itemToMerge = GetItem(other);
        else
            _renderer.material = _mergeMaterial;
    }

    private void ResetItem(GameObject item)
    {
        if (_itemToMerge == item.GetComponent<Item>())
        {
            _itemToMerge = null;
            _renderer.material = _defaultMaterial;
        }
    }

    private void LevelUp(Item item)
    {
        Performed?.Invoke();
        ItemMerger merger = new(_current, item);
        var template = merger.ChooseItem();

        template.LevelUp();
        DoEffect(template.transform);

        if (template != item)
            TryToDestroy(item);
        else
            TryToDestroy(_current);
    }

    private Item GetItem(GameObject other)
    {
        if (other.TryGetComponent(out Item item)
            && item.Level == _current.Level
            && item != _current)
            return item;
        else
            return null;
    }

    private void TryToDestroy(Item item)
    {
        if (item.TryGetComponent(out TeleportItem teleport))
            StartCoroutine(teleport.Destroy());
        else
            Destroy(item.gameObject);
    }
}