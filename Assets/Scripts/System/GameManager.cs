using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    public void TutorialPassed() => YandexGame.savesData.IsTrained = true;

    public void LevelExit()
    {
        if (YandexGame.savesData.PreviousLevel < YandexGame.savesData.Level)
        {
            YandexGame.savesData.PreviousLevel = YandexGame.savesData.Level;
            YandexGame.NewLeaderboardScores("LBLevel", YandexGame.savesData.PreviousLevel);
        }

        ScoreCounter.Instance.ReturnSpent();
    }
}