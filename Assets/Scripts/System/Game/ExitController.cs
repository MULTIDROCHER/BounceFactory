using BounceFactory.Score;
using BounceFactory.UI;
using BounceFactory.System.DataSending;
using System;
using UnityEngine;

namespace BounceFactory.System.Game
{
    public class ExitController : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private ReviewSender _reviewSender;
        [SerializeField] private ScoreSender _scoreSender;

        public event Action OnLevelExit;

        public LoadingScreen LoadingScreen => _loadingScreen;

        public void ExitLevel()
        {
            ScoreCounter.Instance.ReturnSpent();
            _scoreSender.TryToRewriteLeaderboardScore();
            _reviewSender.TryShowReview();

            OnLevelExit?.Invoke();
        }
    }
}