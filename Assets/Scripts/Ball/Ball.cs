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

    public void LevelUp()
    {
        Level++;
        Sprite.color = RandomColor();
        Bonus += 3;

        gameObject.name = Level.ToString();
        Debug.Log("levelup");
    }

    private Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        return new Color(r, g, b);
    }
}