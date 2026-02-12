using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    public float speed = 2f;
    public float direction = 1f; // 1 = rechts, -1 = links

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // 1. Bewegen
        rb.linearVelocity = new Vector2(direction * speed, 0f);

        // 2. Sprite umdrehen (damit er nicht rückwärts läuft!)
        if (direction > 0)
        {
            // Blick nach rechts
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            // Blick nach links (spiegeln)
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Wenn er die RECHTE Wand berührt -> Lauf nach LINKS (-1)
        if (other.tag == "WallRight")
        {
            direction = -1f;
        }

        // Wenn er die LINKE Wand berührt -> Lauf nach RECHTS (1)
        if (other.tag == "WallLeft")
        {
            direction = 1f;
        }
    }
}
