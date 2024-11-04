using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CoinCollector : MonoBehaviour
{
    public int Coins { get; private set; }

    private void AddCoin(int value)
    {
        if (value < 0)
        {
            Debug.LogError("Монетка меньше нуля.");
            return;
        }

        Coins += value;
        Debug.Log("Coins: " + Coins);
    }

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            AddCoin(coin.Value);
        }
    }

    public void Restart()
    {
        Coins = 0;
    }
}
