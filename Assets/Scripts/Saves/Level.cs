using UnityEngine;
using YG;

public class Level : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private BallContainer _ballContainer;
    [SerializeField] private ItemContainer _itemContainer;

    private ItemSpawner _itemSpawner;
    private BallSpawner _ballSpawner;
    private ItemSeller _itemSeller;
    private BallSeller _ballSeller;
    private PointView _pointView;
    private int _minmalBalance;

    private void Awake()
    {
        _ballSpawner = FindObjectOfType<BallSpawner>();
        _itemSpawner = FindObjectOfType<ItemSpawner>();
        _ballSeller = FindObjectOfType<BallSeller>();
        _itemSeller = FindObjectOfType<ItemSeller>();
        _pointView = FindObjectOfType<PointView>();

        if (YandexGame.savesData.Balance < _minmalBalance)
            YandexGame.savesData.Balance = _minmalBalance;

        for (int i = 0; i < _itemContainer.transform.childCount; i++)
            Destroy(_itemContainer.transform.GetChild(i).gameObject);
    }

    private void OnEnable()
    {
        _ballSpawner.GetContainer(_ballContainer);
        _itemSpawner.GetPoints(_spawnPoints);
        _ballSeller.Reset();
        _itemSeller.Reset();
        _pointView.GetPoints(_spawnPoints);
    }
}