using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BonusHandler))]
public class CommonItem : Item
{
    [SerializeField] private List<Sprite> _sprites;

    private void Start()
    {
        if (Renderer.sprite == null)
            Renderer.sprite = _sprites[Random.Range(0, _sprites.Count)];
        
        _type = ItemType.Common;
    }
}