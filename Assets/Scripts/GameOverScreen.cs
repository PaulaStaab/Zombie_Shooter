using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Button ContinueButton;

    void Start()
    {
        if (ContinueButton != null)
            ContinueButton.onClick.AddListener(GameOver);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Gameover");
    }
}