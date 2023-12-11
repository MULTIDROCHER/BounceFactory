using UnityEngine;

public class BonusHandler : MonoBehaviour
{
    [SerializeField] private BonusDisplay _bonusDisplay;

    private Item _item;

    private void Start() => TryGetComponent(out _item);

    private void OnCollisionEnter2D(Collision2D other) => TryGetRevard(other.gameObject, other.GetContact(0).point);

    private void OnTriggerEnter2D(Collider2D other) => TryGetRevard(other.gameObject, transform.position);

    private void TryGetRevard(GameObject other, Vector3 position)
    {
        if (other.TryGetComponent(out Ball ball))
            AddBonus(position, ball);
    }

    public void AddBonus(Vector3 position, Ball ball)
    {
        int bonus = ball.Bonus + _item.Bonus;
        ScoreCounter.Instance.AddScore(bonus);

        var display = Instantiate(_bonusDisplay, transform);
        display.ShowBonus(bonus, position);
    }
}