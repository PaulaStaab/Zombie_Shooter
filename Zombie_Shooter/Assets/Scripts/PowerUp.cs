using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public ParticleSystem collectEffect;  // Partikel reinziehen!
    public int healAmount = 25;

    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.AddHealth(healAmount);
            }

            if (playerHealth != null)
            {
                Debug.Log("PowerUp gefunden!");  //s Test
                playerHealth.AddHealth(healAmount);
            }

            // Partikel-Explosion bei Collect!
            if (collectEffect != null)
            {
                collectEffect.Play();  // Start!
            }

            Destroy(gameObject, 0.3f);  // Kurz warten für Effekt
        }
    }
}
