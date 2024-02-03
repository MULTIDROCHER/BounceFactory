using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory.BaseObjects
{
    public class CommonItem : Item
    {
        [SerializeField] private List<Sprite> _sprites;

        protected override void Awake()
        {
            base.Awake();

            if (Renderer.sprite == null)
                Renderer.sprite = _sprites[Random.Range(0, _sprites.Count)];
        }
    }
}