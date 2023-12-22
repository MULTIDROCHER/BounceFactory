using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    public static Yandex Instance;

    [SerializeField] private TMP_Text _test;

    private string _userName = "Anonimus";

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

    private void Start()
    {
        _test.text = _userName;
    }

    public void Test() => Hello();

    public void SetName(string name)
    {
        _userName = name;
        _test.text = _userName;
    }

    public void RateButton() => RateGame();

    public bool IsRated(bool rated) => GameRated = rated;
}
