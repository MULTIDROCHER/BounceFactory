using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Transform _container;

    private readonly int _accelerationChance = 15;
    private readonly int _ballgeneratorChance = 10;
    //private int _teleportChance = 20;

    public UnityAction<Item> ItemSpawned;

    public void Spawn()
    {
        var point = GetPoint();

        if (point != null)
        {
            var itemToSpawn = GetRandomItem();

            if (itemToSpawn != null)
            {
                var spawned = Instantiate(itemToSpawn, point.transform.position, Quaternion.identity, _container);
                ItemSpawned?.Invoke(spawned);
            }
        }
        else
            Debug.Log("something wrong");
    }

    private Item GetRandomItem()
    {
        int chance = Random.Range(1, 101);

        if (chance <= _ballgeneratorChance)
            return GetItemByComponent<BallGeneratorItem>();
        else if (chance <= _accelerationChance)
            return GetItemByComponent<AccelerationItem>();
        else if (chance <= TeleportChance())
            return GetItemByComponent<TeleportItem>();
        else
            return GetItemByComponent<CommonItem>();
    }

    private SpawnPoint GetPoint()
    {
        SpawnPoint[] emptyPoints = _spawnPoints.Where(point => point.IsEmpty).ToArray();

        if (emptyPoints.Length != 0)
            return emptyPoints[Random.Range(0, emptyPoints.Length)];
        else
            return null;
    }

    private int TeleportChance()
    {
        int possibleAmount = 2;
        TeleportItem[] portals = FindObjectsOfType<TeleportItem>();

        if (portals.Length < possibleAmount)
            return 20;
        else
            return 0;
    }

    private Item GetItemByComponent<T>() where T : Component => _items.Find(item => item.TryGetComponent(out T component));
}