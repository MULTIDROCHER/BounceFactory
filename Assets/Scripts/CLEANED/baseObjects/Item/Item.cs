using System.Collections;
using UnityEngine;

namespace BounceFactory
{
    [RequireComponent(typeof(ItemMover))]
    [RequireComponent(typeof(ItemClickHandler))]
    [RequireComponent(typeof(PointHandler))]
    [RequireComponent(typeof(UpgradeHandler))]
    public class Item : UpgradableObject
    {
        [SerializeField] private ItemType _type;

        private UpgradeHandler _upgradeHandler;

        protected ItemMover Movement;
        protected ItemClickHandler ClickHandler;
        protected PointHandler PointHandler;
        protected IEnumerator Destroying;

        public ItemType Type => _type;
        public LevelDisplay LevelDisplay => _upgradeHandler.LevelDisplay;

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
            if (Destroying != null)
                StartCoroutine(Destroying);
            else
                Destroy(gameObject);
        }
    }
}