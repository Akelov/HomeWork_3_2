using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _starPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _starPosition = transform.position; 
    }

    public void RestartBall()
    {
        transform.position = _starPosition;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
