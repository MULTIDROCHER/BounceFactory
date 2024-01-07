using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private MessageWindow _messageWindow;

    public void Exit()
    {
        if (_messageWindow != null && YandexGame.savesData.HideSaveMessage == false)
        {
            _messageWindow.gameObject.SetActive(true);
        }
        else
        {
            GameManager.Instance.LevelExit();
            LevelManager.Instance.OnLevelExit();
            YandexGame.Instance._SaveProgress();

            SceneManager.LoadScene(0);
        }
    }

    public void StartGame() => LoadingScreen.Instance.LoadScene(1);

    public void RestartGame()
    {
        if (_messageWindow != null )
        {
            _messageWindow.gameObject.SetActive(true);
        }
        else
        {
            YandexGame.Instance._ResetSaveProgress();
            YandexGame.Instance._SaveProgress();

            StartGame();
        }
    }

    public void NextLevel()
    {
        YandexGame.FullscreenShow();
        LevelManager.Instance.ChangeLevel();
    }
}