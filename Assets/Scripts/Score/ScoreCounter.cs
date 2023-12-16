using System;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    private TMP_Text _scoreText;
    private int _globalScore;

    public event Action<int> ScoreAdded;

    public int Score { get; private set; } = 100;
    public int GlobalScore => _globalScore;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);

        _scoreText = GetComponent<TMP_Text>();
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
}