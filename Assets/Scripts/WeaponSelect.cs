using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    [SerializeField] private Text _currentWeapon;
    [SerializeField] private Weapons[] _weapons;
    [SerializeField] private GameManager _gameManager;

    public void LoadWeapon(int weaponNum)
    {
        _currentWeapon.text = _weapons[weaponNum].weaponName;
        _gameManager.player.GetComponentInChildren<PlayerController>()._weapon = _weapons[weaponNum];
    }
}
