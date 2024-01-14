using TMPro;
using UnityEngine;
using YG;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private string _baseText;
    private int _current;

    private void Awake() => _baseText = _text.text + "\n";

    private void Update()
    {
        if (YandexGame.savesData.Level != _current)
        {
            _current = YandexGame.savesData.Level;
            UpdateDisplay();
        }
    }

    private void UpdateDisplay() => _text.text = _baseText + _current.ToString();
}
