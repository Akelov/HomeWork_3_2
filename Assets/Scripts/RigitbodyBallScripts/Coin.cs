using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value = 1;
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        RotateCoin();
    }

    private void RotateCoin()
    {
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinCollector _coinCollector = other.GetComponent<CoinCollector>();

        if (_coinCollector != null)
        {
            _coinCollector.AddCoin(_value);
            DestroyCoin();
        }
    }

    public void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
