using BounceFactory.BaseObjects;
using BounceFactory.BaseObjects.ItemComponents;
using UnityEngine;

namespace BounceFactory.Logic.Spawning
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpawnPoint : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        private ItemClickHandler _clickHandler;

        public Item Item { get; private set; }

        public bool IsEmpty { get; private set; } = true;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            HidePoint();
        }

        private void OnMouseDown()
        {
            if (_clickHandler != null)
                _clickHandler.OnClick();
        }

        private void OnMouseUp()
        {
            if (_clickHandler != null)
                _clickHandler.OnDrop();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item item)
            && IsEmpty)
            {
                Item = item;
                _clickHandler = item.GetComponent<ItemClickHandler>();
                IsEmpty = false;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (Item != null
            && other.gameObject == Item.gameObject)
            {
                Item = null;
                _clickHandler = null;
                IsEmpty = true;
            }
        }

        public void ShowPoint() => _renderer.enabled = true;

        public void HidePoint() => _renderer.enabled = false;
    }
}