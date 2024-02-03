using BounceFactory.BaseObjects;
using BounceFactory.Logic.Selling;
using BounceFactory.Logic.Spawning;
using BounceFactory.Playground.DeadZones;
using BounceFactory.Playground.Storage.Holder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BounceFactory.System.Level
{
    public static class ActiveComponentsProvider
    {
        public static List<SpawnPoint> ActivePoints { get; private set; }
        public static List<DeadZone> DeadZones { get; private set; }
        public static Holder<Ball> BallHolder { get; private set; }
        public static Holder<Item> ItemHolder { get; private set; }
        public static BallPriceChanger BallPriceChanger { get; private set; }
        public static ItemPriceChanger ItemPriceChanger { get; private set; }
        public static Spawner<Ball> BallSpawner { get; private set; }
        public static Spawner<Item> ItemSpawner { get; private set; }

        public static event Action LevelChanged;
        public static event Action LevelExit;

        public static void GetLevelComponents(LevelData current)
        {
            ActivePoints = current.SpawnPoints.ToList();
            DeadZones = current.DeadZones.ToList();
            BallHolder = current.BallHolder;
            ItemHolder = current.ItemHolder;
            BallPriceChanger = current.BallPriceChanger;
            ItemPriceChanger = current.ItemPriceChanger;
            BallSpawner = current.BallSpawner;
            ItemSpawner = current.ItemSpawner;

            LevelChanged?.Invoke();
        }

        public static void Reset()
        {
            ActivePoints.Clear();
            DeadZones.Clear();
            
            LevelExit?.Invoke();
        }
    }
}