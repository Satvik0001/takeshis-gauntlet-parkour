using UnityEngine;

public class PendulumSwing : MonoBehaviour
{
    [Header("Swing Settings")]
    public float maxAngle = 180f;      // Increase this for a wider swing
    public float speed = 1f;
    public float startAngleOffset = 0f; // Different start positions for each pendulum

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed + startAngleOffset) * maxAngle;

        transform.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}