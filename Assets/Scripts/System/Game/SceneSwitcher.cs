using BounceFactory.UI;
using BounceFactory.UI.Window;
using UnityEngine;
using YG;

namespace BounceFactory.System.Game
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private MessageWindow _messageWindow;
        [SerializeField] private LevelExitEvent _exitController;

        private LoadingScreen _loadingScreen;
        private ProgressSaver _progressSaver;

        private void Awake()
        {
            _loadingScreen = _exitController.LoadingScreen;
            _progressSaver = new ();
        }

        public void Exit()
        {
            if (_messageWindow != null && YandexGame.savesData.HideSaveMessage == false)
            {
                _messageWindow.gameObject.SetActive(true);
            }
            else
            {
                _exitController.ExitLevel();
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
                _progressSaver.Reset();
                StartGame();
            }
        }
    }
}