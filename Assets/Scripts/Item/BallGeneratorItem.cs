using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallGeneratorItem : Item, IAnimated
{
    private ParticleSystem _spawnEffect;
    private ParticleSystem _destroyEffect;
    private Animator _animator;
    private int _amount = 2;
    private int _delay = 3;
    private readonly int _acceleration = 10;
    private readonly List<Ball> _spawned = new();

    private bool _isActive = true;

    private void Start()
    {
        _canBeUpgraded = true;
        _type = ItemType.BallGenerator;
        Collider.isTrigger = true;

        TryGetComponent(out _animator);
        GetComponent<Collider2D>().isTrigger = true;
        _spawnEffect = AssetDatabase.LoadAssetAtPath<ParticleSystem>("Assets/EFFECTS/CFXR Impact Glowing HDR (Blue).prefab");
        _destroyEffect = AssetDatabase.LoadAssetAtPath<ParticleSystem>("Assets/EFFECTS/CFXM_Enemy_Explosion.prefab");
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

    public override void LevelUp()
    {
        base.LevelUp();

        _delay++;
        _amount++;
    }

    private void CreateClones(Ball ball)
    {
        for (int i = 0; i < _amount; i++)
        {
            var clone = Instantiate(ball, transform.position, Quaternion.identity);
            clone.TryGetComponent(out Rigidbody2D rigidbody);
            rigidbody.velocity = SetDirection().normalized * _acceleration;
            _spawned.Add(clone);
        }

        DoEffect(_spawnEffect, transform.position);
    }

    private IEnumerator DestroyBallsAfterDelay()
    {
        yield return new WaitForSeconds(_delay);

        foreach (var item in _spawned.ToArray())
            if (item != null){
                Destroy(item.gameObject);
                DoEffect(_destroyEffect, item.transform.position);
            }

        Reset();
    }

    private void Reset()
    {
        _spawned.Clear();
        _isActive = true;
    }

    private Vector2 SetDirection() => Vector2.right * Random.Range(0, 360);

    public void PlayAnimation(Collider2D other) => _animator.SetTrigger(IAnimated.Trigger);

    private void DoEffect(ParticleSystem effect, Vector3 position)
    {
        Instantiate(effect, position, Quaternion.identity, transform);
    }
}