using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody _rigidbody;
    private float _zInput; 
    private float _xInput;
    private float _deadzone = 0.05f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _zInput = Input.GetAxis("Vertical");
        _xInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        ProcessMove();
    }

    private void ProcessMove()
    {
        if (Mathf.Abs(_zInput) > _deadzone)
        {
            _rigidbody.AddForce(Vector3.forward * _speed * _zInput);
        }

        if (Mathf.Abs(_xInput) > _deadzone)
        {
            _rigidbody.AddForce(Vector3.right * _rotationSpeed * _xInput);
        }
    }
}
