using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using YG;

public class Level : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private ItemSpawner _itemSpawner;
    private BallSpawner _ballSpawner;
}