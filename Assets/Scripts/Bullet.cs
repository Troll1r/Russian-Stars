using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float bulletSpeed;
    [HideInInspector] public float bulletDamage;
    [HideInInspector] public float bulletLifeTime;
    [HideInInspector] public Vector3 direction;

    public void Start()
    {
        bulletDamage = GetComponent<Weapons>().attackDamage;
    }
    private void FixedUpdate()
    {
        print(bulletDamage);
        transform.Translate(direction * bulletSpeed * Time.deltaTime, Space.World);
        Destroy(gameObject, bulletLifeTime * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer != 6)
        {
            print("wrg");
            Destroy(gameObject);
        }
    }
}
