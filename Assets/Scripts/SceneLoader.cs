using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Text LoadingPercentage;
    public Image LoadingProgressBar;

    private static SceneLoader instance;
    private static bool shouldPlayOpeningAnimation = false;

    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;

<<<<<<< HEAD
    private bool isLoadingScene;

    private Animator anim;

    public void Load()
    {
        anim.SetTrigger("loading");
    }

    public void scene()
    {
        SceneManager.LoadScene(Random.Range(1, 2));
=======
    public static void SwitchToScene(int sceneName)
    {
        instance.componentAnimator.SetTrigger("sceneClosing");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);

        // ����� ����� �� ������ ������������� ���� ������ �������� closing:
        instance.loadingSceneOperation.allowSceneActivation = false;

        instance.LoadingProgressBar.fillAmount = 0;
    }

    private void Start()
    {
        instance = this;

        componentAnimator = GetComponent<Animator>();

        if (shouldPlayOpeningAnimation)
        {
            componentAnimator.SetTrigger("sceneOpening");
            instance.LoadingProgressBar.fillAmount = 1;

            // ����� ���� ��������� ������� ����� ������� SceneManager.LoadScene, �� ����������� �������� opening:
            shouldPlayOpeningAnimation = false;
        }
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            LoadingPercentage.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";

            // ������ ��������� ��������:
            //LoadingProgressBar.fillAmount = loadingSceneOperation.progress; 

            // ��������� �������� � ������� ���������, ����� ��������� �������:
            LoadingProgressBar.fillAmount = Mathf.Lerp(LoadingProgressBar.fillAmount, loadingSceneOperation.progress,
                Time.deltaTime * 5);
        }
>>>>>>> parent of 17c86cb (shit)
    }

    public void OnAnimationOver()
    {
<<<<<<< HEAD
        instance = this;
        anim = GetComponent<Animator>();
        anim.SetTrigger("enter");
=======
        // ����� ��� �������� �����, ���� �� �������������, ����������� �������� opening:
        shouldPlayOpeningAnimation = true;

        loadingSceneOperation.allowSceneActivation = true;
>>>>>>> parent of 17c86cb (shit)
    }
}