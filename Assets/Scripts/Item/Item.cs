using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ItemMovement))]
[RequireComponent(typeof(ItemClickHandler))]
[RequireComponent(typeof(PointHandler))]
public class Item : MonoBehaviour
{
    [SerializeField] private readonly ItemType _type;
    [SerializeField] private readonly LevelDisplay _display;

    public ItemType Type => _type;
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