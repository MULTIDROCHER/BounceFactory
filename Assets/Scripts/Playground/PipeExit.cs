using UnityEngine;

namespace BounceFactory
{
    public class PipeExit : MonoBehaviour
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