using UnityEngine;

public class PowerUp_Shield : MonoBehaviour
{
    public ParticleSystem collectEffect;
    public float shieldDuration = 2f;

    [Header("Shield Visual")]
    public GameObject shieldVisualPrefab;  // Schild-Prefab hier reinziehen!

    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            // Schild aktivieren + Prefab übergeben
            playerHealth.ActivateShield(shieldDuration, shieldVisualPrefab);
        }

        if (collectEffect != null) collectEffect.Play();
        Destroy(gameObject, 0.3f);
    }
}
