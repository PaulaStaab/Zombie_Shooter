using UnityEngine;

public class EnemyDamage_Limited : MonoBehaviour
{
    public int damageAmount = 1000;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy hit Player!");  // Kollision erkannt

            PlayerHealth_Limited playerHealth = collision.gameObject.GetComponent<PlayerHealth_Limited>();
            if (playerHealth != null)
            {
                int healthBefore = playerHealth.currentHealth;
                playerHealth.TakeDamage(damageAmount);

                Debug.Log("Player took " + damageAmount + " damage | Health: " + healthBefore + " → " + playerHealth.currentHealth);
            }
            else
            {
                Debug.LogWarning("PlayerHealth_Limted Script not found!");
            }
        }
    }
}
