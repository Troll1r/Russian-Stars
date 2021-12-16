using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _smooth = 0.3f;
    [SerializeField] private float _height;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 pos = new Vector3();
        pos.x = _player.position.x;
        pos.z = _player.position.z - 10f;
        pos.y = _player.position.y + _height;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, _smooth);
    }
}
