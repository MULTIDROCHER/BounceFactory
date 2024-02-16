using System;

namespace BounceFactory.ScoreSystem
{
    public class ScoreOperations : Score
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