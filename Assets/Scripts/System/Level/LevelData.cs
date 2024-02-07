using BounceFactory.Logic.Selling;
using BounceFactory.Logic.Spawning;
using BounceFactory.Playground.DeadZones;
using BounceFactory.Playground.Storage.Holder;
using UnityEngine;
using YG;

namespace BounceFactory.System.Level
{
    public class LevelData : MonoBehaviour
    {
        private readonly int _minmalBalance = 100;

        [SerializeField] private SpawnPoint[] _spawnPoints;
        [SerializeField] private DeadZone[] _deadZones;
        [SerializeField] private BallHolder _ballHolder;
        [SerializeField] private ItemHolder _itemHolder;
        [SerializeField] private BallPriceChanger _ballSeller;
        [SerializeField] private ItemPriceChanger _itemSeller;
        [SerializeField] private BallSpawner _ballSpawner;
        [SerializeField] private ItemSpawner _itemSpawner;

        public SpawnPoint[] SpawnPoints => _spawnPoints;
        
        public DeadZone[] DeadZones => _deadZones;

        public BallHolder BallHolder => _ballHolder;

        public ItemHolder ItemHolder => _itemHolder;

        public BallPriceChanger BallPriceChanger => _ballSeller;

        public ItemPriceChanger ItemPriceChanger => _itemSeller;

        public BallSpawner BallSpawner => _ballSpawner;

        public ItemSpawner ItemSpawner => _itemSpawner;

        private void Awake()
        {
            if (YandexGame.savesData.Balance < _minmalBalance)
                YandexGame.savesData.Balance = _minmalBalance;
        }
    }
}