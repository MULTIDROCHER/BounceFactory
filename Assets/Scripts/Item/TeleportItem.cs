using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(BonusHandler))]
[RequireComponent(typeof(EffectHandler))]
public class TeleportItem : Item
{
    public static List<Ball> InPortal { get; private set; } = new();

    private readonly float _delay = 2;
    private readonly float _duration = .5f;

    private BonusHandler _bonusHandler;
    private EffectHandler _effectHandler;
    private ItemMovement _movement;
    private WaitForSeconds _wait;
    private Vector2 _defaultSize;
    
    public bool CanTeleport => _movement.IsDragging == false;

    protected override void Awake()
    {
        base.Awake();
        _bonusHandler = GetComponent<BonusHandler>();
        _effectHandler = GetComponent<EffectHandler>();

        _wait = new(_delay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball)
        && CanTeleport
        && InPortal.Contains(ball) == false)
            TryToTeleport(ball);
    }

    public IEnumerator Destroy()
    {
        Color noAlpha = new(1, 1, 1, 0);

        Renderer.color = noAlpha;

        if (InPortal.Count != 0)
            foreach (var ball in InPortal)
                Appear(ball, this);

        yield return _wait;

        Destroy(gameObject);
    }

    private void TryToTeleport(Ball ball)
    {
        InPortal.Add(ball);
        _defaultSize = ball.transform.localScale;
        List<TeleportItem> portals = FindObjectsOfType<TeleportItem>().ToList();

        if (portals.Count > 1)
        {
            var portal = portals.Find(portal => portal != this);
            StartCoroutine(Teleportation(ball, portal));
        }
        else
        {
            StartCoroutine(Teleportation(ball, this));
        }
    }

    private void Disappear(Ball ball)
    {
        _effectHandler.DoEffect(transform.position);
        ball.transform.DOMove(transform.position, _duration, false);
        ball.transform.DOScale(Vector3.zero, _duration).OnComplete(() =>
        ball.Rigidbody.bodyType = RigidbodyType2D.Static);
    }

    private void Appear(Ball ball, TeleportItem portal)
    {
        _effectHandler.DoEffect(portal.transform.position);
        ball.transform.position = portal.transform.position;
        ball.transform.DOScale(_defaultSize, _duration).OnComplete(() =>
        {
            ball.Rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _bonusHandler.AddBonus(portal.transform.position, ball);
        });
    }

    private IEnumerator Teleportation(Ball ball, TeleportItem portal)
    {
        if (ball != null)
            Disappear(ball);

        yield return _wait;

        if (ball != null)
            Appear(ball, portal);

        StopCoroutine(Teleportation(ball, portal));
        StartCoroutine(ReactivateBall(ball));
    }

    private IEnumerator ReactivateBall(Ball ball)
    {
        yield return _wait;

        InPortal.Remove(ball);
        StopCoroutine(ReactivateBall(ball));
    }
}