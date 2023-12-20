using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    public static Language Instance;
    public static string CurrentLanguage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            CurrentLanguage = GetLang();
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
    }

    [DllImport("_Internal")]
    private static extern string GetLang();
}
