using System.Collections.Generic;
using BounceFactory.BaseObjects;
using UnityEngine;

namespace BounceFactory.Logic
{
    [RequireComponent(typeof(BallMerger))]
    public class MergeButtonController : MonoBehaviour
    {
        [SerializeField] private MergeButton _button;

        private BallMerger _merger;

        public MergeButton Button => _button;

        private void Awake()
        {
            _merger = GetComponent<BallMerger>();

            _merger.MatchFounded += OnMatchFounded;
            _merger.MatchLosted += OnMatchLosted;
        }

        private void OnDestroy()
        {
            _merger.MatchFounded -= OnMatchFounded;
            _merger.MatchLosted -= OnMatchLosted;
        }

        private void OnMatchFounded(List<Ball> balls)
        {
            _button.gameObject.SetActive(true);
            _button.Button.onClick.AddListener(() => _merger.Merge(balls));
        }

        private void OnMatchLosted()
        {
            _button.gameObject.SetActive(false);
            _button.Button.onClick.RemoveAllListeners();
        }
    }
}