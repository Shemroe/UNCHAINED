using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalKeyTrigger : MonoBehaviour
{
    // Slot for the Win Door (drag the door object here)
    public GameObject winDoorObject;

    private void OnTriggerEnter(Collider other)
    {
        // 1. Check if the player is the object entering the trigger
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the UI Manager (the reliable way)
            GameUIManager uiManager = FindObjectOfType<GameUIManager>();

            // 2. DESTROY THE DOOR (Path is cleared)
            if (winDoorObject != null)
            {
                Destroy(winDoorObject);
            }

            // 3. DESTROY THE KEY ITSELF (Key is collected)
            Destroy(gameObject);

            // 4. TRIGGER THE WIN SCREEN LAST
            if (uiManager != null)
            {
                uiManager.ShowGameWin();
            }
        }
    }
}