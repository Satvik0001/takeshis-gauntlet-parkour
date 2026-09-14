using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    public float fireForce = 20f;
    public float fireRate = 2f;

    void Start()
    {
        InvokeRepeating(nameof(FireBall), 0f, fireRate);
    }

    void FireBall()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);

        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(transform.forward * fireForce, ForceMode.Impulse);
        }

        Destroy(ball, 10f);
    }
}