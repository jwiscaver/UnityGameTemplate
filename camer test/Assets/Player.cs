using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f; // Adjust the speed as needed

    void Update()
    {
        // Get the horizontal input (left/right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;

        // Move the player
        transform.Translate(movement);
    }
}
