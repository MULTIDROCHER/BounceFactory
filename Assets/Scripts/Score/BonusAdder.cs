using BounceFactory.BaseObjects;
using BounceFactory.Display;
using UnityEngine;

namespace BounceFactory.Score
{
    [RequireComponent(typeof(Item))]
    public class BonusAdder : MonoBehaviour
    {
        [SerializeField] private BonusDisplay _bonusDisplay;

        private Item _item;

        private void Start() => _item = GetComponent<Item>();

        private void OnCollisionEnter2D(Collision2D other) => GiveRevardOnCollision(other.gameObject, other.GetContact(0).point);

        private void OnTriggerEnter2D(Collider2D other) => GiveRevardOnCollision(other.gameObject, transform.position);

        public void GiveRevard(Vector3 position, Ball ball)
        {
            int bonus = ball.Bonus + _item.Bonus;
            ScoreCounter.Instance.AddScore(bonus);

            var display = Instantiate(_bonusDisplay, transform);
            display.ShowBonus(bonus, position);
        }

        private void GiveRevardOnCollision(GameObject other, Vector3 position)
        {
            if (AbleToGetReward(other, out Ball ball))
                GiveRevard(position, ball);
        }

        private bool AbleToGetReward(GameObject other, out Ball ball)
        {
            ball = other.GetComponent<Ball>();

            return enabled && ball != null && _item.TryGetComponent(out TeleportItem _) == false;
        }
    }
}