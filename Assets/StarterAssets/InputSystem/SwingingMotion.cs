using UnityEngine;

public class SwingingMotion : MonoBehaviour
{
    // These values control the swing in the Inspector
    public float swingAngle = 45f;    // Max angle the blade swings to (e.g., 45 degrees left and right)
    public float swingSpeed = 1.5f;  // How fast the blade moves (e.g., 1.5 cycles per second)

    // The starting rotation of the blade
    private Quaternion initialRotation;

    void Start()
    {
        // Store the original rotation of the object
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Use a sine wave to calculate a smooth value between -1 and 1
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;

        // Apply the rotation relative to the object's initial rotation
        transform.rotation = initialRotation * Quaternion.Euler(0, 0, angle);
    }
}