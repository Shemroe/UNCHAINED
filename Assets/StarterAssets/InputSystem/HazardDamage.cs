using UnityEngine;

public class HazardDamage : MonoBehaviour
{
    public int damageToDeal = 25; // Set this value in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that hit the blade has the HealthManager script
        HealthManager playerHealth = other.GetComponent<HealthManager>();

        if (playerHealth != null)
        {
            // Player hit! Deal damage and update UI via HealthManager
            playerHealth.TakeDamage(damageToDeal);
        }
    }
}