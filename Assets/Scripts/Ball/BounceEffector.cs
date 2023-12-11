using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bounceEffect;
    [SerializeField] private AudioClip _bounceSound;
    [SerializeField] private AudioClip _teleportSound;
    [SerializeField] private AudioClip _generatorSound;
    [SerializeField] private AudioClip _accelerationSound;


    private AudioSource _source;
    private EffectContainer _container;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _container = FindObjectOfType<EffectContainer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _source.PlayOneShot(_bounceSound);
        Instantiate(_bounceEffect, other.GetContact(0).point, Quaternion.identity, _container.transform);
    }

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
