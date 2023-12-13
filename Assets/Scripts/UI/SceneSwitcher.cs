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
        
        if (Input.GetKeyDown(KeyCode.E))
        OpenTestScene();
    }

    public void BackToMainMenu() => SceneManager.LoadScene(0);

    public void StartGame() => SceneManager.LoadScene(1);

    public void OpenTestScene() => SceneManager.LoadScene(2);

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
    }
}