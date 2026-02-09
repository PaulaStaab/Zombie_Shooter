using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;  // ← PUBLIC war das Problem!

    void Start()
    {
        currentHealth = maxHealth;  // Voll-Health Start
    }

    public void AddHealth(int amount)
    {
        Debug.Log("★ AddHealth aufgerufen: +" + amount);  // ← Sichtbar!

        currentHealth += amount;  // Jetzt wirkt's!
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        Debug.Log("★ Neue Health: " + currentHealth + "/" + maxHealth);

        // HealthBar updaten
        HealthBarController bar = GetComponent<HealthBarController>();
        if (bar != null)
        {
            Debug.Log("★ HealthBar gefunden!");
            bar.UpdateHealthBar(currentHealth);
        }
    }
}
