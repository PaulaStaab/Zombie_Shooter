using UnityEngine;

public class StormDamage : MonoBehaviour
{
    public Transform player;
    public Collider2D safeZone;
    public float damagePerSecond = 5f;

    private PlayerHealth playerHealth; // Dein Health-Script

    void Start()
    {
            // Sucht das Script AM Player-Objekt
            playerHealth = player.GetComponent<PlayerHealth>();
        }

void Update()
    {
        // Prüfe ob Spieler außerhalb der Safe Zone
        if (!safeZone.bounds.Contains(player.position))
        {
            //playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}
