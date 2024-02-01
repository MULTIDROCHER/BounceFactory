using UnityEngine;

namespace BounceFactory
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundHandler : MonoBehaviour
    {
        [SerializeField] private AudioClip _bounceSound;
        [SerializeField] private AudioClip _teleportSound;
        [SerializeField] private AudioClip _generatorSound;
        [SerializeField] private AudioClip _accelerationSound;

        private AudioSource _source;
        private TeleportableObject _teleportable;

        private void Awake()
        {
            _teleportable = GetComponent<TeleportableObject>();
            _source = GetComponent<AudioSource>();

            _source.volume = AudioManager.Instance.SFXSource.volume;
        }

        private void OnEnable() => AudioManager.Instance.VolumeChanged += OnVolumeChanged;

        private void OnDisable() => AudioManager.Instance.VolumeChanged -= OnVolumeChanged;

        private void OnCollisionEnter2D(Collision2D other) => _source.PlayOneShot(_bounceSound);

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.TryGetComponent(out Item item);

            switch (item)
            {
                case TeleportItem teleport when teleport.CanTeleport
                && _teleportable != null && _teleportable.CanBeTeleported:
                    PlaySound(_teleportSound);
                    break;
                case BallGeneratorItem generator when generator.IsActive:
                    PlaySound(_generatorSound);
                    break;
                case AccelerationItem:
                    PlaySound(_accelerationSound);
                    break;
            }
        }

        private void PlaySound(AudioClip clip) => _source.PlayOneShot(clip);

        private void OnVolumeChanged(float value) => _source.volume = value;
    }
}