using UnityEngine;
using UnityEngine.UI;

public class HealthBarController1 : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerHealth playerHealth;

    void Start()
    {
        if (playerHealth == null) playerHealth = GetComponent<PlayerHealth>();
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.currentHealth;
    }

    public void UpdateHealthBar(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }
}
