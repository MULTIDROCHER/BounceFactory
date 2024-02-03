using BounceFactory.BaseObjects;
using BounceFactory.Playground.Storage.Holder;
using System.Collections.Generic;
using UnityEngine;

namespace BounceFactory.Display.ItemLevel
{
    public class ItemLevelView : MonoBehaviour
    {
        private List<ItemLevelDisplay> _itemsLevel = new();

        [SerializeField] private Holder<Item> _holder;

        private void OnEnable() => _holder.ChildAdded += OnItemAdded;

        private void OnDisable() => _holder.ChildAdded -= OnItemAdded;

        public void ShowLevel()
        {
            foreach (var level in _itemsLevel)
                level.ShowLevel();
        }

        public void HideLevel()
        {
            foreach (var level in _itemsLevel)
                level.HideLevel();
        }

        private void OnItemAdded()
        {
            foreach (var item in _holder.Contents)
            {
                var display = item.LevelDisplay;

                if (display != null && _itemsLevel.Contains(display) == false)
                    _itemsLevel.Add(display);
            }
        }
    }
}