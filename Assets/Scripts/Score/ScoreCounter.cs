using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    private TMP_Text _scoreText;

    public int Score { get; private set; } = 100;

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