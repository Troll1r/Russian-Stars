using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float bulletSpeed;
    [HideInInspector] public float bulletDamage;
    [HideInInspector] public float bulletLifeTime;
    [HideInInspector] public Vector3 direction;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, bulletLifeTime * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer != 6)
        {
            if (col.gameObject.layer == 7)
            {
                col.gameObject.GetComponent<HP>().GetDamage(bulletDamage);
            }

            Destroy(gameObject);
        }
    }
}
