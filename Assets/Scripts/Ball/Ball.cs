using UnityEngine;

public class Ball : MonoBehaviour
{
    public Sprite Sprite { get; private set; }
    public int Level { get; private set; } = 1;
    public int Bonus { get; private set; } = 1;
}