using UnityEngine;

public class FallDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered!");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Fell!");

            other.transform.position = RespawnManager.respawnPoint;
        }
    }
}