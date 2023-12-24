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

    public void Spawn(Ball ball){
        Instantiate(_template, _container.transform.position, Quaternion.identity, _container.transform);
        BallBought?.Invoke();
    }
}