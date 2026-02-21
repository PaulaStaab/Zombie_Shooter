using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public ParticleSystem collectEffect;  // Partikel reinziehen!
    public int healAmount = 100;
    public Slider playerHealthSlider;  // Slider der HealthBar des Players hier zuweisen!

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
                Debug.Log(healAmount);
            }

            // UpdateHealthBar Funktion: Setzt Slider auf 100% (voll)
            UpdateHealthBar();

            if (collectEffect != null) collectEffect.Play();
            Destroy(gameObject, 0.3f);
        }
    }

    void UpdateHealthBar()
    {
        if (playerHealthSlider != null)
        {
            playerHealthSlider.value = playerHealthSlider.maxValue;  // Auf Maximum (100%)
            Debug.Log("HealthBar auf 100% gesetzt!");
        }
        else
        {
            Debug.LogWarning("playerHealthSlider ist null! Im Inspector zuweisen.");
        }
    }
}
