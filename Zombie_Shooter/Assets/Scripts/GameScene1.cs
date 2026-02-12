using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene1 : MonoBehaviour
{
    [Header("Buttons (Drag hier rein)")]
    public Button Limited;

    void Start()
    {
        // Listener für die Buttons setzen
        if (Limited != null)
            Limited.onClick.AddListener(NewGame);
    }

    // "New Game" / Restart: Einfach die Game-Scene laden
    public void NewGame()
    {
        SceneManager.LoadScene("LimitedMode");  // Laden der Game-Szene
    }
}