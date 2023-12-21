using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    public static Language Instance;
    public static string CurrentLanguage;

    [DllImport("_Internal")]
    private static extern string GetLang();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            CurrentLanguage = GetLang();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}