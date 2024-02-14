using System;
using System.Collections;
using System.Collections.Generic;
using BounceFactory.BaseObjects;
using BounceFactory.BaseObjects.BallComponents;
using BounceFactory.BaseObjects.ItemComponents;
using BounceFactory.Logic.Selling;
using BounceFactory.Playground.Storage.Holder;
using BounceFactory.System.Game;
using BounceFactory.System.Game.SoundSystem;
using BounceFactory.Tutorial;
using DG.Tweening;
using UnityEngine;

namespace BounceFactory.Logic
{
    [RequireComponent(typeof(ColorChanger))]
    [RequireComponent(typeof(EffectApplier))]
    [RequireComponent(typeof(MergeButtonController))]
    public class BallMerger : MonoBehaviour, ITutorialEvent
    {
        private readonly float _duration = 2;

        [SerializeField] private BallPriceChanger _seller;
        [SerializeField] private LevelSwitcher _levelSwitcher;

        private MergeButtonController _buttonController;
        private BallMatchesSeeker _matchesSeeker;
        private Holder<Ball> _holder;
        private ColorChanger _colorChanger;
        private EffectApplier _effectApplier;
        private WaitForSeconds _wait;

        public event Action Performed;
        public event Action<List<Ball>> MatchFounded;
        public event Action MatchLosted;

        public MergeButton Button => _buttonController.Button;

        private void Start()
        {
            _colorChanger = GetComponent<ColorChanger>();
            _effectApplier = GetComponent<EffectApplier>();
            _buttonController = GetComponent<MergeButtonController>();
            _matchesSeeker = new ();

            _wait = new (_duration);
        }

        private void OnEnable()
        {
            _levelSwitcher.LevelChanged += SetHolder;
            _seller.BallDestroyed += OnBallsAmountChanged;
        }

        private void OnDisable()
        {
            _levelSwitcher.LevelChanged -= SetHolder;
            _seller.BallDestroyed -= OnBallsAmountChanged;
        }

        public void Merge(List<Ball> balls)
        {
            MatchLosted?.Invoke();
            StartCoroutine(PrepareToMerge(balls));
            Performed?.Invoke();
        }

        private void FindMatches()
        {
            var match = _matchesSeeker.GetMatch(_holder);

            if (match != null)
            {
                MatchFounded?.Invoke(match);
                return;
            }

            MatchLosted?.Invoke();
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
            SoundManager.PlayOneShot(Sound.BallMerge);

            ball.ChangeColor(_colorChanger.GetColorByLevel(ball));
            ball.LevelUp();
            ball.Collider.enabled = true;
        }

        private void SetHolder()
        {
            if (_holder != null)
                _holder.ChildAdded -= OnBallsAmountChanged;

            _holder = _levelSwitcher.CurrentLevel.BallData.BallHolder;
            _holder.ChildAdded += OnBallsAmountChanged;
            OnBallsAmountChanged();
        }

        private void OnBallsAmountChanged()
        {
            if (_holder.Contents.Count >= _matchesSeeker.RequiredAmount)
                FindMatches();
            else
                MatchLosted?.Invoke();
        }
    }
}