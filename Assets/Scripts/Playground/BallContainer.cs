using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContainer : MonoBehaviour
{
    private int _childCount;

    public List<Ball> Balls { get; private set; } = new();

    private void Update()
    {
        if (transform.childCount != _childCount)
        {
            _childCount = transform.childCount;
            Balls.Clear();
            Balls.AddRange(transform.GetComponentsInChildren<Ball>());
        }
    }

    public void Reset()
    {
        foreach (var ball in Balls)
            if (ball != null)
                Destroy(ball.gameObject);
    }
}
