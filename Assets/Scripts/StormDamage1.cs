using UnityEngine;

public class StormDamage1 : MonoBehaviour
{
    public Transform player;        // Player hier reinziehen
    public Collider2D safeZone;     // BoxCollider2D der SafeZone
    public float damagePerSecond = 10f;

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // 1. Bounds der SafeZone holen
        Bounds b = safeZone.bounds;

        // 2. Check: Ist der Player auﬂerhalb?
        bool outside =
            player.position.x < b.min.x ||
            player.position.x > b.max.x ||
            player.position.y < b.min.y ||
            player.position.y > b.max.y;

        if (outside)
        {
            // Debug zur Kontrolle
            Debug.Log("Player ist AUSSERHALB der SafeZone, StormDamage!");

            // 3. Schaden pro Sekunde
        }

        void Update()
        {
            Bounds b = safeZone.bounds;

            // Player ist im STURM, wenn er NICHT in der SafeZone ist
            bool playerImSturm = !b.Contains(player.position);

            if (playerImSturm)
            {
                Debug.Log("STURM-SCHADEN!");
                playerHealth.TakeDamage(Mathf.RoundToInt(damagePerSecond * Time.deltaTime));
            }
        }

    }
}
