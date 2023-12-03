using System;
using System.Linq;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Transform _ballContainer;

    public event Action BallDestroyed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            if (IsNotClone(ball))
                BallDestroyed?.Invoke();
                
            Destroy(ball.gameObject);
        }
    }

    private bool IsNotClone(Ball ball)
    {
        Ball[] balls = _ballContainer.GetComponentsInChildren<Ball>();

        return balls.Contains(ball);
    }
}