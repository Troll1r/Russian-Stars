using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerInputs inputs;
    [Header("BasicMovement")]
    [SerializeField] private float _speed;
    [SerializeField] private float _speedIncreasingTime;
    [SerializeField] private GameObject _mesh;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    private Vector3 _directionVector;
    [Space]
    [Header("Guns")]
    [SerializeField] private Gun _gun;
    private void Awake()
    {
        Application.targetFrameRate = 60;

        _characterController = GetComponent<CharacterController>();

        inputs = new PlayerInputs();
        inputs.Enable();
        inputs.Main.Shoot.canceled += x => Shooting();
    }

    private void FixedUpdate()
    {
        Move(inputs.Main.Movement.ReadValue<Vector2>(), inputs.Main.LookAround.ReadValue<Vector2>());
    }

    private void Move(Vector2 inputVector, Vector2 directionInputVector)
    {
        _directionVector = new Vector3(directionInputVector.x, 0, directionInputVector.y);
        if (inputVector != Vector2.zero)
        {
            _moveVector = Vector3.MoveTowards(_moveVector, new Vector3(inputVector.x * _speed, 0, inputVector.y * _speed), _speedIncreasingTime * Time.deltaTime);
        }
        else
        {
            _moveVector = Vector3.MoveTowards(_moveVector, Vector3.zero, _speedIncreasingTime * Time.deltaTime);
        }

        if (directionInputVector != Vector2.zero)
        {
            _mesh.transform.LookAt(transform.position + new Vector3(directionInputVector.x, 0, directionInputVector.y));
        }
        else
        {
            _mesh.transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.y));
        }

        _characterController.Move(_moveVector * _speed * Time.deltaTime);
    }

    private void Shooting()
    {
        if (_directionVector != Vector3.zero)
        {
            print("shoot " + _gun._bulletSpeed);
        }
    }
}
