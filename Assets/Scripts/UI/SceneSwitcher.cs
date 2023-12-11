using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    public void StartGame() => SceneManager.LoadScene(1);

    public void BackToMainMenu() => SceneManager.LoadScene(0);

    public void OpenTestScene() => SceneManager.LoadScene(2);

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
    }
}