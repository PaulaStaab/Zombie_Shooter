using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float direction = 1f;  // 1 = rechts, -1 = links

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Bewegung mit Physics
        rb.linearVelocity = new Vector2(direction * speed, 0f);
    }

    // Umdrehen bei Wand-Kollision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            direction *= -1;  // Richtung umkehren
        }
    }
}
