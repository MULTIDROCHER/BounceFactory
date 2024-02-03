using UnityEngine;
using YG;

namespace BounceFactory.UI.Window
{
    public class AuthorizationWindow : MonoBehaviour
    {
        public void Register() => YandexGame.Instance._OpenAuthDialog();
    }
}