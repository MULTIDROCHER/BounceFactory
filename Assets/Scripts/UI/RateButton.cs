using UnityEngine;
using YG;

namespace BounceFactory
{
    public class RateButton : MonoBehaviour
    {
        [SerializeField] private AuthorizationWindow _authorizationWindow;
        [SerializeField] private GameObject _ratedWindow;

        private void OnEnable()
        {
            if (YandexGame.EnvironmentData.reviewCanShow == false || YandexGame.savesData.ReviewLeft)
                gameObject.SetActive(false);
        }

        public void TryToRate()
        {
            if (YandexGame.auth == false)
                _authorizationWindow.gameObject.SetActive(true);
            else if (YandexGame.EnvironmentData.reviewCanShow == false)
                _ratedWindow.SetActive(true);
            else
                YandexGame.ReviewShow(true);
        }

        public void OnRated() => YandexGame.savesData.ReviewLeft = true;
    }
}