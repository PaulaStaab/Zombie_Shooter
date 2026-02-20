using UnityEngine;

public class Bullet2 : MonoBehaviour
    {
        public float damage = 10f;

        void OnTriggerEnter2D(Collider2D other) // Wir nennen es "other"
        {
            // 1. LOGIK VERBESSERT: Statt "targetEnemy" prüfen wir, ob es EIN Enemy ist
            if (other.CompareTag("Enemy"))
            {
                EnemyHealth1 enemy = other.GetComponent<EnemyHealth1>();

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Debug.Log($"✓ {other.name} getroffen! -{damage} HP");
                }

                // Kugel zerstören, damit sie nicht durchfliegt
                Destroy(gameObject);
            }
            else if (other.CompareTag("Wall")) // Optional: Kugel an Wänden zerstören
            {
                Destroy(gameObject);
            }
        }
    }

