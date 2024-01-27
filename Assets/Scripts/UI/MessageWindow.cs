using UnityEngine;
using UnityEngine.UI;
using YG;

public class MessageWindow : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    private void Awake()
    {
        if (_toggle != null)
        {
            _toggle.isOn = YandexGame.savesData.HideSaveMessage;

            if (_toggle.isOn)
                Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        if (_toggle != null && _toggle.isOn)
            DontShowAgain();
    }

    public void DontShowAgain()
    {
        YandexGame.savesData.HideSaveMessage = true;
        YandexGame.Instance._SaveProgress();
    }
}