using UnityEngine;

public class AccelerationItem : Item
{
    private readonly int _acceleration = 10;

    private void Start()
    {
        _canBeUpgraded = true;
        _type = ItemType.Acceleration;
        Collider.isTrigger = true;

        GetComponent<Collider2D>().isTrigger = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball)
        && ball.TryGetComponent(out Rigidbody2D rigidBody))
            rigidBody.velocity = transform.up.normalized * _acceleration;
    }
}