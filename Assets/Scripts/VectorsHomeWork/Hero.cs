using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private string VelocityKey = "IsMove";
    private float ZeroConstant = 0.0f;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    private float _cashSpeed;
    private float _cashRotationSpeed;

    [SerializeField] CharacterController _characterController;
    [SerializeField] Animator _animator;
    [SerializeField] Transform _zeroWorldCoordinate;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Vector3 _currentDirection;
    private Vector3 _lastDirection;

    private float _deadzone = 0.1f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        _startPosition = transform.position;

        _startRotation = transform.rotation;

        _cashSpeed = _speed;

        _cashRotationSpeed = _rotationSpeed;

        _lastDirection = _lastDirection = _zeroWorldCoordinate.position - transform.position;
    }

    private void Update()
    {
        MoveCharacter();
    }

    private void EnableRunningAnimation()
    {
        if (_currentDirection.magnitude != _lastDirection.magnitude)
            _animator.SetBool(VelocityKey, true);
        else if(_currentDirection.magnitude == _lastDirection.magnitude)
            _animator.SetBool(VelocityKey, false);
    }

    private void MoveCharacter()
    {
        Vector3 input = PlayerInputToMove();

        if (input.magnitude <= _deadzone)
            return;

        ProcessMoveTo(input);

        ProcessRotateTo(input);
        
        EnableRunningAnimation();
    }

    private Vector3 PlayerInputToMove()
    {
        return new Vector3(InputHorizontalAxis(), 0, InputVerticalAxis());
    }

    private float InputHorizontalAxis()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    private float InputVerticalAxis()
    {
        return Input.GetAxisRaw("Vertical");
    }

    private void ProcessMoveTo(Vector3 direction)
    {
        _lastDirection = _currentDirection;

        _characterController.Move(direction.normalized * _speed * Time.deltaTime);

        _currentDirection = _zeroWorldCoordinate.position - transform.position;
    }

    private void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    public void StopHeroMovement()
    {
        _speed = ZeroConstant;

        _rotationSpeed = ZeroConstant;
    }

    public void SetRestartHero()
    {
        transform.position = _startPosition;

        transform.rotation = _startRotation;

        _speed = _cashSpeed;

        _rotationSpeed = _cashRotationSpeed;
    }
}
