using System;

public class BallSeller : Seller, ITutorialEvent
{
    private DeadZone _ballDestroyer;
    private BallSpawner _spawner;

    public event Action Performed;

    private void Awake()
    {
        _ballDestroyer = FindObjectOfType<DeadZone>();
        _spawner = FindObjectOfType<BallSpawner>();
    }

    private void OnEnable()
    {
        _spawner.BallBought += OnBought;
        _ballDestroyer.BallDestroyed += OnBallDestroyed;
        _ballDestroyer.BallsOver += OnBallsOver;
    }

    private void OnDisable()
    {
        _spawner.BallBought -= OnBought;
        _ballDestroyer.BallDestroyed -= OnBallDestroyed;
        _ballDestroyer.BallsOver -= OnBallsOver;
    }

    private void OnBallDestroyed() => ReducePrices();

    private void OnBallsOver()
    {
        Price = 0;
        _purchasesCount = 0;
        OnBought();
    }

    protected override void SetPrices()
    {
        Performed?.Invoke();
        Price = 50;
        PriceChange = 1.5f;
    }
}