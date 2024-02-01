using UnityEngine;
using YG;

namespace BounceFactory
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private SpawnPoint[] _spawnPoints;
        [SerializeField] private DeadZone[] _deadZones;
        [SerializeField] private BallHolder _ballHolder;
        [SerializeField] private ItemHolder _itemHolder;
        [SerializeField] private BallPriceChanger _ballSeller;
        [SerializeField] private ItemPriceChanger _itemSeller;
        [SerializeField] private BallSpawner _ballSpawner;
        [SerializeField] private ItemSpawner _itemSpawner;

        private readonly int _minmalBalance = 100;

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

            if (_itemHolder.transform.childCount != 0)
                _itemHolder.Reset();
        }
    }
}