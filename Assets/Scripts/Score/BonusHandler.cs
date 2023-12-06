using UnityEngine;

public class BonusHandler : MonoBehaviour
{
    [SerializeField] private BonusDisplay _bonusDisplay;

    private Item _item;

    private void Start() => TryGetComponent(out _item);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
            AddBonus(other.GetContact(0).point, ball);
    }

    public void AddBonus(Vector3 position, Ball ball)
    {
        int bonus = ball.Bonus + _item.Bonus;
        ScoreCounter.Instance.AddScore(bonus);

        var display = Instantiate(_bonusDisplay, transform);
        display.ShowBonus(bonus, position);
    }
}
