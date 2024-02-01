using System;
using TMPro;
using UnityEngine;
using YG;

namespace BounceFactory
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreCounter : MonoBehaviour
    {
        public static ScoreCounter Instance;

        private readonly int _minimalBalance = 100;

        private TMP_Text _scoreText;
        private string _baseText;

        public event Action<int> ScoreAdded;

        public int Balance { get; private set; }
        public int Spent { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            _scoreText = GetComponent<TMP_Text>();
            _baseText = _scoreText.text + "\n";

            Balance = SetBalance();
            UpdateDisplay(ScoreToString());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Pressed S");
                AddScore(500);
            }
        }

        public void AddScore(int amount)
        {
            Balance += amount;
            ScoreAdded?.Invoke(amount);

            UpdateDisplay(ScoreToString());
        }

        public void Buy(int price)
        {
            if (Balance >= price)
            {
                Balance -= price;
                Spent += price;
                UpdateDisplay(ScoreToString());
            }
        }

        public void ReturnSpent()
        {
            Balance += Spent;
            Spent = 0;
        }

        private string ScoreToString() => _baseText + NumsFormater.FormatedNumber(Balance);

        private void UpdateDisplay(string score) => _scoreText.text = score;

        private int SetBalance()
        {
            if (YandexGame.savesData.Balance == 0)
                return _minimalBalance;
            else
                return YandexGame.savesData.Balance;
        }
    }
}