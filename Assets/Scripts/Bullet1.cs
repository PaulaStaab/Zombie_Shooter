using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public GameObject targetEnemy;  // ← ENEMY REINZIEHEN!
    public float damage = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Getroffen: " + other.gameObject.name + " | Tag: " + other.gameObject.tag);
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
