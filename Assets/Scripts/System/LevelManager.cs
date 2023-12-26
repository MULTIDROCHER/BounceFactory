using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private List<Level> _templates;
    [SerializeField] private List<Sprite> _bgSprites;
    [SerializeField] private Image _background;

    private ProgressBar _progress;
    private Level _currentLevel;

    private float _goalIncrease = 1.3f;

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

        _progress = FindObjectOfType<ProgressBar>();
        _currentLevel = FindObjectOfType<Level>();
        YandexGame.Instance._LoadProgress();

        Debug.Log("level loaded -Lm" + YandexGame.savesData.Level + "-level;" + YandexGame.savesData.Goal + "-goal");
    }

    private void OnEnable()
    {
        YandexGame.Instance._LoadProgress();
        _progress.GoalRiched += OnGoalRiched;
    }

    private void OnDisable()
    {
        YandexGame.Instance._SaveProgress();
        _progress.GoalRiched -= OnGoalRiched;
    }

    private void OnGoalRiched()
    {
        YandexGame.Instance._SaveProgress();

        IDictionary<string, string> eventParams = new Dictionary<string, string>
    {
        { "Level", YandexGame.savesData.Level.ToString() },
        { "Balance", YandexGame.savesData.Balance.ToString() }
    };
    
        YandexMetrica.Send("levelCompleted", eventParams);
        _finishWindow.SetActive(true);
    }

    public void ChangeLevel()
    {
        _currentLevel.gameObject.SetActive(false);
        _currentLevel = _templates[UnityEngine.Random.Range(0, _templates.Count)];
        _currentLevel.gameObject.SetActive(true);
        _background.sprite = _bgSprites[UnityEngine.Random.Range(0, _bgSprites.Count)];

        YandexGame.savesData.Goal = Convert.ToInt32(YandexGame.savesData.Goal * _goalIncrease);
        YandexGame.savesData.Level++;

        _progress.Reset();
        Time.timeScale = 1;
        OnLevelExit();
    }

    public void OnLevelExit()
    {
        YandexGame.savesData.LevelScore = _progress.CurrentScore;
        YandexGame.savesData.Balance = ScoreCounter.Instance.Balance;
        YandexGame.Instance._SaveProgress();
    }
}
