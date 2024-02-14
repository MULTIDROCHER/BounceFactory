using UnityEngine;
using YG;

namespace BounceFactory.Score
{
    [RequireComponent(typeof(ScoreDisplay))]
    [RequireComponent(typeof(ScoreOperations))]
    public class ScoreManager : MonoBehaviour
    {
        private readonly int _minimalBalance = 100;

        private ScoreDisplay _scoreDisplay;

        public int Balance { get; protected set; }

        public int Spent { get; protected set; }

        private void Awake()
        {
            _scoreDisplay = GetComponent<ScoreDisplay>();
            Balance = SetBalance();
        }

        protected void UpdateDisplay() => _scoreDisplay.UpdateDisplay(Balance);

        private int SetBalance()
        {
            if (YandexGame.savesData.Balance == 0)
                return _minimalBalance;
            else
                return YandexGame.savesData.Balance;
        }
    }
}