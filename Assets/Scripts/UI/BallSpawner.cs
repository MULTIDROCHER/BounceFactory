using System;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _template;

    private BallContainer _container;
    private BallSeller _seller;

    public event Action BallBought;

    private void Start()
    {
        _container = FindObjectOfType<BallContainer>();
        _seller = FindObjectOfType<BallSeller>();
    }

    public void Spawn()
    {
        Instantiate(_template, _container.transform.position, Quaternion.identity, _container.transform);
        ScoreCounter.Instance.Buy(_seller.Price);
        BallBought?.Invoke();
    }

    public void Respawn(int[,] balls)
    {
        ColorSetter colorSetter = new();

        for (int i = 0; i < balls.GetLength(0); i++)
        {
            for (int j = 0; j < balls[i, 0]; j++)
            {
                var ball = Instantiate(_template, _container.transform.position, Quaternion.identity, _container.transform);
                BallBought?.Invoke();

                while (ball.Level < balls[i, 1])
                {
                    ball.LevelUp(colorSetter.SetColor(ball));
                }
            }
        }
    }
}