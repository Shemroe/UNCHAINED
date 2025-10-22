using UnityEngine;
using TMPro; // Needed for the UI text component

public class GameManager : MonoBehaviour
{
    public static bool hasDungeonKey = false;

    public static GameManager Instance;

    public TextMeshProUGUI statusText; // The slot for the on-screen text

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // THIS FUNCTION CLEARS THE COMPILER ERROR
    public void UpdateStatus(string message)
    {
        if (statusText != null)
        {
            statusText.text = message;
        }
    }
}