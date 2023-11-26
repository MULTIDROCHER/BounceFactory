using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Transform _container;

    private int _accelerationChance = 60;
    private int _ballgeneratorChance = 50;
    private int _teleportChance = 5;

    public void Spawn()
    {
        var point = GetPoint();

        if (point != null)
        {
            var itemToSpawn = GetRandomItem();
            Debug.Log(itemToSpawn.name);

            if (itemToSpawn != null)
                Instantiate(itemToSpawn, point.transform.position, Quaternion.identity, _container);
        }
        else
            Debug.Log("something wrong");
    }

    private Item GetRandomItem()
    {
        int chance = Random.Range(1, 101);
        Debug.Log(chance);

        if (chance <= _ballgeneratorChance)
        {
            Debug.Log("generator");
            return GetBallGeneratorItem();
        }
        else if (chance <= _accelerationChance)
        {
            Debug.Log("acceleration");
            return GetAccelerationItem();
        }
        else
            return GetCommonItem();
    }

    private SpawnPoint GetPoint()
    {
        SpawnPoint[] emptyPoints = _spawnPoints.Where(point => point.IsEmpty).ToArray();

        if (emptyPoints.Length != 0)
            return emptyPoints[Random.Range(0, emptyPoints.Length)];
        else
            return null;
    }

    private Item GetCommonItem() => _items.Find(item => item.Type == ItemType.Common);

    private Item GetAccelerationItem() => _items.Find(item => item.Type == ItemType.Acceleration);

    private Item GetBallGeneratorItem() => _items.Find(item => item.Type == ItemType.BallGenerator);

    private Item GetTeleportItem() => _items.Find(item => item.Type == ItemType.Teleport);
}