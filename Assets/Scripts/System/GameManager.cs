using TMPro;
using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsTrained { get; private set; } = false;

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

    public void TutorialPassed()
    {
        IsTrained = true;
    }

    public void OnLevelExit()
    {
    }
}