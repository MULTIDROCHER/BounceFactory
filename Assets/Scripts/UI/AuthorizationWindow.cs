using UnityEngine;
using YG;

public class AuthorizationWindow : MonoBehaviour
{
    public void Register() => YandexGame.Instance._OpenAuthDialog();
}