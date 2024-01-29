using System.Collections.Generic;
using BounceFactory;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private List<Level> _levelTemplates;
    [SerializeField] private List<Sprite> _backgroundSprites;
    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private Image _background;

    private readonly float _goalIncrease = 1.3f;

    private Level _current;
    
    private ProgressBar _progressBar => GameManager.Instance.ProgressBar;

    private void Awake() => SetLevel();

    private void OnEnable()
    {
        _progressBar.GoalReached += OnGoalReached;
        GameManager.Instance.OnLevelExit += OnLevelExit;
    }

    private void OnDisable()
    {
        _progressBar.GoalReached -= OnGoalReached;
        GameManager.Instance.OnLevelExit -= OnLevelExit;
    }

    public void ChangeLevel()
    {
        SetLevel();

        YandexGame.savesData.Goal = (int)(YandexGame.savesData.Goal * _goalIncrease);
        YandexGame.savesData.Level++;

        _progressBar.Reset();
        Time.timeScale = 1;
        OnLevelExit();
    }

    private void SetLevel()
    {
        SetRandomLevelTemplate();
        SetRandomBackground();
        _current.gameObject.SetActive(true);
    }

    private void SetRandomLevelTemplate()
    {
        Level tempLevel = _current;

        foreach (var level in _levelTemplates)
            level.gameObject.SetActive(false);

        while (_current == tempLevel)
            _current = _levelTemplates[Random.Range(0, _levelTemplates.Count)];
    }

    private void SetRandomBackground() => _background.sprite = _backgroundSprites[Random.Range(0, _backgroundSprites.Count)];

    private void OnGoalReached()
    {
        OnLevelExit();
        _finishWindow.SetActive(true);
    }

    private void OnLevelExit()
    {
        MetricsSender.CreateMetrics();
        SavesController.SaveProgres(_progressBar);
    }
}
