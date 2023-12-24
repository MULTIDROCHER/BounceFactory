using UnityEngine;
using UnityEngine.UI;
using YG;

public class RateButton : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(YandexGame.EnvironmentData.reviewCanShow);
    }
}