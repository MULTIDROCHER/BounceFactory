using BounceFactory.Display;
using BounceFactory.Display.ItemLevel;
using BounceFactory.Score;
using UnityEngine;

namespace BounceFactory.BaseObjects.ItemComponents
{
    [RequireComponent(typeof(Item))]
    [RequireComponent(typeof(ItemMover))]
    public class ItemClickHandler : MonoBehaviour
    {
        private ItemLevelView _levelView;
        private SpawnPointsView _pointView;
        private BonusAdder _bonusHandler;
        private ItemMover _itemMovement;

        public Item Item { get; private set; }

        private void Awake()
        {
            Item = GetComponent<Item>();
            _itemMovement = GetComponent<ItemMover>();
            _bonusHandler = Item.BonusAdder;
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
                OnClick();
            else if (Input.GetMouseButtonUp(0))
                OnDrop();
        }

        public void SetViews(ItemLevelView levelView, SpawnPointsView pointsView)
        {
            _levelView = levelView;
            _pointView = pointsView;
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