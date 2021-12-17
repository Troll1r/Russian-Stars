using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public float _health;
    private float _maxHP;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Transform _canvas;
    [SerializeField] private Vector3 _healthBarWatchAt;

    private void Awake()
    {
        _maxHP = _health;
    }

    private void FixedUpdate()
    {
        _canvas.transform.LookAt(transform.position + _healthBarWatchAt);
    }

    public void GetDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }

        _healthBar.fillAmount = _health / _maxHP;
    }
}
