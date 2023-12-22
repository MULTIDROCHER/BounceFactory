using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public int Level = 1;
    public int Balance;
    public int Score => ScoreCounter.Instance.GlobalScore;
}

public class Progress : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerInfoText;
    public static Progress Instance;

    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")] private static extern void SaveExtern(string date);

    [DllImport("__Internal")] private static extern void LoadExtern();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

#if UNITY_WEBGL
            LoadExtern();
#endif
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LevelCompleted()
    {
        PlayerInfo.Level++;
        PlayerInfo.Balance = ScoreCounter.Instance.Score;

#if UNITY_WEBGL
        Save();
#endif

    }

    public void Restart()
    {
        PlayerInfo.Level = 1;
        PlayerInfo.Balance = 0;
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void Load(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        _playerInfoText.text = PlayerInfo.Level + "\n" + PlayerInfo.Balance + "\n" + PlayerInfo.Score;
    }
}
