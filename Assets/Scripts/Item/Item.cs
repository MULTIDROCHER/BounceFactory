using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ItemMovement))]
[RequireComponent(typeof(ItemClickHandler))]
[RequireComponent(typeof(PointHandler))]
public class Item : MonoBehaviour
{
    [SerializeField] private ItemType _type;
    [SerializeField] private LevelDisplay _display;
    public ItemType Type {get => _type; protected set => _ = _type;}
    public Sprite Sprite { get; private set; }
    public int Level { get; private set; } = 1;
    public int Bonus { get; private set; } = 1;
    public bool CanBeUpgraded { get; private set; }

    private void Start()
    {
        Sprite = GetComponent<SpriteRenderer>().sprite;
        Instantiate(_display, transform);
    }
}

public enum ItemType
{
    Common,
    Teleport,
    Acceleration,
    BallGenerator
}