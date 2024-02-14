using BounceFactory.System;
using TMPro;
using UnityEngine;

namespace BounceFactory.Score
{
    [RequireComponent(typeof(TMP_Text))]
    [RequireComponent(typeof(ScoreManager))]
    public class ScoreDisplay : MonoBehaviour
    {
        private readonly string _newLine = "\n";

        private TMP_Text _scoreText;
        private ScoreManager _counter;
        private string _baseText;

        private void Start()
        {
            _scoreText = GetComponent<TMP_Text>();
            _counter = GetComponent<ScoreManager>();

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