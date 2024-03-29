using TMPro;
using UnityEngine;
using YG;

namespace BounceFactory.System.Game
{
    public class LevelCounter : MonoBehaviour
    {
        private readonly string _newLine = "\n";

        [SerializeField] private TMP_Text _text;
        [SerializeField] private LevelSwitcher _levelSwitcher;

        private string _baseText;
        private int _current;

        private void Start()
        {
            _baseText = _text.text + _newLine;
            SetLevel();
        }

        private void OnEnable() => _levelSwitcher.LevelChanged += SetLevel;

        private void OnDisable() => _levelSwitcher.LevelChanged -= SetLevel;

        private void SetLevel()
        {
            if (YandexGame.savesData.Level != _current)
            {
                _current = YandexGame.savesData.Level;
                var updatedText = ToStringConverter.GetTextWithNumber(_baseText, _current);

                UpdateDisplay(updatedText);
            }
        }

        private void UpdateDisplay(string level) => _text.text = level;
    }
}