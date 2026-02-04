using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");  // A/D
        float v = Input.GetAxisRaw("Vertical");    // W/S
        float moveSpeed = Mathf.Abs(h) + Mathf.Abs(v);

        animator.SetFloat("Speed", moveSpeed);    // Animator steuern

        rb.linearVelocity = new Vector2(h * speed, v * speed);
    }
}
