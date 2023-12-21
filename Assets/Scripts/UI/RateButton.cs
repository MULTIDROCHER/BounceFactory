using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RateButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        gameObject.SetActive(Yandex.Instance.GameRated);
    }
    
    private void OnEnable()
    {
        _button.onClick.AddListener(() => Yandex.Instance.RateButton());
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
}
