using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 20f;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Reset only the vertical velocity so every bounce is consistent
            Vector3 velocity = rb.linearVelocity;
            velocity.y = 0f;
            rb.linearVelocity = velocity;

            // Bounce straight up
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}