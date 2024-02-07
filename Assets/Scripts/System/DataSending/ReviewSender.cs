using UnityEngine;
using YG;

namespace BounceFactory.System.DataSending
{
    public class ReviewSender : MonoBehaviour
    {
        private readonly int _lowestLevelToReview = 2;

        public void ShowReview()
        {
            if (AbleToShow())
                YandexGame.ReviewShow(true);
        }

        private bool AbleToShow() => YandexGame.savesData.Level >= _lowestLevelToReview && YandexGame.EnvironmentData.reviewCanShow;
    }
}