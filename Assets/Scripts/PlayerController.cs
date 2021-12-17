using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    PlayerInputs inputs;
    [Header("BasicMovement")]

    private float _speed;
    private float _speedIncreasingTime;

    [SerializeField] private GameObject _mesh;

    private CharacterController _characterController;

    private Vector3 _moveVector;
    private Vector3 _directionVector;

    [Space]
    [Header("Guns")]
    [SerializeField] private Weapons _weapon;
    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private float _stickToShootOffset;
    private int _localMagazine;
    [Space]
    [Header("CharacterStats")]
    [SerializeField] private CharacterStats _stats;
    [Space]
    [Header("Camera")]
    [SerializeField] private Transform _cam;
    [Space]
    [Header("HealthAndDamage")]
    [SerializeField] private float _health;
    private float _maxHealth;
    [SerializeField] private Image _hpBar;
    private void Awake()
    {
        Application.targetFrameRate = 60;

        _characterController = GetComponent<CharacterController>();

        inputs = new PlayerInputs();
        inputs.Enable();
        inputs.Main.Shoot.canceled += x => Shooting();

        _speed = _stats.characterSpeed;
        _speedIncreasingTime = _stats.characterSpeedIncrreasingTime;
        _localMagazine = _weapon.magazine;
        _maxHealth = _health;
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
        if (_directionVector.magnitude > _stickToShootOffset && Time.time > _weapon.reloadTime && _localMagazine > 0)
        {
            GameObject _bulletSpawned = Instantiate(_weapon.bullet, _bulletSpawner.position, _bulletSpawner.rotation);
            Bullet _bulletCs = _bulletSpawned.GetComponent<Bullet>();

            _bulletCs.bulletSpeed = _weapon.bulletSpeed;
            _bulletCs.bulletDamage = _weapon.attackDamage;
            _bulletCs.bulletLifeTime = _weapon.bulletLifeTime;
            _bulletCs.direction = _bulletSpawner.forward;

            _localMagazine--;
        }
    }

    public void GetDamage(float damage)
    {
        _health -= damage;

        _hpBar.fillAmount = _health / _maxHealth;

        if (_health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
