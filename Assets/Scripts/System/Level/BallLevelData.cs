using BounceFactory.Playground.Storage.Holder;
using UnityEngine;

namespace BounceFactory.System.Level
{
    public class BallLevelData : MonoBehaviour
    {
        [SerializeField] private BallHolder _ballHolder;

        public BallHolder BallHolder => _ballHolder;
    }
}