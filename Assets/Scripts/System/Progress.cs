using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using YG;

public class Progress : MonoBehaviour
{
    public int Level = 1;
    public int Balance;

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
        Balance = ScoreCounter.Instance.Balance;
        Level++;
        //YandexGame.savesData.Level++;
        //YandexGame.savesData.Balance = ScoreCounter.Instance.Balance;
        //YandexGame.SaveProgress();
    }

    public void Restart()
    {
        Balance = 0;
        Level = 1;
        //YandexGame.savesData.Level = 1;
        //YandexGame.savesData.Balance = 0;
    }
}