using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BallMerger : MonoBehaviour, ITutorialEvent
{
    [SerializeField] private EffectHandler _effectHandler;
    [SerializeField] private BallSpawner _spawner;
    [SerializeField] private Button _button;

    private readonly int _requiredAmount = 3;

    private BallContainer _container;
    private ColorSetter _colorSetter;
    private int _ballCount;

    public event Action Performed;

    public Button Button => _button;

    private void Start()
    {
        GetContainer();
        _ballCount = _container.transform.childCount;
        _colorSetter = GetComponent<ColorSetter>();
    }

    private void FixedUpdate()
    {
        if (_container.transform.childCount != _ballCount)
        {
            _ballCount = _container.transform.childCount;

            if (_ballCount >= _requiredAmount)
                TryFindMatches();
            else
                ButtonOff();
        }
    }

    public void GetContainer(BallContainer container = null)
    {
        if (container == null)
            _container = FindObjectOfType<BallContainer>();
        else
            _container = container;
    }

    private void TryFindMatches()
    {
        List<Ball> balls = _container.GetComponentsInChildren<Ball>().ToList();

        for (int level = balls.Max(ball => ball.Level); level > 0; level--)
        {
            List<Ball> matchingBalls = balls.FindAll(ball => ball.Level == level);

            if (matchingBalls.Count >= _requiredAmount)
            {
                List<Ball> taken = matchingBalls.Take(_requiredAmount).ToList();
                ButtonOn(taken);
                break;
            }
            else
            {
                ButtonOff();
            }
        }
    }

    private void Merge(List<Ball> balls)
    {
        ButtonOff();
        StartCoroutine(PrepareToMerge(balls));
        Performed?.Invoke();
    }

    private IEnumerator PrepareToMerge(List<Ball> balls)
    {
        int delay = 2;

        foreach (var ball in balls)
        {
            ball.GetComponent<Collider2D>().enabled = false;
            ball.transform.DOMove(_spawner.transform.position, delay);
        }

        yield return new WaitForSeconds(delay);

        var toUpgrade = balls[0];
        balls.Remove(toUpgrade);

        foreach (var ball in balls)
            Destroy(ball.gameObject);

        UpgradeOneBall(toUpgrade);
    }

    private void UpgradeOneBall(Ball ball)
    {
        StopAllCoroutines();

        _effectHandler.DoEffect(_spawner.transform.position);
        ball.LevelUp(_colorSetter.SetColor(ball));
        ball.GetComponent<Collider2D>().enabled = true;
    }

    private void ButtonOn(List<Ball> balls)
    {
        _button.gameObject.SetActive(true);
        _button.onClick.AddListener(() => Merge(balls));
    }

    private void ButtonOff() => _button.gameObject.SetActive(false);
}