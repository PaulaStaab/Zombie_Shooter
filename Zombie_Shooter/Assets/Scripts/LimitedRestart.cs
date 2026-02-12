using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LimitedRestart : MonoBehaviour
{
    [Header("Buttons (Drag hier rein)")]
    public Button Restart;

    void Start()
    {
        // Listener für die Buttons setzen
        if (Restart != null)
            Restart.onClick.AddListener(NewGame);
    }

    // "New Game" / Restart: Einfach die Game-Scene laden
    public void NewGame()
    {
        SceneManager.LoadScene("LimitedMode");  // Laden der Game-Szene
    }
}