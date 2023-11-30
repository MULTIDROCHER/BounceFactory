using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using System.Linq;

public class TeleportItem : Item
{
    public static List<Ball> InPortal { get; private set; } = new();

    private BonusHandler _bonusHandler;

    private void Start()
    {
        _bonusHandler = GetComponent<BonusHandler>();
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
            Debug.Log("tp");
            var portal = portals.Find(portal => portal != this);
            StartCoroutine(Teleportation(ball, portal));
        }
        else
        {
            Debug.Log("tp to ths");
            StartCoroutine(Teleportation(ball, this));
        }
    }

    private IEnumerator Teleportation(Ball ball, TeleportItem portal)
    {
        Debug.Log("disappear");
        ball.transform.DOMove(transform.position, .5f, false);
        ball.transform.DOScale(Vector3.zero, .5f).OnComplete(() =>
        ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static);

        yield return new WaitForSeconds(2);

        Debug.Log("appear");
        ball.transform.position = portal.transform.position;
        ball.transform.DOScale(Vector3.one, .5f).OnComplete(() =>
        {
            ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            _bonusHandler.AddBonus(portal.transform.position, ball);
            StartCoroutine(ReactivateBall(ball));
        });
        StopCoroutine(Teleportation(ball, portal));
    }

    private IEnumerator ReactivateBall(Ball ball)
    {
        yield return new WaitForSeconds(3);

        InPortal.Remove(ball);
        StopCoroutine(ReactivateBall(ball));
    }
}