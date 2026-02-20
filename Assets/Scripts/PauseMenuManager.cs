using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSceneController : MonoBehaviour
{
    [SerializeField] string pauseSceneName = "PauseMenuScene";
    bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   // oder eine andere Taste
        {
            if (!isPaused)
                OpenPauseMenu();
            else
                ClosePauseMenu();
        }
    }

    void OpenPauseMenu()
    {
        SceneManager.LoadScene(pauseSceneName, LoadSceneMode.Additive);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ClosePauseMenu()
    {
        SceneManager.UnloadSceneAsync(pauseSceneName);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
