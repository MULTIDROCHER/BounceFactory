using System;
using UnityEngine;
using YG;

namespace BounceFactory
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private readonly int _lowestLevelToReview = 2;

        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private ProgressBar _progressBar;

        public event Action OnLevelExit;

        public LoadingScreen LoadingScreen => _loadingScreen;
        public ProgressBar ProgressBar => _progressBar;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                if (_progressBar != null)
                    DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void LevelExit()
        {
            ScoreCounter.Instance.ReturnSpent();
            TryToRewriteLeaderboardScore();
            TryShowReview();

            OnLevelExit?.Invoke();
        }

        private void TryToRewriteLeaderboardScore()
        {
            if (YandexGame.savesData.PreviousLevel < YandexGame.savesData.Level)
            {
                YandexGame.savesData.PreviousLevel = YandexGame.savesData.Level;
                YandexGame.NewLeaderboardScores("LBLevel", YandexGame.savesData.PreviousLevel);
            }
        }

        private void TryShowReview()
        {
            if (YandexGame.savesData.Level >= _lowestLevelToReview
                && YandexGame.EnvironmentData.reviewCanShow)
                YandexGame.ReviewShow(true);
        }
    }
}