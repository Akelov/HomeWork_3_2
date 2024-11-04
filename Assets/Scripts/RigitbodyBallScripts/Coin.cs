using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    public int Value { get; private set; } = 1;

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
        Ball ball = other.GetComponent<Ball>();
        if(ball != null)
        {
            DestroyCoin();
        }
    }

    public void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
