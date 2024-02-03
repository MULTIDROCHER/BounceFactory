using BounceFactory.System.Level;
using BounceFactory.System.DataSending;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace BounceFactory.System.Game
{
    public class LevelSwitcher : MonoBehaviour
    {
        [SerializeField] private List<LevelData> _levelTemplates;
        [SerializeField] private List<Sprite> _backgroundSprites;
        [SerializeField] private Image _background;
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private GameObject _finishWindow;
        [SerializeField] private ExitController _exitController;

        private readonly float _goalIncrease = 1.3f;

        private LevelData _current;

        private void Start() => SetLevel();

        private void OnEnable()
        {
            _progressBar.GoalReached += OnGoalReached;
            _exitController.OnLevelExit += SaveChanges;
        }

        private void OnDisable()
        {
            _progressBar.GoalReached -= OnGoalReached;
            _exitController.OnLevelExit -= SaveChanges;
        }

        public void ChangeLevel()
        {
            SetLevel();


            _progressBar.Reset();
            Time.timeScale = 1;
            SaveChanges();
        }

        private void SetLevel()
        {
            if (_current != null)
                ActiveComponentsProvider.Reset();

            SetRandomLevelTemplate();
            SetRandomBackground();

            ActiveComponentsProvider.GetLevelComponents(_current);
            _current.gameObject.SetActive(true);
        }

        private void SetRandomLevelTemplate()
        {
            LevelData tempLevel = _current;

            foreach (var level in _levelTemplates)
            {
                if (level != null)
                    level.gameObject.SetActive(false);
                else
                    Debug.Log(level.name);
            }

            while (_current == tempLevel || _current == null)
                _current = _levelTemplates[Random.Range(0, _levelTemplates.Count)];
        }

        private void SetRandomBackground() => _background.sprite = _backgroundSprites[Random.Range(0, _backgroundSprites.Count)];

        private void OnGoalReached()
        {
            YandexGame.savesData.Goal = (int)(YandexGame.savesData.Goal * _goalIncrease);
            YandexGame.savesData.Level++;

            SaveChanges();
            _finishWindow.SetActive(true);
        }

        private void SaveChanges()
        {
            SavesController.SaveProgres(_progressBar);
            MetricsSender.CreateMetrics();
        }
    }
}
