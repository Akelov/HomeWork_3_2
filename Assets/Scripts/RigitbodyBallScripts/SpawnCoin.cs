using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        Instantiate(_coinPrefab, _spawnPoint.position, Quaternion.Euler(0,0,90), null);
    }
}