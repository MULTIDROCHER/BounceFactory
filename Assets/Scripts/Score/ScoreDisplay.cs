using BounceFactory.System;
using TMPro;
using UnityEngine;

namespace BounceFactory.Score
{
    [RequireComponent(typeof(TMP_Text))]
    [RequireComponent(typeof(ScoreCounter))]
    public class ScoreDisplay : MonoBehaviour
    {
        private readonly string _newLine = "\n";

        private TMP_Text _scoreText;
        private ScoreCounter _counter;
        private string _baseText;

        private void Start()
        {
            _scoreText = GetComponent<TMP_Text>();
            _counter = GetComponent<ScoreCounter>();

            _baseText = _scoreText.text + _newLine;
            UpdateDisplay(_counter.Balance);
        }

        public void UpdateDisplay(int newScore)
        {
            var score = ToStringConverter.GetTextWithNumber(_baseText, newScore);
            _scoreText.text = score;
        }
    }
}