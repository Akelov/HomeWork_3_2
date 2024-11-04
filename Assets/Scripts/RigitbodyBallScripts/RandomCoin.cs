using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoin : Coin
{
    [SerializeField] private int _maxValue = 10;
    [SerializeField] private int _minValue = 1;

    public override int GetValue()
    {
        return Random.Range(_minValue, _maxValue);
    }
}
