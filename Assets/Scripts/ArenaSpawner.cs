using UnityEngine;

public class ArenaSpawner : MonoBehaviour
{
    [Header("Arena-Grenzen")]
    public Vector2 arenaMin;   // z.B. (-8, -4)
    public Vector2 arenaMax;   // z.B. ( 8,  4)

    [Header("Enemy")]
    public GameObject enemyPrefab;
    public int maxEnemies = 20;
    public float enemySpawnIntervalMin = 1.5f;
    public float enemySpawnIntervalMax = 3.0f;
    private float enemySpawnTimer;

    [Header("PowerUps (Prefabs)")]
    public GameObject timerPowerUpPrefab;
    public GameObject shieldPowerUpPrefab;
    public GameObject healthPowerUpPrefab;

    [Header("PowerUp Spawn-Intervale")]
    public float timerPowerUpSpawnDelay = 8f;
    public float shieldPowerUpSpawnDelay = 10f;
    public float healthPowerUpSpawnDelay = 6f;

    // interne Timer für PowerUps
    private float timerPowerUpTimer;
    private float shieldPowerUpTimer;
    private float healthPowerUpTimer;

    void Start()
    {
        ResetEnemySpawnTimer();
        timerPowerUpTimer = timerPowerUpSpawnDelay;
        shieldPowerUpTimer = shieldPowerUpSpawnDelay;
        healthPowerUpTimer = healthPowerUpSpawnDelay;
    }

    void Update()
    {
        HandleEnemySpawning();
        HandlePowerUpSpawning();
    }

    // ----------------------------------------------------------
    // Gegner-Spawn
    // ----------------------------------------------------------
    void HandleEnemySpawning()
    {
        if (enemyPrefab == null) return;

        enemySpawnTimer -= Time.deltaTime;

        if (enemySpawnTimer <= 0f)
        {
            int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (currentEnemies < maxEnemies)
            {
                Vector2 spawnPos = GetRandomPositionInArena();
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }

            ResetEnemySpawnTimer();
        }
    }

    void ResetEnemySpawnTimer()
    {
        enemySpawnTimer = Random.Range(enemySpawnIntervalMin, enemySpawnIntervalMax);
    }

    // ----------------------------------------------------------
    // PowerUp-Spawn (immer nur 1 pro Typ)
    // ----------------------------------------------------------
    void HandlePowerUpSpawning()
    {
        // Timer PowerUp
        if (timerPowerUpPrefab != null)
        {
            if (!IsPowerUpOnField("TimerPowerUp"))
            {
                timerPowerUpTimer -= Time.deltaTime;
                if (timerPowerUpTimer <= 0f)
                {
                    SpawnPowerUp(timerPowerUpPrefab);
                    timerPowerUpTimer = timerPowerUpSpawnDelay;
                }
            }
        }

        // Schild PowerUp
        if (shieldPowerUpPrefab != null)
        {
            if (!IsPowerUpOnField("ShieldPowerUp"))
            {
                shieldPowerUpTimer -= Time.deltaTime;
                if (shieldPowerUpTimer <= 0f)
                {
                    SpawnPowerUp(shieldPowerUpPrefab);
                    shieldPowerUpTimer = shieldPowerUpSpawnDelay;
                }
            }
        }

        // Health PowerUp
        if (healthPowerUpPrefab != null)
        {
            if (!IsPowerUpOnField("HealthPowerUp"))
            {
                healthPowerUpTimer -= Time.deltaTime;
                if (healthPowerUpTimer <= 0f)
                {
                    SpawnPowerUp(healthPowerUpPrefab);
                    healthPowerUpTimer = healthPowerUpSpawnDelay;
                }
            }
        }
    }

    bool IsPowerUpOnField(string powerUp)
    {
        // Jede PowerUp-Art sollte ihren eigenen Tag haben:
        // "TimerPowerUp", "ShieldPowerUp", "HealthPowerUp"
        GameObject existing = GameObject.FindGameObjectWithTag(powerUp);
        return existing != null;
    }

    void SpawnPowerUp(GameObject powerUpPrefab)
    {
        Vector2 spawnPos = GetRandomPositionInArena();
        Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
    }

    // ----------------------------------------------------------
    // Hilfsfunktion: zufällige Position innerhalb Arena
    // ----------------------------------------------------------
    Vector2 GetRandomPositionInArena()
    {
        float x = Random.Range(arenaMin.x, arenaMax.x);
        float y = Random.Range(arenaMin.y, arenaMax.y);
        return new Vector2(x, y);
    }
}
