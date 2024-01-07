using UnityEngine;
using YG;

public class RateButton : MonoBehaviour
{
    private void Awake() => gameObject.SetActive(YandexGame.EnvironmentData.reviewCanShow);
}