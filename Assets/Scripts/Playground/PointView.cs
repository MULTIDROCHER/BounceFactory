using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointView : MonoBehaviour
{
    private ItemSpawner _spawner;
    private List<SpawnPoint> _points = new List<SpawnPoint>();
    private List<Item> _items = new List<Item>();

    private void Awake()
    {
        _spawner = FindObjectOfType<ItemSpawner>();
        _points.AddRange(FindObjectsOfType<SpawnPoint>().ToList());
    }

    private void OnEnable()
    {
        _spawner.ItemSpawned += OnItemSpawned;
    }

    private void OnDisable()
    {
        _spawner.ItemSpawned -= OnItemSpawned;
    }

    private void OnItemSpawned(Item item)
    {
        _items.Add(item);
    }

    public void ShowPoints()
    {
        foreach (var point in _points)
            point.ShowPoint();
    }

    public void HidePoints()
    {
        foreach (var point in _points)
            point.HidePoint();
    }
}