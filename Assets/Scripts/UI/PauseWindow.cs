using UnityEngine;
using UnityEngine.UI;
using YG;

public class PauseWindow : MonoBehaviour
{
    [SerializeField] private Button _rateButton;

    private void OnEnable()
    {
        Time.timeScale = 0;

        if (_rateButton != null)
            if (YandexGame.EnvironmentData.reviewCanShow)
                _rateButton.gameObject.SetActive(true);
            else
                _rateButton.gameObject.SetActive(false);
    }

    private void OnDisable() => Time.timeScale = 1;

    public void RateGame() => YandexGame.ReviewShow(YandexGame.EnvironmentData.reviewCanShow);
}
