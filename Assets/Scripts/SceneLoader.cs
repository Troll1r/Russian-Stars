using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Text LoadingPercentage;
    public Image LoadingProgressBar;

    private static SceneLoader instance;

    private AsyncOperation loadingSceneOperation;

    private bool isLoadingScene;

    public IEnumerator SwitchToScene(int sceneName)
    {
        isLoadingScene = true;

        loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        loadingSceneOperation.allowSceneActivation = false;

        LoadingPercentage.gameObject.SetActive(true);
        LoadingProgressBar.gameObject.SetActive(true);

        while(!loadingSceneOperation.isDone)
        {
            LoadingPercentage.text = (loadingSceneOperation.progress * 100) + "%";
            LoadingProgressBar.fillAmount = Mathf.Lerp(LoadingProgressBar.fillAmount, loadingSceneOperation.progress,
                Time.deltaTime * 5);

            print(loadingSceneOperation.progress);
            yield return null;
        }

        isLoadingScene = false;
        loadingSceneOperation.allowSceneActivation = true;

        LoadingPercentage.gameObject.SetActive(false);
        LoadingProgressBar.gameObject.SetActive(false);
    }

    public void Load(int i)
    {
        if (!isLoadingScene)
        {
            StartCoroutine(SwitchToScene(i));
        }
    }

    private void Start()
    {
        instance = this;
    }
}