using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDetector : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    [SerializeField] private float _minDistanceToDetect;

    private void Update()
    {
        Vector3 direction = _secondPoint.position - _firstPoint.position;

        float distance = direction.magnitude; //вместо того чтобы ручками считать теорему Пифагора, просто используем встроенную штукенцу, которая сама считает и возвращает
        if(distance < _minDistanceToDetect)
        {
            Debug.DrawLine(_firstPoint.position, _secondPoint.position, Color.red);
        }
        else
        {
            Debug.DrawLine(_firstPoint.position, _secondPoint.position, Color.green);
        }
    }
}
