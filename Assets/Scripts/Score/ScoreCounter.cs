using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    private TMP_Text _scoreText;

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);

        _scoreText = GetComponent<TMP_Text>();
    }

    public void AddScore(int amount)
    {
        Score += amount;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _scoreText.text = "score: " + Score;
    }
}