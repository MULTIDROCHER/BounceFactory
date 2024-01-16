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

            SceneManager.LoadScene(0);
        }
    }

    public void StartGame() => LoadingScreen.Instance.LoadScene(1);

    public void RestartGame()
    {
        if (_messageWindow != null
        && (YandexGame.savesData.LevelScore != 0 || YandexGame.savesData.Level != 1))
        {
            _messageWindow.gameObject.SetActive(true);
        }
        else
        {
            var level = YandexGame.savesData.Level > YandexGame.savesData.PreviousLevel ? 
            YandexGame.savesData.Level : YandexGame.savesData.PreviousLevel;

            YandexGame.Instance._ResetSaveProgress();
            YandexGame.savesData.PreviousLevel = level;
            YandexGame.Instance._SaveProgress();

            StartGame();
            Debug.Log(YandexGame.savesData.PreviousLevel + "LEVEL============================");
        }
    }

    public void NextLevel()
    {
        YandexGame.FullscreenShow();
        LevelManager.Instance.ChangeLevel();
    }
}