using UnityEngine;

[RequireComponent(typeof(BounceController))]
public class Ball : MonoBehaviour
{
    public SpriteRenderer Sprite { get; private set; }
    public int Level { get; private set; } = 1;
    public int Bonus { get; private set; } = 1;

    private void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    public void LevelUp(Color spriteColor)
    {
        Level++;
        Sprite.color = spriteColor;
        Bonus += 3;

        gameObject.name = Level.ToString();
    }
}