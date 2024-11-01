using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransformation : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 0.125f;

    private void Update()
    {
        MoveCameraBehindPlayer();
    }

    private void MoveCameraBehindPlayer()
    {
        Vector3 desiredPosition = _target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = desiredPosition;

        transform.LookAt(_target);
    }
}
