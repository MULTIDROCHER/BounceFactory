using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    private TMP_Text _text;
    private Slider _slider;
    private int _goal;
    private int _currentScore;
    private float _duration = .2f;

    public event Action GoalRiched;

    private void OnEnable() => StartCoroutine(DelayedSubscription());

    private void OnDisable() => ScoreCounter.Instance.ScoreAdded -= UpdateProgressBar;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _text = GetComponentInChildren<TMP_Text>();

        _goal = LevelManager.Instance.LevelGoal;
        _slider.maxValue = _goal;
        UpdateProgressText();
    }

    private void UpdateProgressBar(int amount)
    {
        _currentScore += amount;
        _slider.DOValue(_currentScore, _duration).OnUpdate(() => UpdateProgressText());

        if (_currentScore >= _goal)
            GoalRiched?.Invoke();
    }

    private void UpdateProgressText() => _text.text = _currentScore + " / " + _goal;

    private IEnumerator DelayedSubscription()
    {
        while (ScoreCounter.Instance == null)
            yield return null;

        ScoreCounter.Instance.ScoreAdded += UpdateProgressBar;
        StopAllCoroutines();
    }
}