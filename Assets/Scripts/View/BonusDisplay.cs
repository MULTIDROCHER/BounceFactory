using TMPro;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class BonusDisplay : MonoBehaviour
{
    private readonly float _delay = 2;

    private Canvas _canvas;
    private TMP_Text _text;
    private Vector2 _position;
    private Vector2 _positionSpread = new(.2f, .2f);

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
        TryGetComponent(out _canvas);
        _canvas.worldCamera = Camera.main;
    }

    private void LateUpdate() => transform.SetPositionAndRotation(_position, Quaternion.identity);

    public void ShowBonus(int bonus, Vector3 position)
    {
        SetText(bonus, position);
        Destroy(gameObject, _delay);
    }

    private void SetText(int bonus, Vector3 pos)
    {
        _text.text = "+" + bonus.ToString();
        _position = pos;
        _position += new Vector2(Random.Range(-_positionSpread.x, _positionSpread.x), Random.Range(-_positionSpread.y, _positionSpread.y));
    }
}