using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


// Для того, чтобы менялась надпись, она должны быть задана в правильном формате

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }
    
    protected TextMeshProUGUI textLoader;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Debug.Log("Был создан еще один   класс синглотона, удален " + gameObject.name);
        Destroy(gameObject);
    }

    public void LoadScene(string loadableScene, string loadingScene, string[] unloadableScenes = null)
    {
        StartCoroutine(Load(loadableScene, loadingScene, unloadableScenes));
    }

    IEnumerator Load(string loadableScene, string loadingScene, string[] unloadableScenes)
    {
        yield return LoadableAscync(unloadableScenes, loadableScene);
        textLoader = GameObject.Find("TextLoader").GetComponentInChildren<TextMeshProUGUI>();
        yield return LoadingAscync(loadableScene, loadingScene);
    }

    IEnumerator LoadableAscync(string[] unloadableScenes, string loadableScene)
    {
        var loadSceneAsync = SceneManager.LoadSceneAsync(loadableScene);
        while (!loadSceneAsync.isDone)
        {
            yield return null;
        }

        if (unloadableScenes != null)
            foreach (var unloadableScene in unloadableScenes)
            {
                SceneManager.UnloadSceneAsync(unloadableScene);
            }
    }

    IEnumerator LoadingAscync(string loadableScene, string loadingScene)
    {
        var f = SceneManager.LoadSceneAsync(loadingScene, LoadSceneMode.Additive);
        f.allowSceneActivation = false;
        while (!f.isDone)
        {
            if (f.progress >= 0.90f && !f.allowSceneActivation)
            {
                textLoader.text = "Press Any Button to Continue";
                if (Input.anyKeyDown)
                    f.allowSceneActivation = true;
            }
            else
            {
                textLoader.text = "Loading... ";// + f.progress * 100 + "%";
            }
            Debug.Log("Loading " + f.progress * 100);
            yield return null;
        }

        SceneManager.UnloadSceneAsync(loadableScene);
    }
}