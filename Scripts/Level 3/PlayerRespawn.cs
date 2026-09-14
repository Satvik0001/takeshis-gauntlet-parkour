using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float respawnHeight = 3f;

    void Update()
    {
        if (transform.position.y > respawnHeight)
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            transform.position = RespawnManager.respawnPoint;
        }
    }
}