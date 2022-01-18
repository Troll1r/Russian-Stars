using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private CharacterStats[] _stats;
    [SerializeField] private Weapons[] _weapons;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);    
    }

    public void LoadStats(int statNum)
    {
        player.GetComponent<PlayerController>()._stats = _stats[statNum];
    }

    public void LoadWeapon(int weaponNum)
    {
        player.GetComponent<PlayerController>()._weapon = _weapons[weaponNum];
    }
}
