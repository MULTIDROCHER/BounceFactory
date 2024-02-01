using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BounceFactory;
using DG.Tweening;
using UnityEngine;

namespace BounceFactory
{
    [RequireComponent(typeof(ColorChanger))]
    [RequireComponent(typeof(EffectApplier))]
    public class BallMerger : MonoBehaviour, ITutorialEvent
    {
        [SerializeField] private BallPriceChanger _seller;
        [SerializeField] private MergeButton _button;

        private readonly int _requiredAmount = 3;
        private readonly float _duration = 2;

        private Holder<Ball> _holder /* => ActiveComponentsProvider.BallHolder */;
        private ColorChanger _colorChanger;
        private EffectApplier _effectApplier;

        public event Action Performed;

        public MergeButton Button => _button;

        private void Start()
        {
            _colorChanger = GetComponent<ColorChanger>();
            _effectApplier = GetComponent<EffectApplier>();
        }

        private void OnEnable()
        {
            ActiveComponentsProvider.LevelChanged += SetHolder;
            _seller.BallDestroyed += OnBallsAmountChanged;
        }

        private void OnDisable()
        {
            ActiveComponentsProvider.LevelChanged -= SetHolder;
            _seller.BallDestroyed -= OnBallsAmountChanged;
        }

        private void TryFindMatches()
        {
            List<Ball> balls = _holder.Contents.ToList();
            int maxLevel = balls.Max(ball => ball.Level);

            for (int level = maxLevel; level > 0; level--)
            {
                List<Ball> matchingBalls = balls.FindAll(ball => ball != null && ball.Level == level);

                Debug.Log($"merger find {matchingBalls.Count} matches for level {level}");
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
                ball.transform.DOMove(transform.position, _duration);
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

            _effectApplier.DoEffect(transform.position);
            ball.ChangeColor(_colorChanger.ChangeColor(ball));
            ball.LevelUp();
            ball.Collider.enabled = true;
            _holder.UpdateContent();
        }

        private void ButtonOn(List<Ball> balls)
        {
            _button.gameObject.SetActive(true);
            _button.Button.onClick.AddListener(() => Merge(balls));
        }

        private void ButtonOff() => _button.gameObject.SetActive(false);

        private void SetHolder()
        {
            if (_holder != null)
                _holder.ChildAdded -= OnBallsAmountChanged;

            _holder = ActiveComponentsProvider.BallHolder;
            _holder.ChildAdded += OnBallsAmountChanged;
        }

        private void OnBallsAmountChanged()
        {
            //Debug.Log("before " + _holder.Contents.Count);
            //_holder.UpdateContent();
            Debug.Log("merger see " + _holder.Contents.Count);

            if (_holder.Contents.Count >= _requiredAmount)
                TryFindMatches();
            /* else
                ButtonOff(); */
        }
    }
}