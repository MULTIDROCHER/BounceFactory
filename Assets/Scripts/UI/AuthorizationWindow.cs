using UnityEngine;
using YG;

namespace BounceFactory
{
    public class AuthorizationWindow : MonoBehaviour
    {
        public void Register() => YandexGame.Instance._OpenAuthDialog();
    }
}