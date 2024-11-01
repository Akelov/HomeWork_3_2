using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotationSpeed;

    private Camera _camera;
    private Vector3 _offset = new Vector3(0, 3, -5);

    private void Awake()
    {
    _camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        MoveCamera();
        RotateCamera();
    }

    private void RotateCamera()
    {
        Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * _rotationSpeed, Vector3.up);

        _offset = camTurnAngle * _offset;

        _camera.transform.LookAt(_target);
    }

    private void MoveCamera()
    {
        _camera.transform.position = _target.position + _offset;
    }
}
