using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    public float pushForce = 10f;
    public float upwardForce = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;

                rb.AddForce((pushDirection + Vector3.up * 0.3f) * pushForce, ForceMode.Impulse);
            }
        }
    }
}