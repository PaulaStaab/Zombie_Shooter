using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    [Header("Buttons (Drag hier rein)")]
    public Button UnlimitedButton;

    void Start()
    {
        // Listener für die Buttons setzen
        if (UnlimitedButton != null)
            UnlimitedButton.onClick.AddListener(NameScreen);
    }

    // "New Game" / Restart: Einfach die Game-Scene laden
    public void NameScreen()
    {
        SceneManager.LoadScene("ChooseName"); 
    }
}