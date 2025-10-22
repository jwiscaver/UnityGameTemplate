using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    private float speed = 1f;  // Default speed, but will be overridden by the spawner
    private Transform targetPosition;  // The position this arrow will move towards

    void Update()
    {
        // If the target position is set, move towards it
        if (targetPosition != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

            // Destroy the arrow if it reaches the target
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
            {
                //Destroy(gameObject);
            }
        }
    }

    // Set the movement speed for this arrow
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // Set the target position for the arrow to move towards
    public void SetTarget(Transform newTarget)
    {
        targetPosition = newTarget;
    }
}