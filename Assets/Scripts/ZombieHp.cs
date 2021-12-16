using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHp : MonoBehaviour
{
    [SerializeField] private ZombiesStats _stats;


    
    public float _hp;

    public float damage;

    [SerializeField] private GameObject _zombie;


    void Start()
    {

        _hp = _stats.hp;
        damage = GetComponent<Bullet>().bulletDamage;

    }
    public void Update()
    {
        print(damage);
        Dying();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            _hp -= damage;
            print("hit");
        }
    }

    public void Dying()
    {
        if (_hp <= 0)
            Destroy(_zombie);

    }
}
