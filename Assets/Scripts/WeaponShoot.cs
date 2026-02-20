using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public GameObject bulletPrefab;   // Bullet-Prefab reinziehen
    public float bulletSpeed = 15f;
    public Transform shootPoint;      // Empty an der Mündung

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        // NEU: Enemy ins Bullet-Feld setzen!
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.targetEnemy = GameObject.Find("EnemyName");  // ← Enemy-Name!

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 dir = transform.right * Mathf.Sign(transform.root.localScale.x);
        rb.linearVelocity = dir * bulletSpeed;

        Destroy(bullet, 2f);
    }

}
