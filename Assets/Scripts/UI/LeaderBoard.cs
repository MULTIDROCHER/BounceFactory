using UnityEngine;
using YG;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private AuthorizationWindow _authorizationWindow;

    private void OnEnable()
    {
        if (YandexGame.auth)
            _authorizationWindow.gameObject.SetActive(false);
    }
}