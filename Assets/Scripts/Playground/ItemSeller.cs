public class ItemSeller : Seller
{
    private ItemSpawner _spawner;

    private void Awake() => _spawner = FindObjectOfType<ItemSpawner>();

    private void OnEnable() => _spawner.ItemBought += OnBought;

    private void OnDisable() => _spawner.ItemBought -= OnBought;

    protected override void SetPrices()
    {
        Price = 25;
        PriceChange = 1.7f;
    }
}