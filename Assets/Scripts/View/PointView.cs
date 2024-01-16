using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointView : MonoBehaviour
{
    private ItemSpawner _spawner;
    private List<SpawnPoint> _points = new();
    private readonly List<Item> _items = new();

    private void Awake()
    {
        _spawner = FindObjectOfType<ItemSpawner>();
        GetPoints();
    }

    private void OnEnable() => _spawner.ItemSpawned += OnItemSpawned;

    private void OnDisable() => _spawner.ItemSpawned -= OnItemSpawned;

    private void OnItemSpawned(Item item) => _items.Add(item);

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

    public void GetPoints(SpawnPoint[] points = null)
    {
        _points.Clear();

        if (points == null)
            _points.AddRange(FindObjectsOfType<SpawnPoint>());
        else
            _points.AddRange(points);
    }
}