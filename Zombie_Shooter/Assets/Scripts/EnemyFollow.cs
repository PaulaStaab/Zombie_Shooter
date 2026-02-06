using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;  // Player per Drag & Drop
    public float speed = 2f;
    public float followDistance = 5f;  // Abstand bevor er folgt

    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < followDistance)
        {
            // Richtung zum Player
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;

            // Umdrehen Richtung Player
            transform.localScale = new Vector3(Mathf.Sign(direction.x), 1f, 1f);
        }
    }
}
