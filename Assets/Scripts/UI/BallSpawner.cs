using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _container;

    public void Spawn() => Instantiate(_template, _spawnPoint.transform.position, Quaternion.identity, _container);
}