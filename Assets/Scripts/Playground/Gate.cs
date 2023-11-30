using UnityEngine;
using DG.Tweening;

public class Gate : MonoBehaviour
{
    [SerializeField] private float _angle;

    private readonly float _delay = .1f;

    private Vector3 _rotation;

    public int Bonus { get; private set; } = 5;

    private void Start() => _rotation = new(0, 0, _angle);

    public void Open()
    {
        transform.DORotate(_rotation, _delay).OnComplete(() =>
        { transform.DORotate(Vector3.zero, _delay); });
    }
}