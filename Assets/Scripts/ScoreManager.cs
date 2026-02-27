using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using System;

public class ScoreManager : MonoBehaviour
{
    private string apiUrl = "http://localhost/zombieshooter_api/";

    public void SubmitZombieKills(string playerName, int kills)
    {
        StartCoroutine(PostKills(playerName, kills));
    }

    IEnumerator PostKills(string name, int kills)
    {
        string jsonData = "{\"player_name\":\"" + name + "\", \"kills\":" + kills + "}";
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);

        using (UnityWebRequest request = new UnityWebRequest(apiUrl + "submit_score.php", "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Score gespeichert: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Fehler: " + request.error + " | Response: " + request.downloadHandler.text);
            }
        }
    }

    // Highscores abrufen
    public void LoadHighscores(System.Action<string[]> callback)
    {
        StartCoroutine(GetHighscores(callback));
    }

    IEnumerator GetHighscores(System.Action<string[]> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl + "get_highscores.php"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                // Parse JSON manuell oder mit JsonUtility
                Debug.Log("Highscores: " + request.downloadHandler.text);
                callback(new string[] { request.downloadHandler.text }); // Beispiel
            }
        }
    }
}
