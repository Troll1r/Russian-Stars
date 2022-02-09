using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject[] _menusObjects;

    private void Awake()
    {
        LoadMenu(0);
    }
    public void StartGame(int Mode) 
    {
<<<<<<< HEAD
        _sceneloader.Load();
=======
        _gameManager._mode = Mode;
        SceneLoader.SwitchToScene(1);
>>>>>>> parent of 17c86cb (shit)
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
