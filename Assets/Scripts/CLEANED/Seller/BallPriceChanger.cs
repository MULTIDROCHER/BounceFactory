using System;

public class BallPriceChanger : PriceChanger<Ball>, ITutorialEvent
{
    private readonly int _startPrice = 50;
    private readonly float _priceIncrease = 1.5f;

    private DeadZone[] _ballDestroyer;

    public event Action Performed;

    private void Awake() => _ballDestroyer = FindObjectsOfType<DeadZone>();

    protected override void OnEnable()
    {
        base.OnEnable();
        
        foreach (var destroyer in _ballDestroyer)
        {
            destroyer.BallDestroyed += OnBallDestroyed;
            destroyer.BallsOver += OnBallsOver;
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        foreach (var destroyer in _ballDestroyer)
        {
            destroyer.BallDestroyed -= OnBallDestroyed;
            destroyer.BallsOver -= OnBallsOver;
        }
    }

    protected override void SetPrices()
    {
        Performed?.Invoke();
        Price = _startPrice;
        PriceIncrease = _priceIncrease;
    }

    private void OnBallDestroyed() => ReducePrices();

    private void OnBallsOver()
    {
        Price = 0;
        PurchasesCount = 0;
        OnBought();
    }
}