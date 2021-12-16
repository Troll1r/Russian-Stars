using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float _distance;
    [Header("Target")]
    public Transform player;

    [Space]
    [Header("Distance")]
    public float attackDistance;
    
    [Header("ZombieStats")]
    [SerializeField] private ZombiesStats _stats;

    void Update()
    {
        _distance = Vector3.Distance(player.position, transform.position);
        if (_distance >= attackDistance)
        {
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<NavMeshAgent>().destination = player.position * _stats.zombieSpeed;
        }
        else 
        {
            GetComponent<NavMeshAgent>().enabled = false;
        }
        
    }
}
