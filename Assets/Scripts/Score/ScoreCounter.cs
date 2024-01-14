using System;
using TMPro;
using UnityEngine;
using YG;

[RequireComponent(typeof(TMP_Text))]
public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    private TMP_Text _scoreText;
    private string _text;

    public event Action<int> ScoreAdded;

    public int Balance { get; private set; }
    public int Spent { get; private set; }

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
        _text = _scoreText.text + "\n";

        Balance = SetBalance();
        UpdateDisplay();
    }

    public void AddScore(int amount)
    {
        Balance += amount;
        ScoreAdded?.Invoke(amount);

        UpdateDisplay();
    }

    public void Buy(int price)
    {
        if (Balance >= price)
        {
            Balance -= price;
            Spent += price;
            UpdateDisplay();
        }
    }

    public void ReturnSpent()
    {
        Balance += Spent;
        Spent = 0;
    }

    private void UpdateDisplay() => _scoreText.text = _text + NumsFormater.FormatedNumber(Balance);

    public void TestChit() => AddScore(YandexGame.savesData.Goal / 10);

    private int SetBalance()
    {
        if (YandexGame.savesData.Balance == 0)
            return 100;
        else
            return YandexGame.savesData.Balance;
    }
}