using UnityEngine;

public class BounceController : MonoBehaviour
{
    [SerializeField] private PhysicsMaterial2D _bounceMaterial;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        TryGetComponent(out _rigidbody);
        EnableMaterial();
    }

    public void EnableMaterial() => _rigidbody.sharedMaterial = _bounceMaterial;

    public void DisableMaterial() => _rigidbody.sharedMaterial = null;
}