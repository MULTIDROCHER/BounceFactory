using TMPro;
using UnityEngine;
using UnityEngine.UI;
using BounceFactory;

public abstract class PriceView<T> : MonoBehaviour where T : UpgradableObject
{
    [SerializeField] private Button _button;
    [SerializeField] private Seller<T> _seller;
    [SerializeField] private TMP_Text _text;
    private int _price;

    public Seller<T> Seller => _seller;

    private void OnEnable() => _seller.PriceChanged += OnPriceChanged;
    private void OnDisable() => _seller.PriceChanged -= OnPriceChanged;

    private void LateUpdate() => _button.interactable = ScoreCounter.Instance.Balance >= _price;

    private void OnPriceChanged(int price)
    {
        _price = price;
        _text.text = _price.ToString();
    }
}
