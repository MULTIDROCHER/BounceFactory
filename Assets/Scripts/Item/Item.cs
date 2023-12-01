using UnityEditor.SceneManagement;
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

        if (_canBeUpgraded)
            gameObject.AddComponent<UpgradeHandler>();
    }

    public void LevelUp(ItemType type, Sprite sprite)
    {
        Level++;
        Bonus += 2;
        Sprite = sprite;

        if (type != Type)
            ChangeType(type);

        gameObject.name = Level.ToString();
    }

    private void ChangeType(ItemType type)
    {
        var previousType = GetComponent<Item>();

        if (type == ItemType.Common)
            gameObject.AddComponent<CommonItem>();
        else if (type == ItemType.Acceleration)
            gameObject.AddComponent<AccelerationItem>();
        else if (type == ItemType.BallGenerator)
            gameObject.AddComponent<BallGeneratorItem>();

        Destroy(previousType);
    }
}