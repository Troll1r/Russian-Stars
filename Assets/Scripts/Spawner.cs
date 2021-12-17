using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _zombie;
    [SerializeField] private List<GameObject> _zombies;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _waves;
    [SerializeField] private Image _progressBar;

    private void Awake()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        float maxWawes = _waves;
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            GameObject _currentZombie = Instantiate(_zombie, _spawnPoints[i].position, _spawnPoints[i].rotation);
            _zombies.Add(_currentZombie);
        }

        _waves--;

        while (IsFull(_zombies))
        {
            yield return null;
        }

        if (_waves > 0)
        {
            _zombies.Clear();
            _progressBar.fillAmount = _waves / maxWawes;
            StartCoroutine(SpawnWave());
        }
    }

    private bool IsFull(List<GameObject> zomb)
    {
        int fullObj = 0;

        for (int i = 0; i < zomb.Count; i++)
        {
            if (zomb[i] != null)
            {
                fullObj++;
            }
        }

        if (fullObj > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}