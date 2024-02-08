using System.Collections;
using BounceFactory.BaseObjects.ItemComponents;
using BounceFactory.Display.ItemLevel;
using BounceFactory.Score;
using UnityEngine;

namespace BounceFactory.BaseObjects
{
    [RequireComponent(typeof(ItemMover))]
    [RequireComponent(typeof(ItemClickHandler))]
    [RequireComponent(typeof(PointHandler))]
    [RequireComponent(typeof(UpgradeHandler))]
    [RequireComponent(typeof(BonusAdder))]
    public class Item : UpgradableObject
    {
        private UpgradeHandler _upgradeHandler;

        protected ItemMover Movement;
        protected PointHandler PointHandler;
        protected IEnumerator DestroyingCoroutine;

        public ItemLevelDisplay LevelDisplay => _upgradeHandler.LevelDisplay;
        
        public ItemClickHandler ClickHandler { get; protected set; }

        public BonusAdder BonusAdder { get; protected set; }

        protected override void Awake()
        {
            base.Awake();
            BonusIncrease = 3;
            ObjectsAmount = 2;

            Movement = GetComponent<ItemMover>();
            ClickHandler = GetComponent<ItemClickHandler>();
            PointHandler = GetComponent<PointHandler>();
            _upgradeHandler = GetComponent<UpgradeHandler>();
            BonusAdder = GetComponent<BonusAdder>();
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