using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float damage = 25f;  // Schaden pro Treffer

    void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Prüfen: Ist das getroffene Objekt ein ENEMY?
        if (other.CompareTag("Enemy"))
        {
            // Health-Script vom Enemy holen
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // Schaden machen
                Debug.Log($"✓ {other.name} getroffen! -{damage} HP");
            }

            Destroy(gameObject); // Kugel löschen
        }

        // 2. Kugel an Wänden zerstören (WallRight, WallLeft oder Wall)
        else if (other.tag.Contains("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
