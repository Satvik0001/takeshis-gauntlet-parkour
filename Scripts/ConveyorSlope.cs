using UnityEngine;

public class ConveyorSlope : MonoBehaviour
{
    public float conveyorSpeed = 2f;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position += -transform.forward * conveyorSpeed * Time.deltaTime;
        }
    }
}