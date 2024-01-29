using UnityEngine;
using YG;

public class Level : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private BallHolder _ballHolder;
    [SerializeField] private ItemHolder _itemHolder;

    private readonly int _minmalBalance = 100;

    private ItemSpawner _itemSpawner;
    private BallSpawner _ballSpawner;
    private ItemPriceChanger _itemSeller;
    private BallPriceChanger _ballSeller;
    private BallMerger _merger;
    private SpawnPointsView _pointView;

    private void Awake()
    {
        _ballSpawner = FindFirstObjectByType<BallSpawner>();
        _itemSpawner = FindFirstObjectByType<ItemSpawner>();
        _ballSeller = FindFirstObjectByType<BallPriceChanger>();
        _merger = FindFirstObjectByType<BallMerger>();
        _itemSeller = FindFirstObjectByType<ItemPriceChanger>();
        _pointView = FindFirstObjectByType<SpawnPointsView>();

        if (YandexGame.savesData.Balance < _minmalBalance)
            YandexGame.savesData.Balance = _minmalBalance;

        for (int i = 0; i < _itemHolder.transform.childCount; i++)
            Destroy(_itemHolder.transform.GetChild(i).gameObject);
    }

    private void OnEnable()
    {
        _ballSpawner.SetHolder(_ballHolder);
        _itemSpawner.GetPoints(_spawnPoints);
        _pointView.GetActivePoints(_spawnPoints);
        _merger.SetContainer(_ballHolder);

        foreach (var deadZone in FindObjectsOfType<DeadZone>())
            deadZone.SetContainer(_ballHolder);
    }

    private void OnDisable()
    {
        _ballSeller.Reset();
        _itemSeller.Reset();
        _itemHolder.Reset();
    }
}