using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            BackToMainMenu();

        if (Input.GetKeyDown(KeyCode.W))
            StartGame();
    }

    public void BackToMainMenu() => SceneManager.LoadScene(0);

    public void StartGame() => SceneManager.LoadScene(1);

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
    }

    public void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex +1;

        if (index < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(index);
    }
}