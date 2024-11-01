using System.Collections.Generic;
using UnityEngine;

public class Barbarian : MonoBehaviour
{
    private float MinDistanceToTarget = 0.05f;
    private float ZeroSpeed = 0.0f;
    private string MoveKey = "Move";

    [SerializeField] private List<Transform> _targets;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed = 1400f;
    private float _cashSpeed;
    private float _cashRotationSpeed;

    private Queue<Vector3> _targetPosition;
    private Queue<Vector3> _cashTargetPosition;
    private Vector3 _currentTarget;
    private Vector3 _lastPosition;
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Awake()
    {
        _targetPosition = new Queue<Vector3>();

        foreach (Transform target in _targets)
        {
            _targetPosition.Enqueue(target.position);
        }

        _currentTarget = _targetPosition.Dequeue();

        _startPosition = transform.position;

        _startRotation = transform.rotation;

        _lastPosition = transform.position;

        _cashSpeed = _speed;

        _cashRotationSpeed = _rotationSpeed;
    }

    private void Update()
    {
        DoMove();

        EnableRunningAnimation();
    }

    private void EnableRunningAnimation()
    {
        _animator.SetFloat(MoveKey, _speed);
    }

    private void DoMove()
    {
        Vector3 direction = _currentTarget - transform.position;

        Vector3 normalizedDirection = direction.normalized;

        ProcessMoveTo(normalizedDirection);

        ProcessRotateTo(normalizedDirection);

        if (direction.magnitude <= MinDistanceToTarget)
            SwitchTarget();
    }

    private void ProcessMoveTo(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;

        _lastPosition = transform.position;
    }

    private void ProcessRotateTo(Vector3 direction)
    {
        Quaternion lookRotate = Quaternion.LookRotation(direction);

        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotate, step);
    }

    private void SwitchTarget()
    {
        _targetPosition.Enqueue(_currentTarget);

        _currentTarget = _targetPosition.Dequeue();
    }

    public void StopBarbarianMovement()
    {
        _speed = ZeroSpeed;

        _rotationSpeed = ZeroSpeed;
    }

    public void SetRestartBarbarian()
    {
        transform.position = _startPosition;

        transform.rotation = _startRotation;

        _speed = _cashSpeed;

        _rotationSpeed = _cashRotationSpeed;
    }
}
