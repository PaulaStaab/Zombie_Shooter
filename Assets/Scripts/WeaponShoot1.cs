using UnityEngine;

public class WeaponShoot1 : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public Transform shootPoint;
    public float damage = 10f;
    public LayerMask enemyLayer = -1;  // Enemy Layer

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootRaycast();
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
                Debug.Log($"✓ Enemy getroffen! -{damage} HP");
            }
        }
    }
}
