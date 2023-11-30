using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private readonly Ball _template;
    [SerializeField] private readonly Transform _spawnPoint;
    [SerializeField] private readonly Transform _container;

    public void Spawn() => Instantiate(_template, _spawnPoint.transform.position, Quaternion.identity, _container);
}