using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _bounceSound;
    [SerializeField] private AudioClip _teleportSound;
    [SerializeField] private AudioClip _generatorSound;
    [SerializeField] private AudioClip _accelerationSound;


    private AudioSource _source;

    private void Start() => TryGetComponent(out _source);

    private void OnCollisionEnter2D(Collision2D other) => _source.PlayOneShot(_bounceSound);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out TeleportItem _))
            _source.PlayOneShot(_teleportSound);
        else if (other.TryGetComponent(out BallGeneratorItem _))
            _source.PlayOneShot(_generatorSound);
        else if (other.TryGetComponent(out AccelerationItem _))
            _source.PlayOneShot(_accelerationSound);
    }
}