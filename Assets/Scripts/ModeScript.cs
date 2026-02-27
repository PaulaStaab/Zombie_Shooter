using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeScript : MonoBehaviour
{
    public void Mode()
    {
        SceneManager.LoadScene("ModeChange");  
    }
}
