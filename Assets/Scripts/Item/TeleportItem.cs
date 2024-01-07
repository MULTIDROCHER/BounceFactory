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
    private WaitForSeconds _wait;
    private Vector2 _defaultSize;

    private void Start()
    {
        TryGetComponent(out _bonusHandler);
        TryGetComponent(out _effectHandler);
        _wait = new(_delay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Ball ball) && InPortal.Contains(ball) == false)
            TryToTeleport(ball);
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
        ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static);
    }

    private void Appear(Ball ball, TeleportItem portal)
    {
        _effectHandler.DoEffect(portal.transform.position);
        ball.transform.position = portal.transform.position;
        ball.transform.DOScale(_defaultSize, _duration).OnComplete(() =>
        {
            ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
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