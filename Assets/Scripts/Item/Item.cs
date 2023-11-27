using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour
{
    public ItemType Type { get; protected set; }
    public Sprite Sprite { get; private set; }
    public int Level { get; private set; } = 1;
    public int Bonus { get; private set; } = 1;
    public bool CanBeUpgraded { get; private set; }

    private void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>().sprite;
    }
}

public enum ItemType
{
    Common,
    Teleport,
    Acceleration,
    BallGenerator
}