using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BallMerger : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private ParticleSystem _poofEffect;
    [SerializeField] private BallSpawner _spawner;
    [SerializeField] private Button _button;

    private ColorSetter _colorSetter;
    private int _requiredAmount = 3;
    private int _ballCount;

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

            if (_ballCount < _requiredAmount)
                ButtonOff();
            else
                TryFindMatches();
        }
    }

    private void TryFindMatches()
    {
        List<Ball> balls = _container.GetComponentsInChildren<Ball>().ToList();
        int level = balls.Max(ball => ball.Level);

        while (level > 0)
        {
            List<Ball> matchingBalls = balls.FindAll(ball => ball.Level == level);

            if (matchingBalls.Count == _requiredAmount)
            {
                ButtonOn(matchingBalls.Take(3).ToList());
                break;
            }

            level--;
        }
    }

    private void Merge(List<Ball> balls)
    {
        MoveToSpawner(balls);
        ButtonOff();
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

    private void ButtonOff() => _button.gameObject.SetActive(false);

    private void DoEffect()
    {
        var poof = Instantiate(_poofEffect, _spawner.transform.position, Quaternion.identity);
        Destroy(poof.gameObject, _poofEffect.main.startLifetime.constant);
    }
}