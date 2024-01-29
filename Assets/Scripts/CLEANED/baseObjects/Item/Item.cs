using UnityEngine;

[RequireComponent(typeof(ItemMovement))]
[RequireComponent(typeof(ItemClickHandler))]
[RequireComponent(typeof(PointHandler))]
[RequireComponent(typeof(UpgradeHandler))]
public class Item : UpgradableObject
{
    [SerializeField] private ItemType _type;

    private UpgradeHandler _upgradeHandler;

    protected ItemMovement Movement;
    protected ItemClickHandler ClickHandler;
    protected PointHandler PointHandler;

    public ItemType Type => _type;
    public LevelDisplay LevelDisplay => _upgradeHandler.LevelDisplay;

    protected override void Awake() {
        base.Awake();
        BonusIncrease = 3;
        ObjectsAmount = 2;

        Movement = GetComponent<ItemMovement>();
        ClickHandler = GetComponent<ItemClickHandler>();
        PointHandler = GetComponent<PointHandler>();
        _upgradeHandler = GetComponent<UpgradeHandler>();
    }
}