using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public List<Item> Items { get; private set; } = new();

    private int _childCount;

    private void Update()
    {
        if (transform.childCount != _childCount)
        {
            _childCount = transform.childCount;
            Items.Clear();
            Items.AddRange(transform.GetComponentsInChildren<Item>());
        }
    }

    private void OnDisable() => Reset();

    public void Reset()
    {
        foreach (var item in Items)
            if (item != null)
                Destroy(item.gameObject);
    }
}