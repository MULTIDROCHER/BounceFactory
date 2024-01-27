using System.Collections.Generic;
using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    private readonly Dictionary<int, Color> _colorsByLevel = new();
    private readonly int _startLevel = 1;
    private readonly int _levelIncrease = 1;

    private void Start() => _colorsByLevel.Add(_startLevel, Color.white);

    public Color SetColor(Ball ball)
    {
        int level = ball.Level + _levelIncrease;

        if (_colorsByLevel.TryGetValue(level, out Color color))
        {
            return color;
        }
        else
        {
            var newColor = GetRandomColor();
            _colorsByLevel.Add(level, newColor);
            return newColor;
        }
    }

    private Color GetRandomColor()
    {
        float minRange = 0;
        float maxRange = 1;

        float r = Random.Range(minRange, maxRange);
        float g = Random.Range(minRange, maxRange);
        float b = Random.Range(minRange, maxRange);

        return new Color(r, g, b);
    }
}