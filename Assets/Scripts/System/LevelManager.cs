using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public int LevelGoal { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int[] values = (int[])Enum.GetValues(typeof(LevelGoals));

        LevelGoal = values[sceneIndex - 1];
    }
}
