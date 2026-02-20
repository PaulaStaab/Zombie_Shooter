using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene3 : MonoBehaviour
{
    [Header("Buttons (Drag hier rein)")]
    public Button PlayButton;

    void Start()
    {
        // Listener für die Buttons setzen
        if (PlayButton != null)
            PlayButton.onClick.AddListener(NewGame);
    }

    // "New Game" / Restart: Einfach die Game-Scene laden
    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");  // Laden der Game-Szene
    }
}