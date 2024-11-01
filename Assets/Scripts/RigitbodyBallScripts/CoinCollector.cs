using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int Coins { get; private set; }

    public void AddCoin(int value)
    {
        if (value < 0)
        {
            Debug.LogError("Монетка меньше нуля.");
            return;
        }

        Coins += value;
        Debug.Log("Coins: " + Coins);
    }

    public void Restart()
    {
        Coins = 0;
    }
}
