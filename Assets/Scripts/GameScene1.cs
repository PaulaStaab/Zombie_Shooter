using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene1 : MonoBehaviour
{
    [Header("Buttons (Drag hier rein)")]
    public Button LimitedButton;

    void Start()
    {
        // Listener für die Buttons setzen
        if (LimitedButton != null)
            LimitedButton.onClick.AddListener(NameScreen);
    }

    // "New Game" / Restart: Einfach die Game-Scene laden
    public void NameScreen()
    {
        SceneManager.LoadScene("ChooseName"); 
    }
}