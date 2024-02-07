using System;
using BounceFactory.Score;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace BounceFactory.System.Level
{
    [RequireComponent(typeof(Slider))]
    public class ProgressBar : MonoBehaviour
    {
        private readonly float _duration = .2f;
        private readonly string _splitter = " / ";

        private TMP_Text _text;
        private Slider _slider;
        private int _goal;

        public event Action GoalReached;

        public int CurrentScore { get; private set; }

        private void Start()
        {
            _slider = GetComponent<Slider>();
            _text = GetComponentInChildren<TMP_Text>();

            ScoreCounter.Instance.ScoreAdded += UpdateProgressBar;
            CurrentScore = YandexGame.savesData.LevelScore;
            SetBar();
        }

        private void OnDestroy() => ScoreCounter.Instance.ScoreAdded -= UpdateProgressBar;

        public void UpdateProgressBar(int amount)
        {
            CurrentScore += amount;

            _slider.DOValue(CurrentScore, _duration);
            var updatedText = ToStringConverter.ConvertProgress(CurrentScore, _splitter, _goal);

            UpdateProgressText(updatedText);

            if (CurrentScore >= _goal)
                GoalReached?.Invoke();
        }

        public void Reset()
        {
            CurrentScore = 0;
            SetBar();
        }

        private void SetBar()
        {
            _goal = YandexGame.savesData.Goal;
            _slider.maxValue = _goal;
            UpdateProgressBar(0);
        }

        private void UpdateProgressText(string progress) => _text.text = progress;
    }
}