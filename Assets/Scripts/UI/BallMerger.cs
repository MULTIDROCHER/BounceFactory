using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BallMerger : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private BallSpawner _spawner;
    [SerializeField] private Button _button;

    private ColorSetter _colorSetter;
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
            TryFindMatches();
        }
    }

    private void TryFindMatches()
    {
        List<Ball> balls = _container.GetComponentsInChildren<Ball>().ToList();
        int level = balls.Max(ball => ball.Level);

        while (level > 0)
        {
            Ball[] matchingBalls = balls.FindAll(ball => ball.Level == level).ToArray();

            if (matchingBalls.Length == 3)
            {
                _button.interactable = true;
                _button.onClick.AddListener(() => Merge(matchingBalls.Take(3).ToList()));
                break;
            }

            level--;
        }
    }

    private void Merge(List<Ball> balls)
    {
        _button.onClick.RemoveAllListeners();
        _button.interactable = false;
        MoveToSpawner(balls);
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

        foreach (var lowLevel in balls.ToArray())
            Destroy(lowLevel.gameObject);

        ball.LevelUp(_colorSetter.SetColor(ball));
        ball.GetComponent<Collider2D>().enabled = true;
    }
}