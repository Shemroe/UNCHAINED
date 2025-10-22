using UnityEngine;

public class WinKey : MonoBehaviour
{
    // VARIABLES FOR LINKING (Must be public to show in Inspector)
    public GameObject endgameDoor;

    private void OnTriggerEnter(Collider other)
    {
        // 1. Check if the player is the one entering the trigger
        if (other.gameObject.CompareTag("Player"))
        {
            // 2. DESTROY THE DOOR FIRST (The path is opened)
            if (this.endgameDoor != null)
            {
                Destroy(this.endgameDoor);
            }

            // 3. DESTROY THE KEY ITSELF (The key is collected)
            Destroy(this.gameObject);

            // 4. TRIGGER THE WIN SCREEN LAST
            // We use GameManager.Instance to guarantee the script finds the UI Manager
            if (GameManager.Instance.GetComponent<GameUIManager>() != null)
            {
                GameManager.Instance.GetComponent<GameUIManager>().ShowGameWin();
            }
        }
    }
}