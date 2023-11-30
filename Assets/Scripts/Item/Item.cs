using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ItemMovement))]
[RequireComponent(typeof(ItemClickHandler))]
[RequireComponent(typeof(PointHandler))]
public class Item : MonoBehaviour
{
    [SerializeField] private ItemType _type;
    [SerializeField] private bool _canBeUpgraded;
    [SerializeField] private LevelDisplay _display;

    public ItemType Type => _type;
    public bool CanBeUpgraded => _canBeUpgraded;
    public Sprite Sprite { get; private set; }
    public int Level { get; private set; } = 1;
    public int Bonus { get; private set; } = 1;

    private void Start()
    {
        Sprite = GetComponent<SpriteRenderer>().sprite;
        Instantiate(_display, transform);
    }
}