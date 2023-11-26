using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
private Sprite _sprite;
    
    private int _level = 1;
    private int _bonus = 1;
    private bool _canBeUpgraded;
    private ItemType _type;

    public int Level => _level;
    public int Bonus => _bonus;
    public bool CanBeUpgraded => _canBeUpgraded;
    public ItemType Type => _type;
}

public enum ItemType
{
    Standart,
    Teleport,
    Acceleration,
    BallGenerator
}