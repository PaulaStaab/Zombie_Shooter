using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Limited : MonoBehaviour
{
    [Header("Buttons (Drag hier rein)")]
    public Button MovetoLimited;
    void Start()
    {
        // Listener für die Buttons setzen
        if (MovetoLimited != null)
            MovetoLimited.onClick.AddListener(NewGame);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Limited"); 
    }
}