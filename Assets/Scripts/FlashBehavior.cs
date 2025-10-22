using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashBehavior : MonoBehaviour
{
    private Image arrowImage;  // Reference to the UI Image component
    private Color originalColor;  // The original color of the image

    public int numberOfFlashes = 5;  // Number of flashes
    public float flashInterval = 0.1f;  // Duration of each flash
    public float lowAlpha = 0.1f;  // The alpha value when flashing (low transparency)

    void Start()
    {
        // Get the Image component and store the original color (with full alpha)
        arrowImage = GetComponent<Image>();
        originalColor = arrowImage.color;  // Store the original color
    }

    // Public method to start the flashing effect
    public void Flash()
    {
        StartCoroutine(FlashImage());
    }

    // Coroutine to flash the image by toggling alpha values
    IEnumerator FlashImage()
    {
        for (int i = 0; i < numberOfFlashes; i++)
        {
            // Set the alpha to low (make it transparent)
            SetAlpha(lowAlpha);
            yield return new WaitForSeconds(flashInterval);

            // Set the alpha back to full (make it visible)
            SetAlpha(1f);
            yield return new WaitForSeconds(flashInterval);
        }

        // Ensure the final alpha is fully visible (original state)
        SetAlpha(1f);
    }

    // Helper function to change the alpha of the image
    private void SetAlpha(float alphaValue)
    {
        Color color = originalColor;  // Get the original color
        color.a = alphaValue;  // Set the alpha to the specified value
        arrowImage.color = color;  // Apply the new color with the adjusted alpha
    }
}
