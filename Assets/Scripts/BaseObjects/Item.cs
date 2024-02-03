using BounceFactory.BaseObjects.ItemComponents;
using BounceFactory.Display.ItemLevel;
using System.Collections;
using UnityEngine;

namespace BounceFactory.BaseObjects
{
    [RequireComponent(typeof(ItemMover))]
    [RequireComponent(typeof(ItemClickHandler))]
    [RequireComponent(typeof(PointHandler))]
    [RequireComponent(typeof(UpgradeHandler))]
    public class Item : UpgradableObject
    {
        private UpgradeHandler _upgradeHandler;

        protected ItemMover Movement;
        protected ItemClickHandler ClickHandler;
        protected PointHandler PointHandler;
        protected IEnumerator DestroyingCoroutine;

        public ItemLevelDisplay LevelDisplay => _upgradeHandler.LevelDisplay;

        protected override void Awake()
        {
            base.Awake();
            BonusIncrease = 3;
            ObjectsAmount = 2;

            Movement = GetComponent<ItemMover>();
            ClickHandler = GetComponent<ItemClickHandler>();
            PointHandler = GetComponent<PointHandler>();
            _upgradeHandler = GetComponent<UpgradeHandler>();
        }

        public void Destroy()
        {
            if (DestroyingCoroutine != null)
                StartCoroutine(DestroyingCoroutine);
            else
                Destroy(gameObject);
        }
    }
}