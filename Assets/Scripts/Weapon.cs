using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;

    private Transform _bulletSpawnObject;

    private InputHandler _inputHandler;
    
    void Start()
    {
        _inputHandler = GetComponent<InputHandler>();
        _bulletSpawnObject = transform.Find("Weapon");
    }

    void Update()
    {
        if(_inputHandler.HasPressedFire1)
        {
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(_bulletPrefab, _bulletSpawnObject.position, transform.rotation);
    }
}
