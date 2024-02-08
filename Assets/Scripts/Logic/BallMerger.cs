using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BounceFactory.BaseObjects;
using BounceFactory.BaseObjects.BallComponents;
using BounceFactory.BaseObjects.ItemComponents;
using BounceFactory.Logic.Selling;
using BounceFactory.Playground.Storage.Holder;
using BounceFactory.System.Level;
using BounceFactory.Tutorial;
using DG.Tweening;
using UnityEngine;

namespace BounceFactory.Logic
{
    [RequireComponent(typeof(ColorChanger))]
    [RequireComponent(typeof(EffectApplier))]
    public class BallMerger : MonoBehaviour, ITutorialEvent
    {
        [SerializeField] private BallPriceChanger _seller;
        [SerializeField] private BallsMergeButton _button;

        private readonly int _requiredAmount = 3;
        private readonly float _duration = 2;

        private Holder<Ball> _holder;
        private ColorChanger _colorChanger;
        private EffectApplier _effectApplier;
        private WaitForSeconds _wait;

        public event Action Performed;

        public BallsMergeButton Button => _button;

        private void Start()
        {
            _colorChanger = GetComponent<ColorChanger>();
            _effectApplier = GetComponent<EffectApplier>();

            _wait = new WaitForSeconds(_duration);
        }

        private void OnEnable()
        {
            BallComponentsProvider.LevelChanged += SetHolder;
            _seller.BallDestroyed += OnBallsAmountChanged;
        }

        private void OnDisable()
        {
            BallComponentsProvider.LevelChanged -= SetHolder;
            _seller.BallDestroyed -= OnBallsAmountChanged;
        }

        private void FindMatches()
        {
            var balls = _holder.Contents;
            int maxLevel = balls.Max(ball => ball.Level);

            for (int level = maxLevel; level > 0; level--)
            {
                var matchingBalls = balls.Where(ball => ball != null && ball.Level == level).ToList();

                if (matchingBalls.Count >= _requiredAmount)
                {
                    var taken = matchingBalls.GetRange(0, _requiredAmount);
                    EnableButton(taken);
                    return;
                }
            }

            DisableButton();
        }

        private void Merge(List<Ball> balls)
        {
            DisableButton();
            StartCoroutine(PrepareToMerge(balls));
            Performed?.Invoke();
        }

        private IEnumerator PrepareToMerge(List<Ball> balls)
        {
            foreach (var ball in balls)
            {
                if (ball != null)
                {
                    ball.Collider.enabled = false;
                    ball.transform.DOMove(transform.position, _duration);
                }
                else
                {
                    StopCoroutine(PrepareToMerge(balls));
                }
            }

            yield return _wait;

            var toUpgrade = balls[0];
            balls.Remove(toUpgrade);

            foreach (var ball in balls)
                Destroy(ball.gameObject);

            UpgradeOneBall(toUpgrade);
        }

        private void UpgradeOneBall(Ball ball)
        {
            StopAllCoroutines();

            _effectApplier.DoEffect(transform.position);
            ball.ChangeColor(_colorChanger.SetColorByLevel(ball));
            ball.LevelUp();
            ball.Collider.enabled = true;
        }

        private void EnableButton(List<Ball> balls)
        {
            _button.gameObject.SetActive(true);
            _button.Button.onClick.AddListener(() => Merge(balls));
        }

        private void DisableButton() => _button.gameObject.SetActive(false);

        private void SetHolder()
        {
            if (_holder != null)
                _holder.ChildAdded -= OnBallsAmountChanged;

            _holder = BallComponentsProvider.BallHolder;
            _holder.ChildAdded += OnBallsAmountChanged;
            OnBallsAmountChanged();
        }

        private void OnBallsAmountChanged()
        {
            if (_holder.Contents.Count >= _requiredAmount)
                FindMatches();
            else
                DisableButton();
        }
    }
}