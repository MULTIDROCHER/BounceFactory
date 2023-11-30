using System.Collections.Generic;
using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    private Dictionary<int, Color> _colorsByLevel = new();

    private void Start() => _colorsByLevel.Add(1, Color.white);

    public Color SetColor(Ball ball)
    {
        int level = ball.Level + 1;

        if (_colorsByLevel.TryGetValue(level, out Color color))
        {
            return color;
        }
        else
        {
            var newColor = RandomColor();
            _colorsByLevel.Add(level, newColor);
            return newColor;
        }
    }

    private Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        return new Color(r, g, b);
    }
}