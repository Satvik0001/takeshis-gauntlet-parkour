using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static Vector3 respawnPoint;

    public Transform startPoint;

    void Start()
    {
        respawnPoint = startPoint.position;
    }
}