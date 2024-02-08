using BounceFactory.Logic.Selling;
using BounceFactory.Logic.Spawning;
using BounceFactory.Playground.DeadZones;
using BounceFactory.Playground.Storage.Holder;
using UnityEngine;

namespace BounceFactory.System.Level
{
    public class BallLevelData : MonoBehaviour
    {
        [SerializeField] private DeadZone[] _deadZones;
        [SerializeField] private BallHolder _ballHolder;
        [SerializeField] private BallPriceChanger _ballSeller;
        [SerializeField] private BallSpawner _ballSpawner;
        
        public DeadZone[] DeadZones => _deadZones;

        public BallHolder BallHolder => _ballHolder;

        public BallPriceChanger BallPriceChanger => _ballSeller;

        public BallSpawner BallSpawner => _ballSpawner;
    }
}