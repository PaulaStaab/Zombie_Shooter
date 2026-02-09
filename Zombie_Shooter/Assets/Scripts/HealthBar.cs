using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private Slider healthSlider;

    void Start()
    {
        // Canvas + Slider als Child erstellen
        CreateHealthBar();

        // PlayerHealth verknüpfen
        if (playerHealth == null)
            playerHealth = GetComponent<PlayerHealth>();
    }

    void CreateHealthBar()
    {
        // Canvas erstellen
        GameObject canvasGO = new GameObject("HealthBarCanvas");
        canvasGO.transform.SetParent(transform);
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;

        // Canvas Scaler
        canvasGO.AddComponent<CanvasScaler>();

        // Slider erstellen
        GameObject sliderGO = new GameObject("HealthSlider");
        sliderGO.transform.SetParent(canvasGO.transform);
        healthSlider = sliderGO.AddComponent<Slider>();

        // Slider-Größe/Position
        RectTransform sliderRect = sliderGO.GetComponent<RectTransform>();
        sliderRect.sizeDelta = new Vector2(2f, 0.3f);
        sliderRect.anchoredPosition = new Vector2(0, 1.5f);

        // HealthBar initialisieren
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.currentHealth;
    }

    public void UpdateHealthBar(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }
}
