using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<Item> _items;

    private SpawnPoint[] _spawnPoints;
    private ItemContainer _container;
    private ItemSeller _seller;

    private readonly int _accelerationChance = 10;
    private readonly int _ballgeneratorChance = 30;

    public event Action<Item> ItemSpawned;
    public event Action ItemBought;

    private void Start()
    {
        GetPoints();
        _container = FindObjectOfType<ItemContainer>();
        _seller = FindObjectOfType<ItemSeller>();
    }

    public void Spawn()
    {
        var point = GetPoint();

        if (point != null)
        {
            var itemToSpawn = GetRandomItem();

            if (itemToSpawn != null)
            {
                var spawned = Instantiate(itemToSpawn, point.transform.position, Quaternion.identity, _container.transform);
                ScoreCounter.Instance.Buy(_seller.Price);
                ItemSpawned?.Invoke(spawned);
                ItemBought?.Invoke();
            }
        }
    }

    private Item GetRandomItem()
    {
        int chance = UnityEngine.Random.Range(1, 101);

        if (chance <= _accelerationChance)
            return GetItemByComponent<AccelerationItem>();
        else if (chance <= TeleportChance())
            return GetItemByComponent<TeleportItem>();
        else if (chance <= _ballgeneratorChance && _container.transform.childCount >= 2)
            return GetItemByComponent<BallGeneratorItem>();
        else
            return GetItemByComponent<CommonItem>();
    }

    private SpawnPoint GetPoint()
    {
        SpawnPoint[] emptyPoints = _spawnPoints.Where(point => point.IsEmpty).ToArray();

        if (emptyPoints.Length != 0)
            return emptyPoints[UnityEngine.Random.Range(0, emptyPoints.Length)];
        else
            return null;
    }

    private int TeleportChance()
    {
        int possibleAmount = 2;
        TeleportItem[] portals = FindObjectsOfType<TeleportItem>();

        if (portals.Length < possibleAmount && _container.transform.childCount >= possibleAmount)
            return 20;
        else
            return 0;
    }

    private Item GetItemByComponent<T>() where T : Component => _items.Find(item => item.TryGetComponent(out T component));

    public void GetPoints(SpawnPoint[] points = null)
    {
        if (points == null)
            _spawnPoints =  FindObjectsOfType<SpawnPoint>();
        else
            _spawnPoints =  points;
    }
}