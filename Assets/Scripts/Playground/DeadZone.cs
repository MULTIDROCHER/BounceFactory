using System;
using System.Linq;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private BallContainer _container;

    public event Action BallDestroyed;
    public event Action BallsOver;

    private void Awake() => GetContainer();

    public void GetContainer(BallContainer container = null)
    {
        if (container == null)
            _container = FindObjectOfType<BallContainer>();
        else
            _container = container;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            if (IsNotClone(ball))
                BallDestroyed?.Invoke();

            Destroy(ball.gameObject);

            if (_container.transform.childCount <= 1)
                BallsOver?.Invoke();

                Debug.Log("killed ball ostalos' -" +_container.transform.childCount);
        }
    }

    private bool IsNotClone(Ball ball)
    {
        Ball[] balls = _container.GetComponentsInChildren<Ball>();

        return balls.Contains(ball);
    }
}