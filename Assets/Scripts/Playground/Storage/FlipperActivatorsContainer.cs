using BounceFactory.Playground.FlipperSystem;
using UnityEngine;

namespace BounceFactory.Playground.Storage
{
    public class FlipperActivatorsContainer : MonoBehaviour
    {
        [SerializeField] private FlipperActivator[] _activators;

        public FlipperActivator[] Activators => _activators;
    }
}