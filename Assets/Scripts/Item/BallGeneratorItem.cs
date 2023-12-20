using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EffectHandler))]
public class BallGeneratorItem : Item, IAnimated
{
    [SerializeField] private ParticleSystem _spawnEffect;
    [SerializeField] private ParticleSystem _destroyEffect;

    private readonly int _acceleration = 10;
    private readonly List<Ball> _spawned = new();

    private Animator _animator;
    private EffectHandler _effectHandler;
    private int _amount = 2;
    private int _delay = 3;
    private bool _isActive = true;

    private void Start()
    {
        _type = ItemType.BallGenerator;

        TryGetComponent(out _animator);
        TryGetComponent(out _effectHandler);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball) && _isActive)
        {
            _isActive = false;
            PlayAnimation(other);
            CreateClones(ball);
            StartCoroutine(DestroyBallsAfterDelay());
        }
    }

    private void OnDestroy()
    {
        foreach (var ball in _spawned)
            Destroy(ball);
    }

    public override void LevelUp()
    {
        base.LevelUp();

        _delay++;
        _amount++;
    }

    public void PlayAnimation(Collider2D _) => _animator.SetTrigger(IAnimated.Trigger);

    private Vector2 SetDirection() => Vector2.right * Random.Range(0, 360);

    private void CreateClones(Ball ball)
    {
        for (int i = 0; i < _amount; i++)
        {
            var clone = Instantiate(ball, transform.position, Quaternion.identity);
            clone.TryGetComponent(out Rigidbody2D rigidbody);
            rigidbody.velocity = SetDirection().normalized * _acceleration;
            _spawned.Add(clone);
        }

        _effectHandler.DoEffect(_spawnEffect, transform.position);
    }

    private IEnumerator DestroyBallsAfterDelay()
    {
        yield return new WaitForSeconds(_delay);

        foreach (var item in _spawned.ToArray())
            if (item != null)
            {
                Destroy(item.gameObject);
                _effectHandler.DoEffect(_destroyEffect, item.transform.position);
            }

        Reset();
    }

    private void Reset()
    {
        _spawned.Clear();
        _isActive = true;
    }
}