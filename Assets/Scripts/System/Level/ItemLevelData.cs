using System.Collections.Generic;
using BounceFactory.Logic.Spawning;
using UnityEngine;

namespace BounceFactory.System.Level
{
    public class ItemLevelData : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;

        public List<SpawnPoint> SpawnPoints => _spawnPoints;
    }
}