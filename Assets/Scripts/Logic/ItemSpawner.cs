using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<Item> _items;

    private SpawnPoint[] _spawnPoints;
    private ItemContainer _container;
    private ItemSeller _seller;

    private readonly int _accelerationChance = 10;
    private readonly int _teleportChance = 20;
    private readonly int _ballgeneratorChance = 30;
    private readonly int _itemsOnSceneForGeneratorSpawn = 2;

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

    public void GetPoints(SpawnPoint[] points = null)
    {
        if (points == null)
            _spawnPoints = FindObjectsOfType<SpawnPoint>();
        else
            _spawnPoints = points;
    }

    private Item GetRandomItem()
    {
        int minRange = 0;
        int maxRange = 101;

        int chance = UnityEngine.Random.Range(minRange, maxRange);

        return chance switch
        {
            int n when n <= _accelerationChance => GetItemByComponent<AccelerationItem>(),
            int n when n <= GetTeleportChance() => GetItemByComponent<TeleportItem>(),
            int n when n <= _ballgeneratorChance && _container.transform.childCount >= _itemsOnSceneForGeneratorSpawn 
                => GetItemByComponent<BallGeneratorItem>(),
            _ => GetItemByComponent<CommonItem>(),
        };
    }

    private SpawnPoint GetPoint()
    {
        SpawnPoint[] emptyPoints = _spawnPoints.Where(point => point.IsEmpty).ToArray();

        if (emptyPoints.Length != 0)
            return emptyPoints[UnityEngine.Random.Range(0, emptyPoints.Length)];
        else
            return null;
    }

    private int GetTeleportChance()
    {
        int possibleAmount = 2;
        TeleportItem[] portals = FindObjectsOfType<TeleportItem>();

        if (portals.Length < possibleAmount && _container.transform.childCount >= possibleAmount)
            return _teleportChance;
        else
            return 0;
    }

    private Item GetItemByComponent<T>() where T : Component => _items.Find(item => item.TryGetComponent(out T component));
}