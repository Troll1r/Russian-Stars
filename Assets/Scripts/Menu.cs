using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject[] _menusObjects;
    [SerializeField] private SceneLoader _sceneloader;
    private void Awake()
    {
        LoadMenu(0);
    }
    public void StartGame(int Mode) 
    {
        _gameManager._mode = Mode;
        _sceneloader.Load(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMenu(int menuNum)
    {
        for (int i = 0; i < _menusObjects.Length; i++)
        {
            if (i == menuNum)
            {
                _menusObjects[i].SetActive(true);
            }
            else
            {
                _menusObjects[i].SetActive(false);
            }
        }
    }
}
