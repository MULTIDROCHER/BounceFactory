using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : IUpgradable
{
    private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;

    protected override void Awake()
    {
        base.Awake();

        _rigidbody = GetComponent<Rigidbody2D>();
        BonusIncrease = 2;
        ObjectsAmount = 3;
    }

    public override void LevelUp()
    {
        base.LevelUp();

        _rigidbody.velocity = Vector2.zero;
    }

    public void ChangeColor(Color color) => Renderer.color = color;
}