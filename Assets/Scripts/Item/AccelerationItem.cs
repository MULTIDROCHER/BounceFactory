using UnityEditor;
using UnityEngine;

public class AccelerationItem : Item
{
    [SerializeField] private ParticleSystem _effect;
    private float _lifetime = 2;
    private readonly int _acceleration = 10;

    private void Start()
    {
        _type = ItemType.Acceleration;
        Collider.isTrigger = true;

        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball)
        && ball.TryGetComponent(out Rigidbody2D rigidBody))
        {
            rigidBody.velocity = transform.up.normalized * _acceleration;

            if (ball.GetComponentInChildren<ParticleSystem>() == null)
                DoEffect(ball);
        }
    }

    private void DoEffect(Ball ball)
    {
        var effect = Instantiate(_effect, ball.transform.position, Quaternion.identity, ball.transform);
        Destroy(effect.gameObject, _lifetime);
    }
}