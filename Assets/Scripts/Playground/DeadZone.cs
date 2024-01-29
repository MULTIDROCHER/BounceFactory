using System;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private BallHolder _holder;

    public event Action BallDestroyed;
    public event Action BallsOver;

    private void Awake() => SetContainer();

    public void SetContainer(BallHolder holder = null)
    {
        if (holder == null)
            _holder = FindObjectOfType<BallHolder>();
        else
            _holder = holder;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            if (IsNotClone(ball))
                BallDestroyed?.Invoke();

            Destroy(ball.gameObject);

            if (_holder.transform.childCount <= 1)
                BallsOver?.Invoke();
        }
    }

    private bool IsNotClone(Ball ball) => _holder.Contents.Contains(ball);
}