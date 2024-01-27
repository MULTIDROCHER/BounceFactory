public class ItemSeller : Seller
{
    private readonly int _startPrice = 25;
    private readonly float _priceIncrease = 1.7f;

    private ItemSpawner _spawner;

    private void Awake() => _spawner = FindObjectOfType<ItemSpawner>();

    private void OnEnable() => _spawner.ItemBought += OnBought;

    private void OnDisable() => _spawner.ItemBought -= OnBought;

    protected override void SetPrices()
    {
        Price = _startPrice;
        PriceIncrease = _priceIncrease;
    }
}