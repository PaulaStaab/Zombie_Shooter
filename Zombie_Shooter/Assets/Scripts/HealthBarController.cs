using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthSlider; 
    private PlayerHealth playerHealth;

    void Start()
    {
        // Automatisch am selben GameObject finden!
        playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            healthSlider.maxValue = playerHealth.maxHealth;
            healthSlider.value = playerHealth.currentHealth;
        }
    }

    // PlayerHealth.cs ruft das auf
    public void UpdateHealthBar(int currentHealth)
    {
        if (healthSlider != null)
            healthSlider.value = currentHealth;
    }
}
