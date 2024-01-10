using System;
using System.Collections;
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

    private void OnEnable() => StartCoroutine(DelayedSubscription());

    private void OnDisable() => ScoreCounter.Instance.ScoreAdded -= UpdateProgressBar;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _text = GetComponentInChildren<TMP_Text>();

        CurrentScore = YandexGame.savesData.LevelScore;
        SetBar();
    }

    public void UpdateProgressBar(int amount)
    {
        CurrentScore += amount;

        _slider.DOValue(CurrentScore, _duration);
        UpdateProgressText();

        if (CurrentScore >= _goal)
            GoalRiched?.Invoke();
    }

    private void UpdateProgressText() =>
    _text.text = NumsFormater.FormatedNumber(CurrentScore) + " / " + NumsFormater.FormatedNumber(_goal);

    private IEnumerator DelayedSubscription()
    {
        while (ScoreCounter.Instance == null)
            yield return null;

        ScoreCounter.Instance.ScoreAdded += UpdateProgressBar;
        StopAllCoroutines();
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
}