using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // GetAxisRaw = SOFORT 0, wenn Taste losgelassen!
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Genau 0 ohne Taste, >0 mit Taste
        float moveAmount = Mathf.Abs(h) + Mathf.Abs(v);

        // Animator sofort updaten
        animator.SetFloat("Speed", moveAmount);

        // Umdrehen bei Horizontal-Bewegung (A/D)
        if (h != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(h), 1f, 1f);
        }

        // Bewegen nur bei Input
        transform.Translate(new Vector2(h, v) * speed * Time.deltaTime);
    }
}
