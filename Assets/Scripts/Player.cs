using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Transform _head;

    private InputHandler _inputHandler;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputHandler = GetComponent<InputHandler>();
        _head = transform.Find("Head");
    }

    private void Update()
    {
        Aim();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Aim()
    {
        transform.LookAt(new Vector3(_inputHandler.MousePosition.x, _head.position.y, _inputHandler.MousePosition.z));
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_inputHandler.HorizontalInput * _speed, _rigidbody.velocity.y, _inputHandler.VerticalInput * _speed);
    }
}
