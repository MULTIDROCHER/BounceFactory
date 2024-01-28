using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using BounceFactory;

public class ItemSpawner : Spawner<Item>
{
    private SpawnPoint[] _spawnPoints;

    private readonly int _accelerationChance = 10;
    private readonly int _teleportChance = 20;
    private readonly int _ballgeneratorChance = 30;
    private readonly int _itemsOnSceneForGeneratorSpawn = 2;

    public event Action<Item> ItemSpawned;
    public override event Action Bought;

    protected override void Start()
    {
        base.Start();
        GetPoints();
    }

    public override void Spawn()
    {
        var point = GetPointToSpawn();

        if (point != null)
        {
            var itemToSpawn = GetRandomItem();

            if (itemToSpawn != null)
            {
                var spawned = Instantiate(itemToSpawn, point.transform.position, Quaternion.identity, Container.transform);
                ScoreCounter.Instance.Buy(_seller.Price);
                ItemSpawned?.Invoke(spawned);
                Bought?.Invoke();
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
            int n when n <= _ballgeneratorChance && Container.transform.childCount >= _itemsOnSceneForGeneratorSpawn 
                => GetItemByComponent<BallGeneratorItem>(),
            _ => GetItemByComponent<CommonItem>(),
        };
    }

    private SpawnPoint GetPointToSpawn()
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

        if (portals.Length < possibleAmount && Container.transform.childCount >= possibleAmount)
            return _teleportChance;
        else
            return 0;
    }

    private Item GetItemByComponent<T>() where T : Component => Templates.Find(item => item.TryGetComponent(out T component));
}