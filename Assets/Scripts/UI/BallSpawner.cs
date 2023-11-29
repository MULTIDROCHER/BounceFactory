using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _container;

    public UnityAction BallSpawned;

    public void Spawn()
    {
        Instantiate(_template, _spawnPoint.transform.position, Quaternion.identity, _container);
        BallSpawned?.Invoke();
    }
}
