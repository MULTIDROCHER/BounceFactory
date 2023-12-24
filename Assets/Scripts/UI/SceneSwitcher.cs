using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class SceneSwitcher : MonoBehaviour
{
    public void BackToMainMenu(){
        YandexGame.SaveProgress();
        LoadingScreen.Instance.LoadScene(0);
    }

    public void StartGame()
    {
        if (YandexGame.savesData.Level >= SceneManager.sceneCountInBuildSettings)
            RestartGame();
        else
            NextLevel();
    }

    public void RestartGame()
    {
        Progress.Instance.Restart();
        StartGame();
    }

    public void NextLevel()
    {
        LoadingScreen.Instance.LoadScene(YandexGame.savesData.Level);
    }
}