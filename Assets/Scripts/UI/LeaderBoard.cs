using UnityEngine;
using YG;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] AuthWindow _authWindow;

    private void OnEnable()
    {
        if (YandexGame.auth)
            _authWindow.gameObject.SetActive(false);
    }
}