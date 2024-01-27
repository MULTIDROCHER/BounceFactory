using System;

public class BallSeller : Seller, ITutorialEvent
{
    private readonly int _startPrice = 50;
    private readonly float _priceIncrease = 1.5f;

    private DeadZone[] _ballDestroyer;
    private BallSpawner _spawner;

    public event Action Performed;

    private void Awake()
    {
        _ballDestroyer = FindObjectsOfType<DeadZone>();
        _spawner = FindObjectOfType<BallSpawner>();
    }

    private void OnEnable()
    {
        _spawner.BallBought += OnBought;

        foreach (var destroyer in _ballDestroyer)
        {
            destroyer.BallDestroyed += OnBallDestroyed;
            destroyer.BallsOver += OnBallsOver;
        }
    }

    private void OnDisable()
    {
        _spawner.BallBought -= OnBought;

        foreach (var destroyer in _ballDestroyer)
        {
            destroyer.BallDestroyed -= OnBallDestroyed;
            destroyer.BallsOver -= OnBallsOver;
        }
    }

    private void OnBallDestroyed() => ReducePrices();

    private void OnBallsOver()
    {
        Price = 0;
        PurchasesCount = 0;
        OnBought();
    }

    protected override void SetPrices()
    {
        Performed?.Invoke();
        Price = _startPrice;
        PriceIncrease = _priceIncrease;
    }
}