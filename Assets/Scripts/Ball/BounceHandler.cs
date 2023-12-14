using UnityEngine;

public class BounceHandler : MonoBehaviour
{
    [SerializeField] private PhysicsMaterial2D _bounceMaterial;
    [SerializeField] private ParticleSystem _bounceEffect;

    private Rigidbody2D _rigidbody;
    private EffectContainer _container;

    private void Start()
    {
        _container = FindObjectOfType<EffectContainer>();
        TryGetComponent(out _rigidbody);
        EnableMaterial();
    }

    private void OnCollisionEnter2D(Collision2D other)
    => Instantiate(_bounceEffect, other.GetContact(0).point, Quaternion.identity, _container.transform);

    public void EnableMaterial() => _rigidbody.sharedMaterial = _bounceMaterial;

    public void DisableMaterial() => _rigidbody.sharedMaterial = null;
}