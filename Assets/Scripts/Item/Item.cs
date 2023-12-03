using UnityEditor.SceneManagement;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ItemMovement))]
[RequireComponent(typeof(ItemClickHandler))]
[RequireComponent(typeof(PointHandler))]
public class Item : MonoBehaviour
{
    [SerializeField] protected ItemType _type;
    [SerializeField] protected bool _canBeUpgraded;
    [SerializeField] private LevelDisplay _display;

    public ItemType Type => _type;
    public bool CanBeUpgraded => _canBeUpgraded;
    public SpriteRenderer Sprite { get; private set; }
    public int Level { get; private set; } = 1;
    public int Bonus { get; private set; } = 1;

    private void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>();

        if (_canBeUpgraded)
        {
            Instantiate(_display, transform);
            gameObject.AddComponent<UpgradeHandler>();
        }
    }

    public virtual void LevelUp(ItemType type, Sprite sprite)
    {
        Level++;
        Bonus += 2;
        Sprite.sprite = sprite;

        gameObject.name = Level.ToString();

        if (type != Type)
        {
            ChangeType(type, out Item previousType);
            //SetupNewType(previousType);
            Destroy(previousType);
        }
    }

    private void ChangeType(ItemType type, out Item previousType)
    {
        previousType = GetComponent<Item>();
        Debug.Log($"prev type = {previousType}. new = {type}");

        if (type == ItemType.Common)
            gameObject.AddComponent<CommonItem>();
        else if (type == ItemType.Acceleration)
            gameObject.AddComponent<AccelerationItem>();
        else if (type == ItemType.BallGenerator)
            gameObject.AddComponent<BallGeneratorItem>();

    }

    private void SetupNewType(Item previousType)
    {
        if (TryGetComponent(out Item item) != previousType)
        {
            item.Level = Level;
            item.Bonus = Bonus;
        }
        else
        {
            Debug.Log("error of type");
        }
    }
}