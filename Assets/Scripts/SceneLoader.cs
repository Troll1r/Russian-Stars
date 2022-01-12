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

    public IEnumerator SwitchToScene(int sceneName)
    {       
        for (int i = 0; i < 100; i++)
        {
            LoadingPercentage.gameObject.SetActive(true);
            LoadingProgressBar.gameObject.SetActive(true);

            LoadingPercentage.text = i + "%";
            LoadingProgressBar.fillAmount = Mathf.Lerp(LoadingProgressBar.fillAmount, i / 1000,
                Time.deltaTime * 5);

            yield return new WaitForFixedUpdate();
        }

        LoadingPercentage.gameObject.SetActive(false);
        LoadingProgressBar.gameObject.SetActive(false);

        SceneManager.LoadScene(sceneName);
    }

    public void Load(int i)
    {
        StartCoroutine(SwitchToScene(i));
    }

    private void Start()
    {
        instance = this;
    }
}
