using BounceFactory.System;
using TMPro;
using UnityEngine;

namespace BounceFactory.Display
{
    [RequireComponent(typeof(Canvas))]
    public class BonusDisplay : MonoBehaviour
    {
        private readonly float _delay = 2;
        private readonly string _symbol = "+";

        private TMP_Text _text;
        private Vector2 _position;
        private Vector2 _positionSpread = new (.2f, .2f);

        private void Awake() => _text = GetComponentInChildren<TMP_Text>();

        private void LateUpdate() => transform.SetPositionAndRotation(_position, Quaternion.identity);

        public void ShowBonus(int bonus, Vector3 position)
        {
            var text = ToStringConverter.GetTextWithNumber(_symbol, bonus);

            SetText(text, position);
            Destroy(gameObject, _delay);
        }

        private void SetText(string text, Vector3 pos)
        {
            _text.text = text;
            _position = pos;
            _position += GetPositionSpread();
        }

        private Vector2 GetPositionSpread()
        {
            float spreadX = Random.Range(-_positionSpread.x, _positionSpread.x);
            float spreadY = Random.Range(-_positionSpread.y, _positionSpread.y);

            return new Vector2(spreadX, spreadY);
        }
    }
}