using BounceFactory.BaseObjects;
using BounceFactory.Display;
using UnityEngine;

namespace BounceFactory.Score
{
    [RequireComponent(typeof(Item))]
    public class BonusHandler : MonoBehaviour
    {
        [SerializeField] private BonusDisplay _bonusDisplay;

        private Item _item;

        private void Start() => _item = GetComponent<Item>();

        private void OnCollisionEnter2D(Collision2D other) => TryGetRevard(other.gameObject, other.GetContact(0).point);

        private void OnTriggerEnter2D(Collider2D other) => TryGetRevard(other.gameObject, transform.position);

        private void TryGetRevard(GameObject other, Vector3 position)
        {
            if (enabled && other.TryGetComponent(out Ball ball)
            && _item.TryGetComponent(out TeleportItem _) == false)
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
}