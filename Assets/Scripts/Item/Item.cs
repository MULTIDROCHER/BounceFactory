using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour
{
    protected ItemType _type;

    private Sprite _sprite;
    private int _level = 1;
    private int _bonus = 1;
    private bool _canBeUpgraded;

    public ItemType Type => _type;
    public Sprite Sprite => _sprite;
    public int Level => _level;
    public int Bonus => _bonus;
    public bool CanBeUpgraded => _canBeUpgraded;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>().sprite;
    }
}

public enum ItemType
{
    Common,
    Teleport,
    Acceleration,
    BallGenerator
}