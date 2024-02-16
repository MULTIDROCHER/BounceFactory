using System;
using System.Collections.Generic;
using System.Linq;
using BounceFactory.BaseObjects;
using BounceFactory.Display;
using BounceFactory.Display.ItemLevel;
using BounceFactory.ScoreSystem;
using UnityEngine;

namespace BounceFactory.Logic.Spawning
{
    public class ItemSpawner : Spawner<Item>
    {
        private readonly int _accelerationChance = 10;
        private readonly int _teleportChance = 20;
        private readonly int _ballgeneratorChance = 30;
        private readonly int _itemsOnSceneForGeneratorSpawn = 2;

        [SerializeField] private ItemLevelView _levelView;
        [SerializeField] private SpawnPointsView _pointView;

        private List<SpawnPoint> _spawnPoints = new ();

        public event Action<Item> ItemSpawned;

        public override event Action Bought;

        public override void Spawn()
        {
            if (_spawnPoints == null || _spawnPoints.Count == 0)
                OnLevelChanged();

            var point = GetPointToSpawn();

            if (point != null)
            {
                var itemToSpawn = GetRandomItem();

                if (itemToSpawn != null)
                {
                    var spawned = Instantiate(itemToSpawn, point.transform.position, Quaternion.identity, Holder.transform);
                    spawned.ClickHandler.SetViews(_levelView, _pointView);
                    spawned.SetScoreOperator(ScoreOperations);

                    ScoreOperations.Buy(PriceChanger.Price);
                    ItemSpawned?.Invoke(spawned);
                    Bought?.Invoke();
                }
            }
        }

        protected override void OnLevelChanged()
        {
            _spawnPoints.Clear();
            _spawnPoints = LevelSwitcher.CurrentLevel.ItemData.SpawnPoints;
        }

        private Item GetRandomItem()
        {
            int minRange = 0;
            int maxRange = 101;

            int chance = UnityEngine.Random.Range(minRange, maxRange);

            return chance switch
            {
                int n when n <= _accelerationChance => GetItemByComponent<AccelerationItem>(),
                int n when n <= GetTeleportChance() => GetItemByComponent<PortalItem>(),
                int n when n <= _ballgeneratorChance && Holder.transform.childCount >= _itemsOnSceneForGeneratorSpawn
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
            PortalItem[] portals = Holder.Contents.Where(item => item is PortalItem).OfType<PortalItem>().ToArray();

            if (portals.Length < possibleAmount && Holder.transform.childCount >= possibleAmount)
                return _teleportChance;
            else
                return 0;
        }

        private Item GetItemByComponent<T>()
        where T : Component
        {
            foreach (var item in Templates)
            {
                if (item.TryGetComponent(out T _))
                    return item;
            }

            return null;
        }
    }
}