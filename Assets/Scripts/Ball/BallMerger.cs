using System.Collections;
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

    private void OnEnable()
    {
        _spawner.BallSpawned += OnBallSpawned;
    }

    private void OnDisable()
    {
        _spawner.BallSpawned -= OnBallSpawned;
    }

    private bool TryFindMatches(out List<Ball> matchedBalls)
    {
        List<Ball> balls = _container.GetComponentsInChildren<Ball>().ToList();
        int level = GetHighestLevel(balls);

        while (level > 0)
        {
            Ball[] matchingBalls = null;
            matchingBalls = balls.FindAll(ball => ball.Level == level).ToArray();

            if (matchingBalls.Length >= 3)
            {
                matchedBalls = matchingBalls.Take(3).ToList();
                return true;
            }

            level--;
        }

        matchedBalls = null;
        return false;
    }

    private int GetHighestLevel(List<Ball> balls)
    {
        int level = 0;

        foreach (var ball in balls)
            if (ball.Level > level)
                level = ball.Level;

        return level;
    }

    private void OnBallSpawned()
    {
        if (TryFindMatches(out List<Ball> balls))
        {
            _button.interactable = true;
            _button.onClick.AddListener(() => TryToMerge(balls));
        }
    }

    private void TryToMerge(List<Ball> balls)
    {
        Debug.Log(balls.Count);
        foreach (var ball in balls)
        {
            if (ball != null)
                ball.transform.DOMove(_spawner.transform.position, 2, false).OnComplete(() =>
                {
                    UpgradeOneBall(balls);
                });
        }
    }

    private void UpgradeOneBall(List<Ball> balls)
    {
        var ball = balls[0];
        balls.Remove(ball);
        ball.LevelUp();

        foreach (var lowLevel in balls)
            Destroy(lowLevel.gameObject);

        StartCoroutine(CheckForAdditionalMatches());
    }

    private IEnumerator CheckForAdditionalMatches()
    {
        _button.interactable = false;

        yield return new WaitForSeconds(3);

        OnBallSpawned();
    }
    /* 
        private void TryToMerge(Ball[] balls)
        {
            Debug.Log(balls.Length);
            foreach (var ball in balls)
            {
                if (ball != null)
                    ball.transform.DOMove(_spawner.transform.position, 2, false).OnComplete(() =>
                    {
                        DestroyTwoBalls(balls);
                        ball.LevelUp();
                    });
            }

            StartCoroutine(CheckForAdditionalMatches());
        }

        private void DestroyTwoBalls(Ball[] balls)
        {
            for (int i = 0; i < 2; i++)
                if (balls.Length > i && balls[i] != null)
                    Destroy(balls[i].gameObject);
        } */
}
