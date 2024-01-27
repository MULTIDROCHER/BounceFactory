using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using YG;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    private readonly float _duration = .2f;

    private TMP_Text _text;
    private Slider _slider;
    private int _goal;

    public event Action GoalRiched;

    public int CurrentScore { get; private set; }

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _text = GetComponentInChildren<TMP_Text>();

        ScoreCounter.Instance.ScoreAdded += UpdateProgressBar;
        CurrentScore = YandexGame.savesData.LevelScore;
        SetBar();
    }

    private void OnDestroy() => ScoreCounter.Instance.ScoreAdded -= UpdateProgressBar;

    public void UpdateProgressBar(int amount)
    {
        CurrentScore += amount;

        _slider.DOValue(CurrentScore, _duration);
        UpdateProgressText(ProgressToString());

        if (CurrentScore >= _goal)
            GoalRiched?.Invoke();
    }

    public void Reset()
    {
        CurrentScore = 0;
        SetBar();
    }

    private void SetBar()
    {
        _goal = YandexGame.savesData.Goal;
        _slider.maxValue = _goal;
        UpdateProgressBar(0);
    }

    private string ProgressToString() => NumsFormater.FormatedNumber(CurrentScore) + " / " + NumsFormater.FormatedNumber(_goal);

    private void UpdateProgressText(string progress) => _text.text = progress;
}