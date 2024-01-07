using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    public static LoadingScreen Instance;

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
