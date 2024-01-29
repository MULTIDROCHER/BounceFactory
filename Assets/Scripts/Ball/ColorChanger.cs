using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private readonly Dictionary<int, Color> _colorsByLevel = new();
    private readonly int _startLevel = 1;
    private readonly int _levelIncrease = 1;

    private void Start() => _colorsByLevel.Add(_startLevel, Color.white);

    public Color ChangeColor(UpgradableObject item)
    {
        int level = item.Level + _levelIncrease;

        if (_colorsByLevel.TryGetValue(level, out Color color))
            return color;
        else
            return AddNewColor(level);
    }

    private Color AddNewColor(int level)
    {
        var newColor = GenerateRandomColor();
        _colorsByLevel.Add(level, newColor);
        return newColor;
    }

    private Color GenerateRandomColor()
    {
        float minRange = 0;
        float maxRange = 1;

        float r = Random.Range(minRange, maxRange);
        float g = Random.Range(minRange, maxRange);
        float b = Random.Range(minRange, maxRange);

        return new Color(r, g, b);
    }
}