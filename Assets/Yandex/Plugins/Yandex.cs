using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    public static Yandex Instance;

    [SerializeField] private TMP_Text _test;

    public bool GameRated { get; private set; }

    [DllImport("__Internal")] private static extern void Hello();
    [DllImport("__Internal")] private static extern void RateGame();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Test() => Hello();

    public void SetName(string name) => _test.text = name;

    public void RateButton() => RateGame();

    public bool IsRated(bool rated) => GameRated = rated;
}
