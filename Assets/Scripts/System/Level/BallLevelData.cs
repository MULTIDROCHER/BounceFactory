using BounceFactory.Playground.DeadZones;
using BounceFactory.Playground.Storage.Holder;
using UnityEngine;

namespace BounceFactory.System.Level
{
    public class BallLevelData : MonoBehaviour
    {
        [SerializeField] private BallHolder _ballHolder;
        [SerializeField] private DeadZone[] _deadZones;

        public BallHolder BallHolder => _ballHolder;

        public DeadZone[] DeadZones => _deadZones;
    }
}