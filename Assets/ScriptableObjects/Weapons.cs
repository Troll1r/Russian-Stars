using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons", order = 51)]
public class Weapons : ScriptableObject
{
    public string rangeOfDefeat;
    public string weaponName;
    public string ShootingMode;

    public float bulletSpeed;
    public float reloadTime;
    public float bulletLifeTime;

    public float attackDamage;
    public float spread;
    public float minSpread;
    public float perShotCooldawn;
    public int bulletCount;
    public int magazine;

    public GameObject bullet;

    public Sprite icon;


}
