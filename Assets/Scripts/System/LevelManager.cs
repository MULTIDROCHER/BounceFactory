using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private GameObject _endhWindow;
    private ProgressBar _progress;
    public int LevelGoal { get; private set; }

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

        _progress = FindObjectOfType<ProgressBar>();
    }

    private void OnEnable()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int[] values = (int[])Enum.GetValues(typeof(LevelGoals));

        LevelGoal = values[sceneIndex - 1];


        _progress.GoalRiched += OnGoalRiched;
    }

    private void OnDisable()
    {
        _progress.GoalRiched -= OnGoalRiched;
    }

    private void OnGoalRiched()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;

        if (index < SceneManager.sceneCountInBuildSettings)
            _finishWindow.SetActive(true);
        else
            _endhWindow.SetActive(true);
    }
}
