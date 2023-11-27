using System.Collections.Generic;
using UnityEngine;

public class CommonItem : Item
{
    [SerializeField] private List<Sprite> _sprites;

    private void Awake()
    {
        Type = ItemType.Common;
        GetComponent<SpriteRenderer>().sprite = _sprites[Random.Range(0, _sprites.Count)];
    }
}