using UnityEngine;

public class BounceController : MonoBehaviour
{
    [SerializeField] private PhysicsMaterial2D _bounceMaterial;

    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    private void Start()
    {
        TryGetComponent(out _rigidbody);
        TryGetComponent(out _collider);

        EnableMaterial();
    }

    public void EnableMaterial()
    {
        _rigidbody.sharedMaterial = _bounceMaterial;
        _collider.sharedMaterial = _bounceMaterial;
    }

    public void DisableMaterial()
    {
        _rigidbody.sharedMaterial = null;
        _collider.sharedMaterial = null;
    }
}