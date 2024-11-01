using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private float TimeToWin = 15;

    [SerializeField] private Hero _hero;
    [SerializeField] private Barbarian _barbarian;
    [SerializeField] private float _minDistanceToDeath = 10;
    [SerializeField] private float _timer;

    public bool IsEndGame { get; private set; } = false;

    private void Awake()
    {
        _timer = TimeToWin;
    }

    private void Start()
    {
        Debug.Log("��������� ����� � ��������, ���� ������ ����...");
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
            RestartGame();

        float distance = (_barbarian.transform.position - _hero.transform.position).magnitude;

        if (IsEndGame == true)
            return;

        Debug.Log($"������������ �� ������ ��� {_timer} ������!");

        if(_timer < 0)
            WinGame();

        if (distance > _minDistanceToDeath)
            EndGame();

    }

    private void EndGame()
    {
        Debug.Log("�� ���������");

        IsEndGame = true;

        StopEnvironment();
        RestartTimer();
    }

    private void RestartGame()
    {
        IsEndGame = false;

        RestartEnvironment();
        RestartTimer();
    }

    private void WinGame()
    {
        IsEndGame = true;

        StopEnvironment();
        RestartTimer();

        Debug.Log("�� ��������, ����������!");
    }

    private void StopEnvironment()
    {
        _hero.StopHeroMovement();
        _barbarian.StopBarbarianMovement();
    }

    private void RestartEnvironment()
    {
        _hero.SetRestartHero();
        _barbarian.SetRestartBarbarian();
    }

    private void RestartTimer()
    {
        _timer = TimeToWin;
    }
}
