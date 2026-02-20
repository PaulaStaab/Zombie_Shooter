using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth1 : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;  // 100!
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
        Destroy(gameObject);
    }
}
