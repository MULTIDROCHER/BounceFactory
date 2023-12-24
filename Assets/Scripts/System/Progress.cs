using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using YG;

public class Progress : MonoBehaviour
{
    public static Progress Instance;

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

    public void LevelCompleted()
    {
        YandexGame.savesData.Level++;
        YandexGame.savesData.Balance = ScoreCounter.Instance.Balance;
        YandexGame.SaveProgress();
    }

    public void Restart()
    {
        YandexGame.savesData.Level = 1;
        YandexGame.savesData.Balance = 0;
    }
}