using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    public Transform topPoint;
    public Transform bottomPoint;

    public float speed = 2f;
    public float waitTime = 1f;

    private Transform target;
    private float waitCounter;

    void Start()
    {
        transform.position = bottomPoint.position;
        target = topPoint;
    }

    void Update()
    {
        if (waitCounter > 0)
        {
            waitCounter -= Time.deltaTime;
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            waitCounter = waitTime;

            if (target == topPoint)
                target = bottomPoint;
            else
                target = topPoint;
        }
    }
}