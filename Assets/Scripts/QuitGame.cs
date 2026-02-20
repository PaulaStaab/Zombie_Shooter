using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        // Stoppt den Playmode im Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Schlieﬂt die Anwendung im Build 
        (EXE, APK, etc.)
        Application.Quit();
#endif
        Debug.Log("Quit Game button clicked!");

        // Funktioniert im Editor nicht sichtbar, nur im Build
        Application.Quit();
    }
}
