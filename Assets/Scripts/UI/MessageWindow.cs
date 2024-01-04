using UnityEngine;
using UnityEngine.UI;
using YG;

public class MessageWindow : MonoBehaviour
{
    [SerializeField] private Toggle _hideMessage;

    private void Awake()
    {
        if (_hideMessage != null)
        {
            _hideMessage.isOn = YandexGame.savesData.HideSaveMessage;
            
            if (_hideMessage.isOn == true)
                Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        if (_hideMessage != null && _hideMessage.isOn)
        {
            YandexGame.savesData.HideSaveMessage = true;
            Destroy(gameObject);
        }
    }
}