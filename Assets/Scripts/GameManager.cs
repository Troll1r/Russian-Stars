using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _waveModeLevels;
    public GameObject player;
    [HideInInspector] public int _mode;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        switch (_mode)
        {
            case 0:
                Instantiate(_waveModeLevels[Random.Range(0, _waveModeLevels.Length)], 
                    Vector3.zero, Quaternion.identity);
                break;
        }
    }
}

