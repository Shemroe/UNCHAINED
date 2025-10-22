using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public Vector3 openPositionOffset = new Vector3(0, 5, 0);
    private bool isLocked = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isLocked)
        {
            if (GameManager.hasDungeonKey)
            {
                // Logic that was blocked by physics
                Vector3 newPosition = transform.position + openPositionOffset;
                transform.position = newPosition;
                isLocked = false;
                Debug.Log("Door Opened!");
            }
            else
            {
                Debug.Log("Door is locked! You need a key.");
            }
        }
    }
}