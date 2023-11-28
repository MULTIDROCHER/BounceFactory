using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private Ball _ball;

    private void Awake() => TryGetComponent(out _ball);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Item item)
        && item.Type == ItemType.Common)
            ScoreCounter.Instance.AddScore(_ball.Bonus + item.Bonus);
    }
}