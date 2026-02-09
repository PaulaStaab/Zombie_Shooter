using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth; 

    void Start()
    {
        currentHealth = 0;  
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        HealthBarController bar = GetComponent<HealthBarController>();
        if (bar != null)
        {
            // Hier schicken wir jetzt current UND maxHealth
            bar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }
}
