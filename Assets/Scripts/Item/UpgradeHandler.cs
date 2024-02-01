using System;
using UnityEngine;

namespace BounceFactory
{
    [RequireComponent(typeof(Item))]
    public class UpgradeHandler : MonoBehaviour, ITutorialEvent
    {
        [SerializeField] private ParticleSystem _effect;
        [SerializeField] private LevelDisplay _displayTemplate;
        [SerializeField] private Material _mergeMaterial;

        private Material _defaultMaterial;
        private SpriteRenderer _renderer;
        private LevelDisplay _display;
        private Item _current;
        private Item _itemToMerge;

        public event Action Performed;

        public LevelDisplay LevelDisplay => _display;

        private void Awake()
        {
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
                _itemToMerge = GetItem(other);
            else
                _renderer.material = _mergeMaterial;
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

        private void ResetItem(GameObject item)
        {
            if (_itemToMerge.gameObject == item)
            {
                _itemToMerge = null;
                _renderer.material = _defaultMaterial;
            }
        }

        private void LevelUp(Item item)
        {
            Performed?.Invoke();
            ItemSelector merger = new(_current, item);
            var template = merger.GetRandom();

            template.LevelUp();
            DoEffect(template.transform);

            if (template != item)
                item.Destroy();
            else
                _current.Destroy();
        }

        private void DoEffect(Transform parent) => Instantiate(_effect, parent);
    }
}