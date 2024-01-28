using UnityEngine;

[RequireComponent(typeof(ItemMovement))]
[RequireComponent(typeof(ItemClickHandler))]
[RequireComponent(typeof(PointHandler))]
public class Item : UpgradableObject
{
    [SerializeField] private ItemType _type;

    protected ItemMovement Movement;
    protected ItemClickHandler ClickHandler;
    protected PointHandler PointHandler;

    public ItemType Type => _type;

    protected override void Awake() {
        base.Awake();
        BonusIncrease = 3;
        ObjectsAmount = 2;

        Movement = GetComponent<ItemMovement>();
        ClickHandler = GetComponent<ItemClickHandler>();
        PointHandler = GetComponent<PointHandler>();
    }
}