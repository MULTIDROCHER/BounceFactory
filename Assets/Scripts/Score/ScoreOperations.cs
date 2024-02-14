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

        private void Update() {
            if(Input.GetKeyDown(KeyCode.Space)){
                Debug.Log("dont forget to delete dont forget to delete dont forget to delete dont forget to delete dont forget to delete dont forget to delete dont forget to delete ");
                AddScore(500);
            }
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