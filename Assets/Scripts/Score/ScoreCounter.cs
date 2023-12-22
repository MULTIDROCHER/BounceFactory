using System;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    private TMP_Text _scoreText;
    private int _globalScore;

    public event Action<int> ScoreAdded;

    public int Score { get; private set; }
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

        Score = SetPrice();
        UpdateDisplay();
    }

    public void AddScore(int amount)
    {
        Score += amount;
        _globalScore += amount;
        ScoreAdded?.Invoke(amount);

        UpdateDisplay();
    }

    public void Buy(int price)
    {
        if (Score >= price)
        {
            Score -= price;
            UpdateDisplay();
        }
    }

    private void UpdateDisplay() => _scoreText.text = "score: " + Score;

    public void TestChit()
    {
        AddScore(LevelManager.Instance.LevelGoal / 10);
    }

    private int SetPrice()
    {
        if (Progress.Instance.PlayerInfo.Balance == 0)
            return 100;
        else
            return Progress.Instance.PlayerInfo.Balance;
    }
}