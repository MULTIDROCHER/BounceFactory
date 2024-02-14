using System.Collections.Generic;
using BounceFactory.Logic.Selling;
using BounceFactory.Logic.Spawning;
using BounceFactory.Playground.Storage.Holder;
using UnityEngine;

namespace BounceFactory.System.Level
{
    public class ItemLevelData : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;

        [SerializeField] private ItemHolder _itemHolder;

        [SerializeField] private ItemPriceChanger _itemSeller;

        [SerializeField] private ItemSpawner _itemSpawner;

        public List<SpawnPoint> SpawnPoints => _spawnPoints;

        public ItemHolder ItemHolder => _itemHolder;

        public ItemPriceChanger ItemPriceChanger => _itemSeller;

        public ItemSpawner ItemSpawner => _itemSpawner;
    }
}