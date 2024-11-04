using UnityEngine;

public abstract class Coin : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        RotateCoin();
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinCollector coinCollector = other.GetComponent<CoinCollector>();
        if(coinCollector != null)
        {
            coinCollector.AddCoin(GetValue());
            DestroyCoin();
        }
    }

    public abstract int GetValue();

    private void RotateCoin()
    {
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }

    public void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
