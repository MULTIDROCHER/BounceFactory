using UnityEngine;

[RequireComponent(typeof(BounceHandler))]
public class Ball : MonoBehaviour
{
    private int _increaseBonus = 3;

    public SpriteRenderer Sprite { get; private set; }
    public int Level { get; private set; } = 1;
    public int Bonus { get; private set; } = 1;

    private void Start() => Sprite = GetComponent<SpriteRenderer>();

    public void LevelUp(Color spriteColor)
    {
        Level++;
        Sprite.color = spriteColor;
        Bonus += _increaseBonus;

        gameObject.name = Level.ToString();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}