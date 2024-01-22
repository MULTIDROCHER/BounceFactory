using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BounceHandler : MonoBehaviour
{
    [SerializeField] private PhysicsMaterial2D _material;
    [SerializeField] private ParticleSystem _effect;

    private Rigidbody2D _rigidbody;
    private EffectContainer _container;

    private void Start()
    {
        _container = FindObjectOfType<EffectContainer>();
        _rigidbody = GetComponent<Rigidbody2D>();

        EnableMaterial();
    }

    private void OnCollisionEnter2D(Collision2D other)
    => Instantiate(_effect, other.GetContact(0).point, Quaternion.identity, _container.transform);

    public void EnableMaterial() => _rigidbody.sharedMaterial = _material;

    public void DisableMaterial() => _rigidbody.sharedMaterial = null;
}