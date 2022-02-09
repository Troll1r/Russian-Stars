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

    private Animator anim;

    public void Load()
    {
        anim.SetTrigger("loading");
    }

    public void scene()
    {
        SceneManager.LoadScene(Random.Range(1, 2));
    }

    private void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        anim.SetTrigger("enter");
    }
}