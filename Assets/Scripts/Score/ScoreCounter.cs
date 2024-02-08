using System;
using UnityEngine;
using YG;

namespace BounceFactory.Score
{
    [RequireComponent(typeof(ScoreDisplay))]
    public class ScoreCounter : MonoBehaviour
    {
        private readonly int _minimalBalance = 100;

        private ScoreDisplay _scoreDisplay;

        public event Action<int> ScoreAdded;

        public int Balance { get; private set; }
        
        public int Spent { get; private set; }

        private void Awake()
        {
            _scoreDisplay = GetComponent<ScoreDisplay>();
            Balance = SetBalance();
        }

        public void AddScore(int amount)
        {
            Balance += amount;
            ScoreAdded?.Invoke(amount);
            _scoreDisplay.UpdateDisplay(Balance);
        }

        public void Buy(int price)
        {
            if (Balance >= price)
            {
                Balance -= price;
                Spent += price;
                _scoreDisplay.UpdateDisplay(Balance);
            }
        }

        public void ReturnSpent()
        {
            Balance += Spent;
            Spent = 0;
        }

        private int SetBalance()
        {
            if (YandexGame.savesData.Balance == 0)
                return _minimalBalance;
            else
                return YandexGame.savesData.Balance;
        }
    }
}