using UnityEngine;
using YG;

public class AuthWindow : MonoBehaviour
{
    public void Register() => YandexGame.Instance._OpenAuthDialog();
}
