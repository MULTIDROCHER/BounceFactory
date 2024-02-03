using BounceFactory.System.Level;
using TMPro;
using UnityEngine;
using YG;

namespace BounceFactory.System.Game
{
    public class LevelCounter : MonoBehaviour
    {
        [SerializeField] TMP_Text _text;

        private string _baseText;
        private int _current;

        private void Start()
        {
            _baseText = _text.text + "\n";
            SetLevel();
        }

        private void OnEnable() => ActiveComponentsProvider.LevelChanged += SetLevel;

        private void OnDisable() => ActiveComponentsProvider.LevelChanged -= SetLevel;

        private void SetLevel()
        {
            if (YandexGame.savesData.Level != _current)
            {
                _current = YandexGame.savesData.Level;
                UpdateDisplay(LevelToString());
            }
        }

        private string LevelToString() => _baseText + _current.ToString();

        private void UpdateDisplay(string level) => _text.text = level;
    }
}