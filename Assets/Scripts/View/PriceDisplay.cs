using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PriceDisplay : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Seller _seller;
    [SerializeField] private TMP_Text _text;

    private int _price;

    private void OnEnable()
    {
        _seller.PriceChanged += OnPriceChanged;
    }

    private void OnDisable()
    {
        _seller.PriceChanged -= OnPriceChanged;
    }

    private void LateUpdate()
    {
        if (ScoreCounter.Instance.Score >= _price)
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    private void OnPriceChanged(int price)
    {
        _price = price;
        _text.text = _price.ToString();
    }
}
