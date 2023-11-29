using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHandler : MonoBehaviour
{
    [SerializeField] private BonusDisplay _bonusDisplay;
    private Item _item;

    private void Awake()
    {
        TryGetComponent(out _item);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            var pos = other.GetContact(0);
            int bonus = ball.Bonus + _item.Bonus;
            ScoreCounter.Instance.AddScore(bonus);

            var display = Instantiate(_bonusDisplay, transform);
            display.ShowBonus(bonus, pos);
        }
    }
}
