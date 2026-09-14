using UnityEngine;

public class StepBlock : MonoBehaviour
{
    public bool isSafe = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (isSafe)
            return;

        rb.isKinematic = false;
    }
}