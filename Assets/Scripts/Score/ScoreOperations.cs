using System;
using UnityEngine;

namespace BounceFactory.Score
{
    public class ScoreOperations : ScoreManager
    {
        public event Action<int> ScoreAdded;

        public void AddScore(int amount)
        {
            Balance += amount;
            ScoreAdded?.Invoke(amount);
            UpdateDisplay();
        }

        public void Buy(int price)
        {
            if (Balance >= price)
            {
                Balance -= price;
                UpdateDisplay();
            }
        }

        public void ReturnSpent()
        {
            Balance += Spent;
            Spent = 0;
        }
    }
}