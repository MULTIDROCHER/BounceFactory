using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BallMerger : MonoBehaviour
{
    [SerializeField] private readonly Transform _container;
    [SerializeField] private readonly BallSpawner _spawner;
    [SerializeField] private readonly Button _button;
    private int _ballCount;

    private void Start()
    {
        _ballCount = _container.childCount;
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

            if (matchingBalls.Length >= 3)
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
        UpgradeOneBall(balls);
        /* int count = 0;

        foreach (var ball in balls.ToArray())
        {
            ball.transform.DOMove(_spawner.transform.position, 2, false).OnComplete(() =>
            {
                count++;

                if (count == balls.Count)
                {
                    Debug.Log("count = " + count);
                    UpgradeOneBall(balls);
                }
            });
        } */
    }

    private void UpgradeOneBall(List<Ball> balls)
    {
        Debug.Log(" start lvlup");
        var ball = balls[0];
        balls.Remove(ball);
        Debug.Log(balls.Count);

        foreach (var lowLevel in balls.ToArray())
            Destroy(lowLevel.gameObject);

        ball.LevelUp();
    }
}