using System;
using System.Linq;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private Transform _ballContainer;

    public event Action BallDestroyed;
    public event Action BallsOver;

    private void Awake() => _ballContainer = FindObjectOfType<BallContainer>().transform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            if (IsNotClone(ball))
                BallDestroyed?.Invoke();

            Destroy(ball.gameObject);

            if (_ballContainer.childCount <= 1)
                BallsOver?.Invoke();
        }
    }

    private bool IsNotClone(Ball ball)
    {
        Ball[] balls = _ballContainer.GetComponentsInChildren<Ball>();

        return balls.Contains(ball);
    }
}