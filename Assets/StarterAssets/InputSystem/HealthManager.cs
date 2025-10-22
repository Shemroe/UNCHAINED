using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    // VARIABLES AND LINKS
    public int currentHealth = 100;
    public Slider healthSlider;
    public TextMeshProUGUI hpNumberText;

    public GameUIManager gameUIManager;

    public AudioClip hurtSoundClip;
    private AudioSource audioSource;

    void Start()
    {
        // 1. FORCE HEALTH RESET TO 100 (FIXES NEGATIVE START)
        currentHealth = 100;

        audioSource = GetComponent<AudioSource>();

        // 2. SET UI MAX AND CURRENT VALUES
        if (healthSlider != null)
        {
            healthSlider.maxValue = 100;
            healthSlider.value = currentHealth;
        }
        if (hpNumberText != null)
        {
            hpNumberText.text = currentHealth.ToString();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // SAFEGUARD AGAINST NEGATIVE NUMBERS
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // --- CRITICAL FIX: CHECK FOR DEATH IMMEDIATELY ---
        if (currentHealth <= 0)
        {
            Die();
            return;
        }
        // --- END CRITICAL FIX ---

        // PLAY HURT SOUND
        if (audioSource != null && hurtSoundClip != null)
        {
            audioSource.PlayOneShot(hurtSoundClip);
        }

        // Update the visual bar and number text
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
        if (hpNumberText != null)
        {
            hpNumberText.text = currentHealth.ToString();
        }

        // Send status update to the screen
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UpdateStatus("PLAYER HIT! HP: " + currentHealth);
        }
    }

    private void Die()
    {
        Debug.LogError("Game Over! The Knight has fallen.");

        // Use the direct link to call the Game Over screen
        if (gameUIManager != null)
        {
            gameUIManager.ShowGameOver();
        }
    }
}