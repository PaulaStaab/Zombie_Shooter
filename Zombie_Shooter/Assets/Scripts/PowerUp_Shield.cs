using UnityEngine;
using UnityEngine.UI;

public class PowerUp_Shield : MonoBehaviour
{
    public ParticleSystem collectEffect;  // Partikel reinziehen!
    public int healAmount = 100;

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
                playerHealth.AddHealth(healAmount); // Nur EINMAL aufrufen
            }

            if (collectEffect != null) collectEffect.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}
