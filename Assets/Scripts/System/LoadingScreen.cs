using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Instance;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        gameObject.SetActive(false);
    }

    public void LoadScene(int sceneId)
    {
        gameObject.SetActive(true);
        StartCoroutine(LoadAsync(sceneId));
    }

    private IEnumerator LoadAsync(int sceneId)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneId);

        while (async.isDone == false)
        {
            _slider.value = async.progress;

            yield return null;
        }

        gameObject.SetActive(false);
        StopAllCoroutines();
    }
}
