using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicRigidbodyBall : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private float _timer;
    [SerializeField] private int _coinsToWin;

    private float _startTimer;
    private bool _isGameContinues;

    private void Awake()
    {
        _isGameContinues = true;
        _startTimer = _timer;
    }

    private void Update()
    {
        ChekInputs();

        if (_isGameContinues == false)
            return;

        UpdateTimer();

        ChecksConditionCompletionGame();
    }

    private void ChekInputs()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Restart();
    }

    private void ChecksConditionCompletionGame()
    {
        if (_timer <= 0)
            Lose();

        if (_coinCollector.Coins >= _coinsToWin)
            Win();
    }

    private void Restart()
    {
        _ball.RestartBall();
        _coinCollector.Restart();
        _timer = _startTimer;
        _isGameContinues = true;
        DestroyCoinsInScene();
        InitializeSpawnCoin();
    }

    private void DestroyCoinsInScene()
    {
        Coin[] coinCollector = FindObjectsOfType<Coin>();
        foreach (Coin coin in coinCollector)
        {
            coin.DestroyCoin();
        }
    }

    private void InitializeSpawnCoin()
    {
        SpawnCoin[] spawnCoinCollector = FindObjectsOfType<SpawnCoin>();
        foreach (SpawnCoin spawnCoin in spawnCoinCollector)
        {
            spawnCoin.Initialize();
        }
    }

    private void Win()
    {
        Debug.Log("Win");
        Debug.Log("Всего собрано монет: " + _coinCollector.Coins);
        _isGameContinues = false;
    }

    private void Lose()
    {
        Debug.Log("Lose");
        _isGameContinues = false;
        Debug.Log("Всего собрано монет: " + _coinCollector.Coins);
    }

    private void UpdateTimer()
    {
        _timer -= Time.deltaTime;

        Debug.Log(_timer);
    }
}
