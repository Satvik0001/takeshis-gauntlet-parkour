using UnityEngine;
using System.Collections;

public class PunchGlove : MonoBehaviour
{
    public float punchHeight = 2f;
    public float punchSpeed = 8f;
    public float waitTime = 1.5f;

    public float pushForce = 15f;
    public float upwardForce = 8f;

    private Vector3 startPosition;
    private bool isPunching = false;

    void Start()
    {
        startPosition = transform.localPosition;
        StartCoroutine(PunchRoutine());
    }

    IEnumerator PunchRoutine()
    {
        while (true)
        {
            // Wait before punching
            yield return new WaitForSeconds(waitTime);

            // Punch Up
            isPunching = true;

            while (transform.localPosition.y < startPosition.y + punchHeight)
            {
                transform.localPosition += Vector3.up * punchSpeed * Time.deltaTime;
                yield return null;
            }

            // Stop damaging at the top
            isPunching = false;

            yield return new WaitForSeconds(0.15f);

            // Move Down
            while (transform.localPosition.y > startPosition.y)
            {
                transform.localPosition -= Vector3.up * punchSpeed * Time.deltaTime;
                yield return null;
            }

            transform.localPosition = startPosition;
        }
    }

   private void OnCollisionStay(Collision collision)
{
    if (!isPunching)
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

        isPunching = false; // Prevent multiple launches during the same punch
    }
}
}