using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitPlayScene : MonoBehaviour
{
    [Header("Buttons (Drag hier rein)")]
    public Button LobbyButton;

    void Start()
    {
        // Listener für die Buttons setzen
        if (LobbyButton != null)
            LobbyButton.onClick.AddListener(NewGame);
    }

    // "New Game" / Restart: Einfach die Game-Scene laden
    public void NewGame()
    {
        SceneManager.LoadScene("StartScreen");  // Laden der Game-Szene
    }
}