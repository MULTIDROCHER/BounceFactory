using BounceFactory.BaseObjects;
using UnityEngine;

namespace BounceFactory.Playground
{
    public class SplashEffect : MonoBehaviour
    {
        private ParticleSystem _splash;

        private void Awake() => _splash = GetComponentInChildren<ParticleSystem>();

        private void OnTriggerEnter2D(Collider2D other) => DoSplash(other);

        private void DoSplash(Collider2D other)
        {
            if (other.TryGetComponent(out Ball _))
                _splash.Play();
        }
    }
}