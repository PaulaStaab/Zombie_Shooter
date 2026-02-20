using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene2 : MonoBehaviour
{
    [Header("Buttons (Drag hier rein)")]
    public Button Unlimited;

    void Start()
    {
        // Listener für die Buttons setzen
        if (Unlimited != null)
            Unlimited.onClick.AddListener(NewGame);
    }

    // "New Game" / Restart: Einfach die Game-Scene laden
    public void NewGame()
    {
        SceneManager.LoadScene("UnlimitedMode");  // Laden der Game-Szene
    }
}