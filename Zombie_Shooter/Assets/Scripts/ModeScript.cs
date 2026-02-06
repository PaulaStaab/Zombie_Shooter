using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeScript : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("ModeChange");  
    }
}
