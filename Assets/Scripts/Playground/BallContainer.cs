using System.Collections.Generic;
using UnityEngine;

public class BallContainer : MonoBehaviour
{
    [SerializeField] private BallSpawner _spawner;

    private int _childCount;
    private List<Ball> _balls = new();

    private void Update()
    {
        if (transform.childCount != _childCount)
        {
            _childCount = transform.childCount;
            _balls.Clear();
            _balls.AddRange(transform.GetComponentsInChildren<Ball>());
        }
    }

    private void OnDisable() => Reset();

    public void Reset()
    {
        foreach (var ball in _balls)
            if (ball != null)
                Destroy(ball.gameObject);
    }
}
