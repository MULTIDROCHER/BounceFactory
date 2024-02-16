using System;
using BounceFactory.ScoreSystem;
using BounceFactory.System.DataSending;
using BounceFactory.UI;
using UnityEngine;

namespace BounceFactory.System.Game
{
    public class LevelExitEvent : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private ReviewSender _reviewSender;
        [SerializeField] private ScoreSender _scoreSender;
        [SerializeField] private ScoreOperations _scoreOperations;

        public event Action LevelExited;

        public LoadingScreen LoadingScreen => _loadingScreen;

        public void ExitLevel()
        {
            _scoreOperations.ReturnSpent();
            _scoreSender.RewriteLeaderboardScore();
            _reviewSender.ShowReview();

            LevelExited?.Invoke();
        }
    }
}