using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float direction = 1f;  // 1 = rechts, -1 = links

    void Update()
    {
        // Automatisch horizontal bewegen
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    // Bei Wandumkehr (BoxCollider2D mit Trigger)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            direction *= -1;  // Richtung umkehren
        }
    }
}
