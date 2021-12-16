using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHp : MonoBehaviour
{
    [SerializeField] private ZombiesStats _stats;


    [SerializeField] private int _hp;

    [SerializeField] private GameObject _zombie;
   
    void Start()
    {
        _hp = _stats.hp;

        
    }
    public void Update()
    {
        Dying();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            _hp -= 1;
            print("hit");
        }
    }

    public void Dying()
    {
        if (_hp <= 0)
            Destroy(_zombie);

    }
}
