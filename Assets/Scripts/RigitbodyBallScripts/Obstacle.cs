using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _speedRotation;

    private void Update()
    {
        Rotator();
    }

    private void Rotator()
    {
        transform.Rotate(Vector3.left * _speedRotation * Time.deltaTime);
;   }
}
