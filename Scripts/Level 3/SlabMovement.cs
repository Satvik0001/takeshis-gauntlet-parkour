using UnityEngine;

public class SlabMovement : MonoBehaviour
{
    public float moveDistance = 5f;
    public float speed = 2f;
    public float delay = 0f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float x = Mathf.Sin((Time.time - delay) * speed) * moveDistance;
        transform.position = startPosition + new Vector3(x, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}