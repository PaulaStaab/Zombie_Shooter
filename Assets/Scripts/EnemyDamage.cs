using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy hit Player!");  // Kollision erkannt

            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                int healthBefore = playerHealth.currentHealth;
                playerHealth.TakeDamage(damageAmount);

                Debug.Log("Player took " + damageAmount + " damage | Health: " + healthBefore + " → " + playerHealth.currentHealth);
            }
            else
            {
                Debug.LogWarning("PlayerHealth Script not found!");
            }
        }
    }
}
