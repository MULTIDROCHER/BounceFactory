using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private string _baseText;

    private int _current;

    private void Awake() => _baseText = _text.text;

    private void Update()
    {
        if (Progress.Instance.Level != _current)
        {
            _current = Progress.Instance.Level;
            UpdateDisplay();
        }
    }

    private void UpdateDisplay() => _text.text = _baseText + _current.ToString();
}
