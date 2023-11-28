using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private Ball _ball;
    private BonusDisplay _bonusDisplay;

    private void Awake()
    {
        TryGetComponent(out _ball);
        _bonusDisplay = GetComponentInChildren<BonusDisplay>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Item item)
        && item.Type == ItemType.Common)
        {
            int bonus = _ball.Bonus + item.Bonus;
            ScoreCounter.Instance.AddScore(bonus);
            _bonusDisplay.ShowText(bonus, item);
        }
    }
}