using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PriceDisplay : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Seller _seller;
    [SerializeField] private TMP_Text _text;

    private int _price;

    public Button Button => _button;
    public Seller Seller => _seller;

    private void OnEnable() => _seller.PriceChanged += OnPriceChanged;

    private void OnDisable() => _seller.PriceChanged -= OnPriceChanged;

    private void LateUpdate()
    {
        _button.interactable = ScoreCounter.Instance.Score >= _price;
    }

    private void OnPriceChanged(int price)
    {
        _price = price;
        _text.text = _price.ToString();
    }
}