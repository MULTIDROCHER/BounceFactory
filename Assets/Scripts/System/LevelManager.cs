using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private List<Level> _levelTemplates;
    [SerializeField] private List<Sprite> _backgroundSprites;
    [SerializeField] private Image _background;

    private readonly float _goalIncrease = 1.3f;

    private ProgressBar _progressBar;
    private Level _current;

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

        _progressBar = FindObjectOfType<ProgressBar>();
        SetLevel();
    }

    private void OnEnable() => _progressBar.GoalRiched += OnGoalRiched;

    private void OnDisable()
    {
        YandexGame.Instance._SaveProgress();
        _progressBar.GoalRiched -= OnGoalRiched;
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
        foreach (var level in _levelTemplates)
            level.gameObject.SetActive(false);

        Level tempLevel = _current;

        while (_current == tempLevel)
            _current = _levelTemplates[Random.Range(0, _levelTemplates.Count)];

        _background.sprite = _backgroundSprites[Random.Range(0, _backgroundSprites.Count)];

        _current.gameObject.SetActive(true);
    }

    public void OnLevelExit()
    {
        YandexGame.savesData.LevelScore = _progressBar.CurrentScore;
        YandexGame.savesData.Balance = ScoreCounter.Instance.Balance;
        YandexGame.Instance._SaveProgress();
    }

    private void OnGoalRiched()
    {
        OnLevelExit();

        IDictionary<string, string> eventParams = new Dictionary<string, string>
    {
        { "Level", YandexGame.savesData.Level.ToString() },
        { "Balance", YandexGame.savesData.Balance.ToString() }
    };

        YandexMetrica.Send("levelCompleted", eventParams);
        _finishWindow.SetActive(true);
    }
}