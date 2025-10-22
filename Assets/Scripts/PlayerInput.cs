using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;

    public Transform upArrowTarget;
    public Transform downArrowTarget;
    public Transform leftArrowTarget;
    public Transform rightArrowTarget;

    public FlashBehavior upArrowFlash;  // Reference to the FlashBehavior on the Up Arrow
    public FlashBehavior downArrowFlash;  // Reference to the FlashBehavior on the Down Arrow
    public FlashBehavior leftArrowFlash;  // Reference to the FlashBehavior on the Left Arrow
    public FlashBehavior rightArrowFlash;  // Reference to the FlashBehavior on the Right Arrow

    public float hitWindow = 0.5f;  // How close the arrow needs to be to count as a hit

    void Update()
    {
        // Check for user input and hit detection
        if (Input.GetKeyDown(upKey))
        {
            CheckForHit(upArrowTarget, upArrowFlash);
        }
        else if (Input.GetKeyDown(downKey))
        {
            CheckForHit(downArrowTarget, downArrowFlash);
        }
        else if (Input.GetKeyDown(leftKey))
        {
            CheckForHit(leftArrowTarget, leftArrowFlash);
        }
        else if (Input.GetKeyDown(rightKey))
        {
            CheckForHit(rightArrowTarget, rightArrowFlash);
        }
    }

    void CheckForHit(Transform target, FlashBehavior flashBehavior)
    {
        // Check for any overlapping arrows within the hit window
        Collider2D[] hits = Physics2D.OverlapCircleAll(target.position, hitWindow);
        foreach (Collider2D hit in hits)
        {
            ArrowMovement arrow = hit.GetComponent<ArrowMovement>();
            if (arrow != null)
            {
                // Hit detected - Flash the UI Image and destroy the arrow
                flashBehavior.Flash();  // Trigger the flash on the arrow image
                Destroy(hit.gameObject);  // Destroy the arrow game object
            }
        }
    }
}
