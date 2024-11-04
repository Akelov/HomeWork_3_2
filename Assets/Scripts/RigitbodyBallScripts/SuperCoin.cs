using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCoin : Coin
{
    [SerializeField] private int _value = 15;

    public override int GetValue()
    {
        return _value;  
    }
}
