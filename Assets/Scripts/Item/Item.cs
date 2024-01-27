using UnityEngine;

[RequireComponent(typeof(ItemMovement))]
[RequireComponent(typeof(ItemClickHandler))]
[RequireComponent(typeof(PointHandler))]
public class Item : IUpgradable
{
    [SerializeField] private ItemType _type;

    public ItemType Type => _type;

    protected override void Awake() {
        base.Awake();
        BonusIncrease = 3;
        ObjectsAmount = 2;
    }
}