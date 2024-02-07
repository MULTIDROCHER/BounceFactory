using System;
using BounceFactory.Score;
using BounceFactory.System.DataSending;
using BounceFactory.UI;
using UnityEngine;

namespace BounceFactory.System.Game
{
    public class LevelExitController : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private ReviewSender _reviewSender;
        [SerializeField] private ScoreSender _scoreSender;

        public event Action LevelExited;

        public LoadingScreen LoadingScreen => _loadingScreen;

        public void ExitLevel()
        {
            ScoreCounter.Instance.ReturnSpent();
            _scoreSender.RewriteLeaderboardScore();
            _reviewSender.ShowReview();

            LevelExited?.Invoke();
        }
    }
}