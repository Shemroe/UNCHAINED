using UnityEngine;
using StarterAssets; // Needed for the ThirdPersonController check
using TMPro; // Needed for the UI text

public class KeyCollectible : MonoBehaviour
{
    // Slot to drag the door object into in the Inspector
    public GameObject doorToDestroy;

    // Slot to drag the UI text object into
    public TextMeshProUGUI objectiveText;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that hit the key has the unique movement script
        if (other.GetComponent<ThirdPersonController>() != null)
        {
            // 1. SET THE GLOBAL STATE
            GameManager.hasDungeonKey = true;

            // 2. RUN THE SCRIPTED EVENT (DOOR VANISHES)
            if (doorToDestroy != null)
            {
                Destroy(doorToDestroy);
            }

            // 3. UPDATE THE UI ELEMENT
            if (objectiveText != null)
            {
                objectiveText.text = "EXIT UNLOCKED! ASSIGNMENT COMPLETE.";
            }

            Debug.Log("Key Acquired! Door is open.");

            // 4. DESTROY THE KEY OBJECT
            Destroy(gameObject);
        }
    }
}