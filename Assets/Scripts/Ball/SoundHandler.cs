using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _bounceSound;
    [SerializeField] private AudioClip _teleportSound;
    [SerializeField] private AudioClip _generatorSound;
    [SerializeField] private AudioClip _accelerationSound;

    private AudioSource _source;

    private void Awake()
    {
        TryGetComponent(out _source);
        _source.volume = SoundManager.Instance.SFXSource.volume;
    }

    private void OnEnable() => SoundManager.Instance.VolumeChanged += OnVolumeChanged;

    private void OnDisable() => SoundManager.Instance.VolumeChanged -= OnVolumeChanged;

    private void OnCollisionEnter2D(Collision2D other) => _source.PlayOneShot(_bounceSound);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out TeleportItem portal) && portal.CanTeleport)
            _source.PlayOneShot(_teleportSound);
        else if (other.TryGetComponent(out BallGeneratorItem _))
            _source.PlayOneShot(_generatorSound);
        else if (other.TryGetComponent(out AccelerationItem _))
            _source.PlayOneShot(_accelerationSound);
    }

    private void OnVolumeChanged(float value) => _source.volume = value;
}