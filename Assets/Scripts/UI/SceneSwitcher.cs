using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _messageWindow;

    [SerializeField] private Toggle _showMessage;

    public void Exit()
    {
        if (_showMessage.isOn == false && _messageWindow != null)
        {
            _messageWindow.SetActive(true);
        }
        else
        {
            GameManager.Instance.LevelExit();
            LevelManager.Instance.OnLevelExit();
            YandexGame.Instance._SaveProgress();

            SceneManager.LoadScene(0);
        }
    }

    public void StartGame()
    {
        LoadingScreen.Instance.LoadScene(1);
    }

    public void RestartGame()
    {
        YandexGame.Instance._ResetSaveProgress();
        YandexGame.Instance._SaveProgress();

        StartGame();
    }

    public void NextLevel()
    {
        YandexGame.FullscreenShow();
        LevelManager.Instance.ChangeLevel();
    }
}