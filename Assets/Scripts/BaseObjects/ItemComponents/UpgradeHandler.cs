using System;
using BounceFactory.Display.ItemLevel;
using BounceFactory.Tutorial;
using UnityEngine;

namespace BounceFactory.BaseObjects.ItemComponents
{
    [RequireComponent(typeof(Item))]
    [RequireComponent(typeof(EffectApplier))]
    [RequireComponent(typeof(AudioSource))]
    public class UpgradeHandler : MonoBehaviour, ITutorialEvent
    {
        [SerializeField] private ItemLevelDisplay _displayTemplate;
        [SerializeField] private Material _mergeMaterial;

        private EffectApplier _effectApplier;
        private AudioSource _source;
        private Material _defaultMaterial;
        private SpriteRenderer _renderer;
        private ItemLevelDisplay _display;
        private Item _current;
        private Item _itemToMerge;

        public event Action Performed;

        public ItemLevelDisplay LevelDisplay => _display;

        private void Awake()
        {
            _effectApplier = GetComponent<EffectApplier>();
            _source = GetComponent<AudioSource>();
            _current = GetComponent<Item>();
            _renderer = _current.Renderer;

            _display = Instantiate(_displayTemplate, transform);
            _defaultMaterial = _renderer.material;

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
            if (_itemToMerge == null)
                _itemToMerge = GetItemToMerge(other);
            else
                _renderer.material = _mergeMaterial;
        }

        private Item GetItemToMerge(GameObject other)
        {
            if (TryGetItem(other, out Item item))
                return item;
            else
                return null;
        }

        private bool TryGetItem(GameObject other, out Item item)
        {
            item = other.GetComponent<Item>();

            return item != null && item.Level == _current.Level && item != _current;
        }

        private void ResetItem(GameObject item)
        {
            if (_itemToMerge != null && _itemToMerge.gameObject == item)
            {
                _itemToMerge = null;
                _renderer.material = _defaultMaterial;
            }
        }

        private void LevelUp(Item item)
        {
            Performed?.Invoke();
            ItemSelector merger = new (_current, item);
            var template = merger.GetRandom();

            template.LevelUp();
            _effectApplier.DoUpgradeEffect(template.transform);
            _source.PlayOneShot(_source.clip);

            if (template != item)
                item.Destroy();
            else
                _current.Destroy();
        }
    }
}