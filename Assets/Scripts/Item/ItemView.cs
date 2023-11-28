using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    private List<LevelDisplay> _itemsLevel = new List<LevelDisplay>();

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
            _itemsLevel.Add(item.GetComponentInChildren<LevelDisplay>());
    }
}
