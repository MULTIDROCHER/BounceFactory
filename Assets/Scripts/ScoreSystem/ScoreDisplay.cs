using BounceFactory.System;
using TMPro;
using UnityEngine;

namespace BounceFactory.ScoreSystem
{
    [RequireComponent(typeof(TMP_Text))]
    [RequireComponent(typeof(Score))]
    public class ScoreDisplay : MonoBehaviour
    {
        private readonly string _newLine = "\n";

        private TMP_Text _scoreText;
        private Score _score;
        private string _baseText;

        private void Start()
        {
            _scoreText = GetComponent<TMP_Text>();
            _score = GetComponent<Score>();

            _baseText = _scoreText.text + _newLine;
            UpdateDisplay(_score.Balance);
        }

        public void UpdateDisplay(int newScore)
        {
            var score = ToStringConverter.GetTextWithNumber(_baseText, newScore);
            _scoreText.text = score;
        }
    }
}