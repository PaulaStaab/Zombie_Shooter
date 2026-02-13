using UnityEngine;

public class WeaponShoot2 : MonoBehaviour
{
    public GameObject bulletPrefab;  // Bullet Prefab hier reinziehen
    public float bulletSpeed = 15f;
    public Transform shootPoint;
    public float damage = 10f;
    public LayerMask enemyLayer = -1;  // Enemy Layer

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootRaycast();
            SpawnBulletVisual();  // Visuelle Bullet spawnen
        }
    }

    void ShootRaycast()
    {
        // RAYCAST ab ShootPoint!
        Vector2 direction = transform.right * Mathf.Sign(transform.root.localScale.x);
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, direction, 10f, enemyLayer);

        // VISUELLE BULLET-LINIE (optional)
        Debug.DrawRay(shootPoint.position, direction * 10f, Color.red, 1f);

        if (hit.collider != null)
        {
            // EnemyHealth finden & Schaden!
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log($" Enemy getroffen! -{damage} HP");
            }
        }
    }

    void SpawnBulletVisual()
    {
        // Bullet-Prefab spawnen für visuellen Effekt
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 direction = transform.right * Mathf.Sign(transform.root.localScale.x);
                rb.linearVelocity = direction * bulletSpeed;
            }

            Destroy(bullet, 2f);  // Bullet nach 2 Sekunden zerstören
        }
    }
}
