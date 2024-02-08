using System;
using System.Collections.Generic;
using System.Linq;
using BounceFactory.BaseObjects;
using BounceFactory.Logic.Selling;
using BounceFactory.Logic.Spawning;
using BounceFactory.Playground.DeadZones;
using BounceFactory.Playground.Storage.Holder;

namespace BounceFactory.System.Level
{
    public static class BallComponentsProvider
    {
        public static List<DeadZone> DeadZones { get; private set; }

        public static Holder<Ball> BallHolder { get; private set; }

        public static BallPriceChanger BallPriceChanger { get; private set; }

        public static Spawner<Ball> BallSpawner { get; private set; }

        public static event Action LevelChanged;

        public static event Action LevelExit;

        public static void GetLevelComponents(BallLevelData current)
        {
            DeadZones = current.DeadZones.ToList();
            BallHolder = current.BallHolder;
            BallPriceChanger = current.BallPriceChanger;
            BallSpawner = current.BallSpawner;
            LevelChanged?.Invoke();
        }

        public static void Reset()
        {
            DeadZones.Clear();
            LevelExit?.Invoke();
        }
    }
}