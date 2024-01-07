using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    private readonly int _increaseBonus = 3;

    private SpriteRenderer _sprite;
    
    public int Level { get; private set; } = 1;
    public int Bonus { get; private set; } = 1;

    private void Start() => _sprite = GetComponent<SpriteRenderer>();

    public void LevelUp(Color spriteColor)
    {
        Level++;
        _sprite.color = spriteColor;
        Bonus += _increaseBonus;

        gameObject.name = Level.ToString();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}