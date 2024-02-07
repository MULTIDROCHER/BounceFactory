using UnityEngine;
using YG;

namespace BounceFactory.System.DataSending
{
    public class ReviewSender : MonoBehaviour
    {
        private readonly int _lowestLevelToReview = 2;

        public void TryShowReview()
        {
            if (YandexGame.savesData.Level >= _lowestLevelToReview
                && YandexGame.EnvironmentData.reviewCanShow)
                YandexGame.ReviewShow(true);
        }
    }
}