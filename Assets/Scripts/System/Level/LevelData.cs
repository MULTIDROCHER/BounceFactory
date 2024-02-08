using UnityEngine;

namespace BounceFactory.System.Level
{
    [RequireComponent(typeof(ItemLevelData))]
    [RequireComponent(typeof(BallLevelData))]
    public class LevelData : MonoBehaviour
    {
        public ItemLevelData ItemData { get; private set; }

        public BallLevelData BallData { get; private set; }

        private void Awake()
        {
            ItemData = GetComponent<ItemLevelData>();
            BallData = GetComponent<BallLevelData>();
        }
    }
}