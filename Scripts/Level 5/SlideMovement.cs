using UnityEngine;

public class SlideMovement : MonoBehaviour
{
    public float slideSpeed = 15f;

    private Rigidbody rb;
    private bool onSlide = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (onSlide)
        {
            rb.AddForce(Vector3.forward * slideSpeed, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slide"))
        {
            onSlide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Slide"))
        {
            onSlide = false;
        }
    }
}