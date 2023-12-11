using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ItemMovement))]
[RequireComponent(typeof(ItemClickHandler))]
[RequireComponent(typeof(PointHandler))]
public class Item : MonoBehaviour
{
    [SerializeField] protected ItemType _type;

    public ItemType Type => _type;
    public SpriteRenderer Renderer { get; private set; }
    public Collider2D Collider { get; private set; }
    public int Level { get; private set; } = 1;
    public int Bonus { get; private set; } = 1;
    public bool CanBeUpgraded => GetComponent<UpgradeHandler>() != null;

    private void Awake()
    {
        Renderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();
    }

    public virtual void LevelUp()
    {
        Level++;
        Bonus += 2;

        gameObject.name = Level.ToString();
    }
}