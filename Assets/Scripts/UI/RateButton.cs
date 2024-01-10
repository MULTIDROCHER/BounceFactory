using UnityEngine;
using YG;

public class RateButton : MonoBehaviour
{
    [SerializeField] private AuthWindow _authWindow;

    private void OnEnable()
    {
        if (YandexGame.EnvironmentData.reviewCanShow == false)
            gameObject.SetActive(false);
    }

    public void TryToRate()
    {
        if (YandexGame.auth == false)
            _authWindow.gameObject.SetActive(true);
        else
            YandexGame.ReviewShow(true);
    }

    public void OnRated()
    {
        YandexGame.savesData.ReviewLeft = true;
    }
}