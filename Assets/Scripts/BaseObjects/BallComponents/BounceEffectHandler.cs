using BounceFactory.Playground.Storage;
using UnityEngine;

namespace BounceFactory.BaseObjects.BallComponents
{
    public class BounceEffectHandler : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effect;

        private EffectContainer _container;

        private void Start() => _container = FindFirstObjectByType<EffectContainer>();

        private void OnCollisionEnter2D(Collision2D other)
        => Instantiate(_effect, other.GetContact(0).point, Quaternion.identity, _container.transform);
    }
}