using UnityEngine;
using YG;

public class RateButton : MonoBehaviour
{
    [SerializeField] private AuthWindow _authWindow;
    [SerializeField] private GameObject _ratedWindow;

    private void OnEnable()
    {
        if (YandexGame.EnvironmentData.reviewCanShow == false || YandexGame.savesData.ReviewLeft)
            gameObject.SetActive(false);
    }

    public void TryToRate()
    {
        if (YandexGame.auth == false)
            _authWindow.gameObject.SetActive(true);
        else if (YandexGame.EnvironmentData.reviewCanShow == false)
            _ratedWindow.SetActive(true);
        else
            YandexGame.ReviewShow(true);
    }

    public void OnRated() => YandexGame.savesData.ReviewLeft = true;
}