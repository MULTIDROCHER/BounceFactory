using System.Collections.Generic;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    private readonly List<LevelDisplay> _itemsLevel = new();

    [SerializeField] private Transform _container;

    private int _childCount;

    private void Update()
    {
        if (_container.childCount != _childCount)
        {
            _childCount = _container.childCount;
            GetItems();
        }
    }

    public void ShowLevel()
    {
        GetItems();

        foreach (var level in _itemsLevel)
            level.ShowLevel();
    }

    public void HideLevel()
    {
        foreach (var level in _itemsLevel)
            level.HideLevel();
    }

    private void GetItems()
    {
        _itemsLevel.Clear();
        Item[] items = _container.GetComponentsInChildren<Item>();

        foreach (var item in items)
        {
            var display = item.GetComponentInChildren<LevelDisplay>();

            if (display != null)
                _itemsLevel.Add(display);
        }
    }
}