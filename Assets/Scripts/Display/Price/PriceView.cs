using BounceFactory.BaseObjects;
using BounceFactory.Logic.Selling;
using BounceFactory.Score;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BounceFactory.Display.Price
{
    public class PriceView<T> : MonoBehaviour 
    where T : UpgradableObject
    {
        [SerializeField] private Button _button;
        [SerializeField] private PriceChanger<T> _priceChanger;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private ScoreCounter _scoreCounter;
        
        private int _price;

        public PriceChanger<T> PriceChanger => _priceChanger;

        private void OnEnable() => _priceChanger.PriceChanged += OnPriceChanged;

        private void OnDisable() => _priceChanger.PriceChanged -= OnPriceChanged;

        private void LateUpdate() => _button.interactable = _scoreCounter.Balance >= _price;

        private void OnPriceChanged(int price)
        {
            _price = price;
            _text.text = _price.ToString();
        }
    }
}