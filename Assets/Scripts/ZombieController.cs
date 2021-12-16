using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float _distance
    {
        get
        {
            return dist;
        }
        set
        {
            dist = value;

            if (_distance >= attackDistance)
            {
                _navMesh.enabled = true;
                _navMesh.destination = player.position * _stats.zombieSpeed;
            }
            else
            {
                _navMesh.enabled = false;

            }
        }
    }
    private float dist;
    [Header("Target")]
    [SerializeField] private Transform player;
    private NavMeshAgent _navMesh;


    [Space]
    [Header("Distance")]
    [SerializeField] private float attackDistance;
    
    [Header("ZombieStats")]
    [SerializeField] private ZombiesStats _stats;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();

        GetComponent<HP>()._health = _stats.hp;

        player = FindObjectOfType<PlayerController>().transform;
    }

    void FixedUpdate()
    {
        _distance = Vector3.Distance(player.position, transform.position);
    }
}
