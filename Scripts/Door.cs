using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isCorrect;

    private bool used = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (isCorrect)
        {
            if (used) return;

            used = true;

            GetComponent<Collider>().isTrigger = true;
        }
        else
        {
            other.transform.position = RespawnManager.respawnPoint;
        }
    }
}