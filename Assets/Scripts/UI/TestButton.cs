using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] private Ball _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _container;

    public void CreateNewBall()
    {
        var _spawned = Instantiate(_template, _spawnPoint.transform.position, Quaternion.identity, _container);
    }
}
