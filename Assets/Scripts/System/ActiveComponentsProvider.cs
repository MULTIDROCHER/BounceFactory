using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BounceFactory
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

        public static void GetLevelComponents(Level current)
        {
            ActivePoints = current.SpawnPoints.ToList();
            DeadZones = current.DeadZones.ToList();
            BallHolder = current.BallHolder;
            ItemHolder = current.ItemHolder;
            BallPriceChanger = current.BallPriceChanger;
            ItemPriceChanger = current.ItemPriceChanger;
            BallSpawner = current.BallSpawner;
            ItemSpawner = current.ItemSpawner;

            Debug.Log("level changed");
            LevelChanged?.Invoke();
        }

        public static void Reset()
        {
            ActivePoints.Clear();
            DeadZones.Clear();

            BallPriceChanger.Reset();
            ItemPriceChanger.Reset();

            BallHolder.Reset();
            ItemHolder.Reset();
        }
    }
}