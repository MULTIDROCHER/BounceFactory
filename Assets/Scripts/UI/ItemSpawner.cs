using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Transform _container;
    [SerializeField] private ItemSeller _seller;

    private readonly int _accelerationChance = 10;
    private readonly int _ballgeneratorChance = 30;

    public UnityAction<Item> ItemSpawned;
    public UnityAction ItemBought;

    public void Spawn()
    {
        var point = GetPoint();

        if (point != null)
        {
            var itemToSpawn = GetRandomItem();

            if (itemToSpawn != null)
            {
                var spawned = Instantiate(itemToSpawn, point.transform.position, Quaternion.identity, _container);
                ScoreCounter.Instance.Buy(_seller.Price);
                ItemSpawned?.Invoke(spawned);
                ItemBought?.Invoke();
            }
        }
    }

    private Item GetRandomItem()
    {
        int chance = Random.Range(1, 101);

        if (chance <= _accelerationChance)
            return GetItemByComponent<AccelerationItem>();
        else if (chance <= TeleportChance())
            return GetItemByComponent<TeleportItem>();
        else if (chance <= _ballgeneratorChance)
            return GetItemByComponent<BallGeneratorItem>();
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