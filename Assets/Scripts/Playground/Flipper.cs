using UnityEngine;
using DG.Tweening;
using UnityEngine.Video;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float _angle;
    [SerializeField] private AudioClip _sound;

    private readonly float _delay = .1f;
    private readonly int _acceleration = 10;

    private Vector3 _rotation;
    private bool _isOpened = false;

    private void Start() => _rotation = new(0, 0, _angle);

    public void Open()
    {
        SoundManager.Instance.SFXSource.PlayOneShot(_sound);
        _isOpened = true;

        transform.DORotate(_rotation, _delay).OnComplete(() =>
        {
            transform.DORotate(Vector3.zero, _delay)
            .OnComplete(() => _isOpened = false);
        });
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball) && _isOpened)
            AddAcceleration(ball);
    }

    private void AddAcceleration(Ball ball)
    {
        if (ball.TryGetComponent(out Rigidbody2D rigidbody))
            rigidbody.velocity = rigidbody.velocity.normalized *  _acceleration;
    }
}