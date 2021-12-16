using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Zombie", menuName = "Zombies", order = 49)]

public class ZombiesStats : ScriptableObject
{
    public string zombieName;

    public float zombieSpeed;
    public float zombieSpeedIncrreasingTime;

    public int hp;
}
