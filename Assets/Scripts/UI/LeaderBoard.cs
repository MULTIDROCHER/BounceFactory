using BounceFactory.UI.Window;
using UnityEngine;
using YG;

namespace BounceFactory.UI
{
    public class LeaderBoard : MonoBehaviour
    {
        [SerializeField] private AuthorizationWindow _authorizationWindow;

        private void OnEnable()
        {
            if (YandexGame.auth)
                _authorizationWindow.gameObject.SetActive(false);
        }
    }
}