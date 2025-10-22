using UnityEngine;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering is the Player (must be tagged "Player")
        if (other.gameObject.CompareTag("Player"))
        {
            // CRITICAL CHECK: Has the player collected the final key?
            if (GameManager.hasDungeonKey)
            {
                // FIX: Access the UI Manager through the Game Manager Instance
                if (GameManager.Instance != null)
                {
                    // Get the UI Manager component from the Game Manager object
                    GameUIManager uiManager = GameManager.Instance.GetComponent<GameUIManager>();

                    if (uiManager != null)
                    {
                        uiManager.ShowGameWin();
                    }
                }

                // Optional: Destroy the door here for visual effect
                // Destroy(gameObject); 
            }
            else
            {
                // Key not collected. Tell the player what to do.
                Debug.Log("Door is locked! Find the Final Key.");
            }
        }
    }
}