using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsView : MonoBehaviour
{
    private readonly List<SpawnPoint> _points = new();
    private readonly List<Item> _items = new();

    private ItemSpawner _spawner;

    private void Awake()
    {
        _spawner = FindFirstObjectByType<ItemSpawner>();
    }

    private void OnEnable() => _spawner.ItemSpawned += OnItemSpawned;

    private void OnDisable() => _spawner.ItemSpawned -= OnItemSpawned;

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

    public void GetActivePoints(SpawnPoint[] points = null)
    {
        _points.Clear();

        if (points == null)
            _points.AddRange(FindObjectsOfType<SpawnPoint>());
        else
            _points.AddRange(points);
    }

    private void OnItemSpawned(Item item) => _items.Add(item);
}