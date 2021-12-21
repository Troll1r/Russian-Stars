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
                _navMesh.destination = player.transform.position * _stats.zombieSpeed;
            }
            else
            {
                _navMesh.enabled = false;

                if (_canAttack)
                {
                    StartCoroutine(Damage());
                }
            }
        }
    }
    private float dist;
    private bool _canAttack = true;
    [Header("Target")]
    public PlayerController player;
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
    }

    private void FixedUpdate()
    {
        _distance = Vector3.Distance(player.transform.position, transform.position);
    }

    private IEnumerator Damage()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_stats.attackCooldawn);
        if (_distance < attackDistance)
        {
            player.GetDamage(_stats._damage);
        }
        _canAttack = true;
    }
}
