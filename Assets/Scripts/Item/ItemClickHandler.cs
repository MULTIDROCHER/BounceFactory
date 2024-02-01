using UnityEngine;

namespace BounceFactory
{
    [RequireComponent(typeof(Item))]
    [RequireComponent(typeof(ItemMover))]
    [RequireComponent(typeof(BonusHandler))]
    public class ItemClickHandler : MonoBehaviour
    {
        private ItemLevelView _levelView;
        private SpawnPointsView _pointView;
        private BonusHandler _bonusHandler;
        private ItemMover _itemMovement;

        public Item Item { get; private set; }

        private void Awake()
        {
            _levelView = FindFirstObjectByType<ItemLevelView>();
            _pointView = FindFirstObjectByType<SpawnPointsView>();

            Item = GetComponent<Item>();
            _itemMovement = GetComponent<ItemMover>();
            _bonusHandler = GetComponent<BonusHandler>();
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
                OnClick();
            else if (Input.GetMouseButtonUp(0))
                OnDrop();
        }

        public void OnClick()
        {
            _itemMovement.OnStartMovement();
            _pointView.ShowPoints();
            _levelView.ShowLevel();
            DisableBonusHandler();
        }

        public void OnDrop()
        {
            _levelView.HideLevel();
            _pointView.HidePoints();
            _itemMovement.OnEndMovement();
            EnableBonusHandler();
        }

        private void EnableBonusHandler()
        {
            if (_bonusHandler != null)
                _bonusHandler.enabled = true;
        }

        private void DisableBonusHandler()
        {
            if (_bonusHandler != null)
                _bonusHandler.enabled = false;
        }
    }
}