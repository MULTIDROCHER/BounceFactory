using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using System.Linq;

public class TeleportItem : Item
{
    public static List<Ball> InPortal { get; private set; } = new();

    private BonusHandler _bonusHandler;
    private float _delay = 2;
    private float _duration = .5f;
    private WaitForSeconds _wait;

    private void Start()
    {
        _bonusHandler = GetComponent<BonusHandler>();
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
        ball.transform.DOMove(transform.position, _duration, false);
        ball.transform.DOScale(Vector3.zero, _duration).OnComplete(() =>
        ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static);
    }

    private void Appear(Ball ball, TeleportItem portal)
    {
        ball.transform.position = portal.transform.position;
        ball.transform.DOScale(Vector3.one, _duration).OnComplete(() =>
        {
            ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            _bonusHandler.AddBonus(portal.transform.position, ball);
            StartCoroutine(ReactivateBall(ball));
        });
    }

    private IEnumerator Teleportation(Ball ball, TeleportItem portal)
    {
        Disappear(ball);

        yield return _wait;

        Appear(ball, portal);
        StopCoroutine(Teleportation(ball, portal));
    }

    private IEnumerator ReactivateBall(Ball ball)
    {
        yield return _wait;

        InPortal.Remove(ball);
        StopCoroutine(ReactivateBall(ball));
    }
}