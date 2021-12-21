using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _waveModeLevels;
    [SerializeField] private mode _mode;
    private enum mode
    {
        WAVEMODE,
        PROTECTIONMODE
    }


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        switch (_mode)
        {
            case mode.WAVEMODE:
                Instantiate(_waveModeLevels[Random.Range(0, _waveModeLevels.Length)], 
                    Vector3.zero, Quaternion.identity);
                break;
        }
    }
}
