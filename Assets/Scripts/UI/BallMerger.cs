using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BallMerger : MonoBehaviour, ITutorialEvent
{
    [SerializeField] private Transform _container;
    [SerializeField] private ParticleSystem _poofEffect;
    [SerializeField] private BallSpawner _spawner;
    [SerializeField] private Button _button;

    public Button Button => _button;

    private ColorSetter _colorSetter;
    private int _requiredAmount = 3;
    private int _ballCount;

    public event Action Performed;

    private void Start()
    {
        _ballCount = _container.childCount;
        _colorSetter = GetComponent<ColorSetter>();
    }

    private void FixedUpdate()
    {
        if (_container.childCount != _ballCount)
        {
            _ballCount = _container.childCount;

            if (_ballCount >= _requiredAmount)
                TryFindMatches();
            else
                ButtonOff();
        }
    }

    private void TryFindMatches()
    {
        List<Ball> balls = _container.GetComponentsInChildren<Ball>().ToList();

        for (int level = balls.Max(ball => ball.Level); level > 0; level--)
        {
            List<Ball> matchingBalls = balls.FindAll(ball => ball.Level == level);

            if (matchingBalls.Count >= _requiredAmount)
            {
                ButtonOn(matchingBalls.Take(_requiredAmount).ToList());
                break;
            }
            else
            {
                ButtonOff();
            }
        }
    }

    private void Merge(List<Ball> balls)
    {
        ButtonOff();
        MoveToSpawner(balls);
        Performed?.Invoke();
    }

    private void MoveToSpawner(List<Ball> balls)
    {
        int completedTweens = 0;

        foreach (var ball in balls)
        {
            ball.GetComponent<Collider2D>().enabled = false;
            ball.transform.DOMove(_spawner.transform.position, 2)
                .OnComplete(() =>
                {
                    completedTweens++;

                    if (completedTweens == balls.Count)
                        UpgradeOneBall(balls);
                });
        }
    }

    private void UpgradeOneBall(List<Ball> balls)
    {
        var ball = balls[0];
        balls.Remove(ball);
        ball.LevelUp(_colorSetter.SetColor(ball));
        DoEffect();
        ball.GetComponent<Collider2D>().enabled = true;

        foreach (var lowLevel in balls.ToArray())
            Destroy(lowLevel.gameObject);
    }

    private void ButtonOn(List<Ball> balls)
    {
        _button.gameObject.SetActive(true);
        _button.onClick.AddListener(() => Merge(balls));
    }

    private void ButtonOff()
    {
        _button.gameObject.SetActive(false);
        //TryFindMatches();
    }

    private void DoEffect()
    {
        var poof = Instantiate(_poofEffect, _spawner.transform.position, Quaternion.identity);
        Destroy(poof.gameObject, _poofEffect.main.startLifetime.constant);
    }
}