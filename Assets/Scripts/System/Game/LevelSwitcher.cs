using System.Collections.Generic;
using BounceFactory.System.DataSending;
using BounceFactory.System.Level;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace BounceFactory.System.Game
{
    public class LevelSwitcher : MonoBehaviour
    {
        private readonly float _goalIncrease = 1.3f;

        [SerializeField] private List<LevelData> _levelTemplates;
        [SerializeField] private List<Sprite> _backgroundSprites;
        [SerializeField] private Image _background;
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private GameObject _finishWindow;
        [SerializeField] private LevelExitController _exitController;

        private LevelData _current;
        private ProgressSaver _progressSaver;
        private LevelPrepairer _prepairer;

        private void Start()
        {
            _progressSaver = new (_progressBar);
            _prepairer = new (_levelTemplates, _backgroundSprites);
            SetLevel();
        }

        private void OnEnable()
        {
            _progressBar.GoalReached += OnGoalReached;
            _exitController.LevelExited += SaveChanges;
        }

        private void OnDisable()
        {
            _progressBar.GoalReached -= OnGoalReached;
            _exitController.LevelExited -= SaveChanges;
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
            {
                BallComponentsProvider.Reset();
                ItemComponentsProvider.Reset();
            }

            _current = _prepairer.GetRandomLevel(_current);
            _background.sprite = _prepairer.GetRandomBackground();

            BallComponentsProvider.GetLevelComponents(_current.BallData);
            ItemComponentsProvider.GetLevelComponents(_current.ItemData);

            _current.gameObject.SetActive(true);
        }

        private void OnGoalReached()
        {
            YandexGame.savesData.Goal = (int)(YandexGame.savesData.Goal * _goalIncrease);
            YandexGame.savesData.Level++;

            SaveChanges();
            _finishWindow.SetActive(true);
        }

        private void SaveChanges()
        {
            _progressSaver.SaveProgress();
            MetricsSender.CreateMetrics();
        }
    }
}