using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace BounceFactory
{public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private List<Level> _levelTemplates;
    [SerializeField] private List<Sprite> _backgroundSprites;
    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private Image _background;

    private readonly float _goalIncrease = 1.3f;

    private Level _current;

    private ProgressBar _progressBar => GameManager.Instance.ProgressBar;

    private void Start() => SetLevel();

    private void OnEnable()
    {
        _progressBar.GoalReached += OnGoalReached;
        GameManager.Instance.OnLevelExit += SaveChanges;
    }

    private void OnDisable()
    {
        _progressBar.GoalReached -= OnGoalReached;
        GameManager.Instance.OnLevelExit -= SaveChanges;
    }

    public void ChangeLevel()
    {
        SetLevel();

        YandexGame.savesData.Goal = (int)(YandexGame.savesData.Goal * _goalIncrease);
        YandexGame.savesData.Level++;

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

        _current.gameObject.SetActive(true);
        ActiveComponentsProvider.GetLevelComponents(_current);
    }

    private void SetRandomLevelTemplate()
    {
        Level tempLevel = _current;

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
        SaveChanges();
        _finishWindow.SetActive(true);
    }

    private void SaveChanges()
    {
        SavesController.SaveProgres(_progressBar);
        MetricsSender.CreateMetrics();
    }
}}
