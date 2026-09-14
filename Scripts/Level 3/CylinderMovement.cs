using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public float speed = 3f;

    private Transform target;

    public float pushForce = 12f;

    public float upwardForce = 2f;
    void Start()
    {
        transform.position = startPoint.position;
        target = endPoint;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            target = (target == endPoint) ? startPoint : endPoint;
        }
    }

private void OnCollisionStay(Collision collision)
{
    if (!collision.gameObject.CompareTag("Player"))
        return;

    Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

    if (rb != null)
    {
        Vector3 direction = (collision.transform.position - transform.position).normalized;
        direction.y = 0;

        rb.AddForce(direction * pushForce + Vector3.up * upwardForce, ForceMode.Impulse);
    }
}

}