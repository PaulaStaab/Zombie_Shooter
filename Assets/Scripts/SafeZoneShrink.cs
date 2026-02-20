using UnityEngine;
using System.Collections;
using TMPro; // Für TextMeshPro

public class SafeZoneShrink : MonoBehaviour
{
    [Header("Timing")]
    public float warningTime = 27f;        // Nach 27 Sek Warnung
    public float shrinkStartTime = 30f;    // Nach 30 Sek startet Shrink
    public float shrinkDuration = 15f;     // 15 Sek bis zur Zielgröße

    [Header("Zone Settings")]
    public Vector3 startScale = new Vector3(50f, 50f, 1f);  // Groß = ganzes Feld
    public Vector3 targetScale = new Vector3(10f, 10f, 1f); // Klein = Endgröße

    [Header("UI")]
    public GameObject warningText;         // Ziehe UI-Text hier rein

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        transform.localScale = startScale;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Zone am Anfang unsichtbar (optional)
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;

        StartCoroutine(ZoneCycle());
    }

    IEnumerator ZoneCycle()
    {
        // 1. Warten bis Warnung
        yield return new WaitForSeconds(warningTime);

        // 2. Warnung anzeigen
        if (warningText != null)
        {
            warningText.SetActive(true);
            yield return new WaitForSeconds(3f); // 3 Sek Warnung
            warningText.SetActive(false);
        }

        // 3. Zone sichtbar machen
        if (spriteRenderer != null)
            spriteRenderer.enabled = true;

        // 4. Langsam schrumpfen
        float elapsed = 0f;
        while (elapsed < shrinkDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / shrinkDuration;
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale; // Final sicherstellen
    }
}
