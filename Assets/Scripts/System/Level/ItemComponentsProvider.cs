using System;
using System.Collections.Generic;
using System.Linq;
using BounceFactory.BaseObjects;
using BounceFactory.Logic.Selling;
using BounceFactory.Logic.Spawning;
using BounceFactory.Playground.Storage.Holder;

namespace BounceFactory.System.Level
{
    public static class ItemComponentsProvider
    {
        public static List<SpawnPoint> ActivePoints { get; private set; }

        public static Holder<Item> ItemHolder { get; private set; }
        
        public static ItemPriceChanger ItemPriceChanger { get; private set; }

        public static Spawner<Item> ItemSpawner { get; private set; }

        public static event Action LevelChanged;

        public static event Action LevelExit;

        public static void GetLevelComponents(ItemLevelData current)
        {
            ActivePoints = current.SpawnPoints.ToList();
            ItemHolder = current.ItemHolder;
            ItemPriceChanger = current.ItemPriceChanger;
            ItemSpawner = current.ItemSpawner;
            LevelChanged?.Invoke();
        }

        public static void Reset()
        {
            ActivePoints.Clear();
            LevelExit?.Invoke();
        }
    }
}