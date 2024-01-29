using System;
using BounceFactory;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private MessageWindow _messageWindow;
    
    private LoadingScreen _loadingScreen => GameManager.Instance.LoadingScreen;

    public void Exit()
    {
        if (_messageWindow != null && YandexGame.savesData.HideSaveMessage == false)
        {
            _messageWindow.gameObject.SetActive(true);
        }
        else
        {
            GameManager.Instance.LevelExit();
            _loadingScreen.LoadScene(0);
        }
    }

    public void StartGame() => _loadingScreen.LoadScene(1);

    public void RestartGame()
    {
        if (_messageWindow != null
        && (YandexGame.savesData.LevelScore != 0 || YandexGame.savesData.Level != 1))
        {
            _messageWindow.gameObject.SetActive(true);
        }
        else
        {
            SavesController.ResetSavedProgress();
            StartGame();
        }
    }
}