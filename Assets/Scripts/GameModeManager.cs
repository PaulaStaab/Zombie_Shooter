using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    public enum GameMode { Unlimited, Limited }
    public GameMode currentMode = GameMode.Unlimited;

    [Header("Timer Settings (nur Limited Mode)")]
    public float gameDuration = 300f; // 5 Minuten = 300 Sekunden
    private float currentTime;

    [Header("UI")]
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel; // Panel das beim Game Over erscheint

    [Header("Spawning Settings")]
    public float unlimitedSpawnRate = 5f; // Gegner alle 5 Sekunden
    public float limitedSpawnRate = 3f;   // Gegner alle 3 Sekunden (schneller!)

    [Header("PowerUp Settings")]
    public float maxTime = 600f; // Maximale Zeit (10 Minuten Cap)

    private bool gameActive = false;

    void Start()
    {
        currentTime = gameDuration;
        gameActive = true;

        // Timer UI nur im Limited Mode anzeigen
        if (timerText != null)
        {
            timerText.gameObject.SetActive(currentMode == GameMode.Limited);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (!gameActive) return;

        // Timer nur im Limited Mode runterzählen
        if (currentMode == GameMode.Limited)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();

            // Zeit abgelaufen?
            if (currentTime <= 0)
            {
                currentTime = 0;
                GameOver();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText == null) return;

        // Zeit in Minuten:Sekunden formatieren
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Warnung bei weniger als 30 Sekunden (optional: Text rot machen)
        if (currentTime <= 30f && currentTime > 0)
        {
            timerText.color = Color.red;
        }
    }

    void GameOver()
    {
        gameActive = false;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Debug.Log("Zeit abgelaufen! Game Over!");

        // Optional: Spiel pausieren
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Gibt die aktuelle Spawn-Rate zurück (für Enemy-Spawner)
    public float GetCurrentSpawnRate()
    {
        return currentMode == GameMode.Limited ? limitedSpawnRate : unlimitedSpawnRate;
    }

    public bool IsGameActive()
    {
        return gameActive;
    }

    // WICHTIG: Zeit hinzufügen für TimePowerUp
    public void AddTime(float seconds)
    {
        if (currentMode != GameMode.Limited) return;

        currentTime += seconds;

        // Optional: Cap bei maxTime
        if (currentTime > maxTime)
        {
            currentTime = maxTime;
        }

        Debug.Log("Zeit hinzugefügt! Neue Zeit: " + Mathf.FloorToInt(currentTime) + " Sekunden");
    }
}
