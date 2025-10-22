using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    // VARIABLES: Drag your panels here in the Inspector
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    // --- PAUSE/RESUME LOGIC (The only Update function needed) ---
    void Update()
    {
        // Checks for the ESCAPE key AND the 'P' key
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale > 0)
            {
                PauseGame();
            }
            else if (Time.timeScale == 0 && !gameOverPanel.activeSelf && !gameWinPanel.activeSelf)
            {
                ResumeGame();
            }
        }

        // RESTART LOGIC (Checks for 'R' Key on Win/Loss Screens)
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Time.timeScale == 0f && (gameOverPanel.activeSelf || gameWinPanel.activeSelf))
            {
                RestartGame();
            }
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // Shows Game Over screen and stops time
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Shows Game Win screen and stops time
    public void ShowGameWin()
    {
        gameWinPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Called by ALL restart buttons and 'R' key
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}