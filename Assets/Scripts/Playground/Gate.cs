using UnityEngine;
using DG.Tweening;

public class Gate : MonoBehaviour
{
    [SerializeField] private float _angle;

    private readonly float _delay = .1f;
    private readonly int _acceleration = 10;

    private Vector3 _rotation;

    private bool IsOpened => transform.rotation.eulerAngles != Vector3.zero;
    public int Bonus { get; private set; } = 5;

    private void Start() => _rotation = new(0, 0, _angle);

    public void Open()
    {
        transform.DORotate(_rotation, _delay).OnComplete(() =>
        { transform.DORotate(Vector3.zero, _delay); });
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball) && IsOpened)
        {
            Debug.Log(IsOpened +" " + gameObject.name+ transform.rotation.eulerAngles);
            AddAcceleration(ball);
        }
    }

    private void AddAcceleration(Ball ball)
    {
        if (ball.TryGetComponent(out Rigidbody2D rigidbody))
            rigidbody.velocity = rigidbody.velocity.normalized * _acceleration;
    }
}