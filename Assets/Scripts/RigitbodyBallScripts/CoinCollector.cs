using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CoinCollector : MonoBehaviour
{
    public int Coins { get; private set; }

    public void AddCoin(int value)
    {
        Coins += value;
        Debug.Log("Coins: " + Coins);
    }

    public void Restart()
    {
        Coins = 0;
    }
}
