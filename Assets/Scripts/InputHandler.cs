using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private float _horizontalInput;
    public float HorizontalInput => _horizontalInput;

    private float _verticalInput;
    public float VerticalInput => _verticalInput;

    private Vector3 _mousePosition;
    public Vector3 MousePosition => _mousePosition;

    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
