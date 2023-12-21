using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public static Progress Instance;

    public int Level { get; private set; } = 1;
    public int Balance { get; private set; }
    public int Score => ScoreCounter.Instance.GlobalScore;

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
        Level++;
        Balance = ScoreCounter.Instance.Score;
        Debug.Log(Score);
    }

    public void Restart()
    {
        Level = 1;
        Balance = 0;
    }
}
