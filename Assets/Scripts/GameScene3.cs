using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene3 : MonoBehaviour
{
    [Header("Buttons (Drag hier rein)")]
    public Button NewGameButton;

    void Start()
    {
        // Listener für die Buttons setzen
        if (NewGameButton != null)
            NewGameButton.onClick.AddListener(NewGame);
    }

    // "New Game" / Restart: Einfach die Game-Scene laden
    public void NewGame()
    {
        SceneManager.LoadScene("UnlimitedMode");  // Laden der Game-Szene
    }
}