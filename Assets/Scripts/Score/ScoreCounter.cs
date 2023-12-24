using System;
using TMPro;
using UnityEngine;
using YG;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    private TMP_Text _scoreText;
    private string _text;
    private int _globalScore;

    public event Action<int> ScoreAdded;

    public int Balance { get; private set; }
    public int GlobalScore => _globalScore;

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

        _scoreText = GetComponent<TMP_Text>();
        _text = _scoreText.text;

        Balance = SetBalance();
        UpdateDisplay();
    }

    public void AddScore(int amount)
    {
        Balance += amount;
        _globalScore += amount;
        ScoreAdded?.Invoke(amount);

        TrySaveHighScore();
        UpdateDisplay();
    }

    public void Buy(int price)
    {
        if (Balance >= price)
        {
            Balance -= price;
            UpdateDisplay();
        }
    }

    private void UpdateDisplay() => _scoreText.text = _text + Balance;

    public void TestChit()
    {
        AddScore(LevelManager.Instance.LevelGoal / 10);
    }

    private int SetBalance()
    {
        if (YandexGame.savesData.Balance == 0)
            return 100;
        else
            return YandexGame.savesData.Balance;
    }

    private void TrySaveHighScore()
    {
        YandexGame.NewLeaderboardScores("LeaderBoardScore", GlobalScore);
        Debug.Log("score upd");
    }
}