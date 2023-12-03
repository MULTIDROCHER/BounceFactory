using System;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _container;
    [SerializeField] private BallSeller _seller;

    public event Action BallBought;

    public void Spawn()
    {
        Instantiate(_template, _spawnPoint.transform.position, Quaternion.identity, _container);
        ScoreCounter.Instance.Buy(_seller.Price);
        BallBought?.Invoke();
    }
}