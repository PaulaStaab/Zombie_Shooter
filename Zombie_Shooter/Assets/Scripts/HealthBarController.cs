using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthSlider;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Initialisierung mit beiden Werten
            UpdateHealthBar(playerHealth.currentHealth, playerHealth.maxHealth);
        }
    }

    // Jetzt mit zwei Parametern!
    public void UpdateHealthBar(int current, int max)
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = max; // Zwingt den Slider auf das richtige Maximum
            healthSlider.value = current;
        }
    }
}