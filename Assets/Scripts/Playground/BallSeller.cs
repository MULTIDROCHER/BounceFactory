public class BallSeller : Seller
{
    private DeadZone _ballDestroyer;
    private BallSpawner _spawner;

    private void Awake()
    {
        _ballDestroyer = FindObjectOfType<DeadZone>();
        _spawner = FindObjectOfType<BallSpawner>();
    }

    private void OnEnable()
    {
        _spawner.BallBought += OnBought;
        _ballDestroyer.BallDestroyed += OnBallDestroyed;
    }

    private void OnDisable()
    {
        _spawner.BallBought -= OnBought;
        _ballDestroyer.BallDestroyed -= OnBallDestroyed;
    }

    private void OnBallDestroyed() => ReducePrices();

    protected override void SetPrices()
    {
        Price = 50;
        PriceChange = 1.5f;
    }
}