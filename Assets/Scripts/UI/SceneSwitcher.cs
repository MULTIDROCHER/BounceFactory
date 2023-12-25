using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class SceneSwitcher : MonoBehaviour
{

    public void BackToMainMenu()
    {
        YandexGame.NewLeaderboardScores("LeaderBoardScore", ScoreCounter.Instance.GlobalScore);
        //FindObjectOfType<SaveData>().Save();
        LoadingScreen.Instance.LoadScene(0);
    }

    public void StartGame()
    {
        if (Progress.Instance.Level >= SceneManager.sceneCountInBuildSettings)
            RestartGame();
        else
            NextLevel();
    }

    public void RestartGame()
    {
        Progress.Instance.Restart();
       // YandexGame.ResetSaveProgress();
        //YandexGame.SaveProgress();
        StartGame();
    }

    public void NextLevel()
    {
        //LoadingScreen.Instance.LoadScene(YandexGame.savesData.Level);
        //YandexGame.Instance._LoadProgress();
        LoadingScreen.Instance.LoadScene(Progress.Instance.Level);
    }
}