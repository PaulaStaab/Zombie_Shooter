using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth1 : MonoBehaviour
{
    public float maxHealth = 50f;
    public float currentHealth = 50f;
    public Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;  // 50!
        UpdateHealthBar();          // Bar sofort voll!
        Debug.Log("Enemy startet mit voller Health: " + currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthSlider)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    void Die()
    {
        // Explosion/Partikel, zerstören
        Destroy(gameObject);
    }
}
