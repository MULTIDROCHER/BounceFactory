using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BounceFactory;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(EffectApplier))]
public class BallMerger : MonoBehaviour, ITutorialEvent
{
    [SerializeField] private BallSpawner _spawner;
    [SerializeField] private MergeButton _button;

    private readonly int _requiredAmount = 3;

    private Holder<Ball> _holder;
    private ColorChanger _colorChanger;
    private EffectApplier _effectApplier;
    private float _duration = 2;

    public event Action Performed;

    public MergeButton Button => _button;

    private void Start()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _effectApplier = GetComponent<EffectApplier>();
    }

    private void OnDisable() => _holder.ChildAdded -= OnBallSpawned;

    public void SetContainer(Holder<Ball> holder = null)
    {
        if (holder == null)
            _holder = FindFirstObjectByType<Holder<Ball>>();
        else
            _holder = holder;

        _holder.ChildAdded += OnBallSpawned;
    }

    private void OnBallSpawned()
    {
        if (_holder.Contents.Count >= _requiredAmount)
            TryFindMatches();
    }

    private void TryFindMatches()
    {
        List<Ball> balls = _holder.Contents.ToList();
        int maxLevel = balls.Max(ball => ball.Level);

        for (int level = maxLevel; level > 0; level--)
        {
            List<Ball> matchingBalls = balls.FindAll(ball => ball.Level == level);
            Debug.Log($"Found {matchingBalls.Count} balls with level {level}");

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
        foreach (var ball in balls)
        {
            ball.Collider.enabled = false;
            ball.transform.DOMove(_spawner.transform.position, _duration);
        }

        yield return new WaitForSeconds(_duration);

        var toUpgrade = balls[0];
        balls.Remove(toUpgrade);

        foreach (var ball in balls)
            Destroy(ball.gameObject);

        UpgradeOneBall(toUpgrade);
    }

    private void UpgradeOneBall(Ball ball)
    {
        StopAllCoroutines();

        _effectApplier.DoEffect(_spawner.transform.position);
        ball.ChangeColor(_colorChanger.ChangeColor(ball));
        ball.LevelUp();
        ball.Collider.enabled = true;
    }

    private void ButtonOn(List<Ball> balls)
    {
        _button.gameObject.SetActive(true);
        _button.Button.onClick.AddListener(() => Merge(balls));
    }

    private void ButtonOff() => _button.gameObject.SetActive(false);
}