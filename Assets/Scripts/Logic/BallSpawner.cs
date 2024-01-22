using System;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _template;

    private BallContainer _container;
    private BallSeller _seller;

    public event Action BallBought;

    private void Awake()
    {
        GetContainer();
        _seller = FindObjectOfType<BallSeller>();
    }

    public void Spawn()
    {
        if (_container == null)
            GetContainer();

        Instantiate(_template, _container.transform.position, Quaternion.identity, _container.transform);
        ScoreCounter.Instance.Buy(_seller.Price);
        BallBought?.Invoke();
    }

    public void GetContainer(BallContainer container = null)
    {
        if (container == null)
            _container = FindObjectOfType<BallContainer>();
        else
            _container = container;

        if (_container.transform.childCount == 0)
            Instantiate(_template, _container.transform.position, Quaternion.identity, _container.transform);
    }
}