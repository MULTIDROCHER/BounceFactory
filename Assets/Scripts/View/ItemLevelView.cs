using System.Collections.Generic;
using BounceFactory;
using UnityEngine;

public class ItemLevelView : MonoBehaviour
{
    private List<LevelDisplay> _itemsLevel = new();

    [SerializeField] private Holder<Item> _holder;

    private void OnEnable() => _holder.ChildAdded += () => GetLevelDisplays();

    private void OnDisable() => _holder.ChildAdded -= () => GetLevelDisplays();

    public void ShowLevel()
    {
        Debug.Log("ShowLevel from view");
        foreach (var level in _itemsLevel)
            level.ShowLevel();
    }

    public void HideLevel()
    {
        Debug.Log("hideLevel from view");
        foreach (var level in _itemsLevel)
            level.HideLevel();
    }

    private void GetLevelDisplays()
    {
        _itemsLevel.Clear();

        foreach (var item in _holder.Contents)
        {
            var display = item.LevelDisplay;

            if (display != null)
                _itemsLevel.Add(display);
        }
    }
}