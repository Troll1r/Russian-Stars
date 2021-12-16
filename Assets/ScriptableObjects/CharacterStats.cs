using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Characters", order = 50)]

public class CharacterStats : ScriptableObject
{
    public string characterName;

    public float characterSpeed;
    public float characterSpeedIncrreasingTime;

    public int hp;
}
