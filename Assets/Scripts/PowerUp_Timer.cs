using UnityEngine;

public class PowerUp_Timer : MonoBehaviour
{
    [Header("Time Bonus Settings")]
    public float timeToAdd = 30f; // Sekunden die hinzugefügt werden

    [Header("Visual Feedback (optional)")]
    public GameObject collectParticles; // Partikel beim Einsammeln
    public AudioClip collectSound; // Sound beim Einsammeln

    private GameModeManager gameModeManager;

    void Start()
    {
        gameModeManager = FindObjectOfType<GameModeManager>();
    }

    void Update()
    {
        // Rotation für Attraktivität
        transform.Rotate(0, 0, 90 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Zeit hinzufügen (nur im Limited Mode)
            if (gameModeManager != null && gameModeManager.currentMode == GameModeManager.GameMode.Limited)
            {
                gameModeManager.AddTime(timeToAdd);

                // Visual Feedback
                if (collectParticles != null)
                {
                    Instantiate(collectParticles, transform.position, Quaternion.identity);
                }

                // Audio Feedback
                if (collectSound != null)
                {
                    AudioSource.PlayClipAtPoint(collectSound, transform.position);
                }

                Debug.Log("+" + timeToAdd + " Sekunden!");
            }
            else if (gameModeManager != null)
            {
                // Im Unlimited Mode hat das PowerUp keine Funktion
                Debug.Log("Zeit-PowerUp funktioniert nur im Limited Mode!");
            }

            // PowerUp zerstören
            Destroy(gameObject);
        }
    }
}
