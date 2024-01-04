using System.Collections;
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

    public void Reset()
    {
        foreach (Item item in transform)
            if (item != null)
                Destroy(item.gameObject);
    }
}
