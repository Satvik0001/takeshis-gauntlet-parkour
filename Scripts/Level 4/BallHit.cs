using UnityEngine;
using System.Collections;

public class BallHit : MonoBehaviour
{
    public float pushForce = 20f;
    public float upwardForce = 6f;

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

            StartCoroutine(BallHitCooldown());
        }
    }

    IEnumerator BallHitCooldown()
    {
        canPush = false;
        yield return new WaitForSeconds(0.3f);
        canPush = true;
    }
}