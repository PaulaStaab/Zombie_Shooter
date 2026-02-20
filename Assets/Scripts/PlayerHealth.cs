using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private bool isInvulnerable;
    private GameObject activeShield;  // Instanziiertes Schild-GameObject
    private Coroutine shieldRoutine;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        // UpdateHealthBar() hier aufrufen falls vorhanden
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return;  // Schild blockt

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        Debug.Log("Player took damage: " + damage + " | Health: " + currentHealth);
        // UpdateHealthBar() + Death-Check hier
    }

    public void ActivateShield(float duration, GameObject shieldPrefab)
    {
        if (shieldRoutine != null) StopCoroutine(shieldRoutine);
        shieldRoutine = StartCoroutine(ShieldCo(duration, shieldPrefab));
    }

    private IEnumerator ShieldCo(float duration, GameObject shieldPrefab)
    {
        isInvulnerable = true;

        // Schild spawnen als Child vom Player
        if (shieldPrefab != null)
        {
            activeShield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
            activeShield.transform.SetParent(transform);  // Folgt dem Player
            activeShield.transform.localPosition = Vector3.zero;  // Zentriert
        }

        yield return new WaitForSeconds(duration);

        isInvulnerable = false;

        // Schild zerstören
        if (activeShield != null)
        {
            Destroy(activeShield);
        }

        shieldRoutine = null;
    }
}
