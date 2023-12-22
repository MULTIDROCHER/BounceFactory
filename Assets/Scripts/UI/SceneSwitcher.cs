using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            BackToMainMenu();

        if (Input.GetKeyDown(KeyCode.W))
            StartGame();
    }

    public void BackToMainMenu() => SceneManager.LoadScene(0);

    public void StartGame() => SceneManager.LoadScene(Progress.Instance.PlayerInfo.Level);

    public void RestartetGame()
    {
        Progress.Instance.Restart();
        StartGame();
    }

    public void NextLevel()
    {
        Progress.Instance.LevelCompleted();
        SceneManager.LoadScene(Progress.Instance.PlayerInfo.Level);
    }
}