using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContainer : MonoBehaviour
{
    public List<Ball> Balls { get; private set; } = new();

    private int _childCount;

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
        foreach (Ball ball in transform)
            if (ball != null)
                Destroy(ball.gameObject);
    }
}
