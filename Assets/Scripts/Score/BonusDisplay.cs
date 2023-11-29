using System.Collections;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BonusDisplay : MonoBehaviour
{
    private TMP_Text _text;
    private float _delay = 2;
    private Vector2 _position;
    private Vector2 _positionSpread = new(.2f, .2f);

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    private void LateUpdate()
    {
        transform.SetPositionAndRotation(_position, Quaternion.identity);
    }

    public void ShowBonus(int bonus, ContactPoint2D pos)
    {
        SetText(bonus, pos);
        Destroy(gameObject, _delay);
    }

    private void SetText(int bonus, ContactPoint2D pos)
    {
        _text.text = "+" + bonus.ToString();
        _position = pos.point;
        _position += new Vector2(Random.Range(-_positionSpread.x, _positionSpread.x), Random.Range(-_positionSpread.y, _positionSpread.y));
    }
}