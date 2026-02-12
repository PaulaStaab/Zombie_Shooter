using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject targetEnemy;  // ← ENEMY REINZIEHEN!
    public float damage = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Nur BESTIMMTEN Enemy treffen!
        if (other.gameObject == targetEnemy)
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log($"✓ {targetEnemy.name} getroffen! -{damage} HP");
            }
            Destroy(gameObject);
        }
    }
}
