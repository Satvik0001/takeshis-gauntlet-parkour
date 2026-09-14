using UnityEngine;

public class BallPush : MonoBehaviour
{
    public float pushForce = 15f;
    public float upwardForce = 5f;

    private bool canPush = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (!canPush)
            return;

        if (!collision.gameObject.CompareTag("Player"))
            return;

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            direction.y = 0;

            rb.linearVelocity = Vector3.zero;
            rb.AddForce(direction * pushForce + Vector3.up * upwardForce, ForceMode.Impulse);

            StartCoroutine(PushCooldown());
        }
    }

    System.Collections.IEnumerator PushCooldown()
    {
        canPush = false;
        yield return new WaitForSeconds(0.3f);
        canPush = true;
    }
}